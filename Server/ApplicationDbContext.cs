using BlazorPO.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorPO.Server
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //precisa armazenar informações em um banco do qual não herdamos
        //configurações que o EF precisa para gerenciar as tabelas do banco de identidade
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //public DbSet<Product> Product { get; set; }
        
        //public DbSet<Category> Category { get; set; }
        
    }
}