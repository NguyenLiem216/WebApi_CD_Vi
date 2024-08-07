using System.ComponentModel.DataAnnotations;

namespace API_Tutorial_ProductManager.Models
{
    public class ModelType
    {
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; } = null!;
    }
}
