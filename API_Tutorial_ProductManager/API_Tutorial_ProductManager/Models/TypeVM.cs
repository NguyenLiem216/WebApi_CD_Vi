using System.ComponentModel.DataAnnotations;

namespace API_Tutorial_ProductManager.Models
{
    public class TypeVM
    {
        public int Id_Type { get; set; }
        public string TypeName { get; set; } = null!;
    }
}
