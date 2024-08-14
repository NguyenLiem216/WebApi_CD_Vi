using System.ComponentModel.DataAnnotations;

namespace API_Tutorial_ProductManager.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = null!;
        [Required]
        [MaxLength(250)]
        public string Password { get; set; } = null!;
    }
}
