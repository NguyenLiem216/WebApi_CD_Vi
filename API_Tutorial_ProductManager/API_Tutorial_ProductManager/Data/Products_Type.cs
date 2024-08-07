using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tutorial_ProductManager.Data
{
    [Table("Products_Type")]
    public class Products_Type
    {
        [Key]
        public int Id_Type { get; set; }
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Product_data> Product_Datas { get; set; } = null!;
    }
}
