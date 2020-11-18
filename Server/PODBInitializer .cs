using BlazorPO.Shared;

namespace BlazorPO.Server
{
    public class PODBInitializer 
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Category.AddOrUpdate(x => x.Id,
                new Category() { Id = 1, Description = "Bebidas" },
                new Category() { Id = 2, Description = "Limpeza" },
                new Category() { Id = 3, Description = "Frutas" }
                );

            context.Product.AddOrUpdate(x => x.Id,
                new Product() { Id = 1, Name = "Coca-cola",  Price = 5, IdCategory = 1 },
                new Product() { Id = 2, Name = "Desinfetante", Price = 8, IdCategory = 2 },
                new Product() { Id = 3, Name = "Maçã", Price = 1, IdCategory = 3 }
                );
        }
    }
}