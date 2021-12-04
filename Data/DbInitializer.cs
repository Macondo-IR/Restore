using System.Collections.Immutable;
using System.Text;
using System.Linq;
using API.Entities;
using FizzWare.NBuilder;

namespace API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            if(context.Products.Any()) return;
            var Products=Builder<Product>.CreateListOfSize(100).Build();
            
            foreach (var item in Products)
            {
                context.Products.Add(item);
            }
            context.SaveChanges();

        }
    }
}