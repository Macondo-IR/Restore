
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Middleware;

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

app.UseMiddleware<ExceptionMiddleware>();
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
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000","http://185.8.173.74:80","http://185.8.173.74");
});


app.UseAuthorization();

app.MapControllers();

app.Run();
