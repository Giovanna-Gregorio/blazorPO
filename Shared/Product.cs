using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorPO.Shared
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Preço é obrigatório")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Categoria é obrigatório")] 
        public int IdCategory { get; set; }
        public Category Category{ get; set; }
    }
}