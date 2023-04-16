
using Microsoft.EntityFrameworkCore;
using API.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt=>{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Problem details service
builder.Services.AddProblemDetails();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();



var app = builder.Build();

//for show error 
app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
 
var scope=app.Services.CreateScope();
var context=scope.ServiceProvider.GetRequiredService<StoreContext>();
var logger=scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    context.Database.Migrate();
    DbInitializer.Initializer(context);
}
catch (System.Exception ex)
{
    
    logger.LogError(ex,"Error Migrating data");
}
finally{
    scope.Dispose();
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(opt => 
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000","http://localhost:80");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
