using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorPO.Shared
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Description { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}