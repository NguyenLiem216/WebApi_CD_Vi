using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Tutorial_ProductManager.Data
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = null!;
        [Required]
        [MaxLength(250)]
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;

    }
}
