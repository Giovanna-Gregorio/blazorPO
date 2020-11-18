using BlazorPO.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorPO.Server
{
    public class ApplicationDbContext : IdentityDbContext //DbContext
    {
        //precisa armazenar informações em um banco do qual não herdamos
        //configurações que o EF precisa para gerenciar as tabelas do banco de identidade
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.SetInitializer(new PODBInitializer());
        }

        public DbSet<Product> Product { get; set; }
        
        public DbSet<Category> Category { get; set; }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<IdentityUser>().HasData(
        //         new IdentityUser() { UserName = "Teste", Email = "teste1@gmail.com"}
        //     );

        //     builder.Entity<Category>().HasData(
        //         new Category() { Id = 1, Description = "Bebidas" },
        //         new Category() { Id = 2, Description = "Limpeza" },
        //         new Category() { Id = 3, Description = "Frutas" }
        //     );

        //     builder.Entity<Category>().HasData(
        //         new Product() { Id = 1, Name = "Coca-cola",  Price = 5, IdCategory = 1 },
        //         new Product() { Id = 2, Name = "Desinfetante", Price = 8, IdCategory = 2 },
        //         new Product() { Id = 3, Name = "Maçã", Price = 1, IdCategory = 3 }
        //     );
        // }

    }
}