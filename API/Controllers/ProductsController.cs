using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;


public class ProductsController : BaseApiController
{
    private readonly StoreContext context;

    public ProductsController(StoreContext _context)
    {
        this.context= _context;
    }

[HttpGet]
public async Task <ActionResult<List<Product>>> GetProdcucts(){
   
    return  await context.Products.ToListAsync();
}

[HttpGet("{id}")]
public async Task <ActionResult<Product>> GetProdcuct(int id){
    return await context.Products.FindAsync(id);
}
}
