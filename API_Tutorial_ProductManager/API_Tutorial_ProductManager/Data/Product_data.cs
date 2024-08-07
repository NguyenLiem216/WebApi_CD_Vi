using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tutorial_ProductManager.Data
{
    [Table("ProductManager")]
    public class Product_data
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        public byte Discount { get; set; }
        
        public int? Id_Type { get; set; }

        [ForeignKey("Id_Type")]
        public Products_Type Products_Type { get; set; }=null!;
    }
}
