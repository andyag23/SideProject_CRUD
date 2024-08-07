using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_SliedProject.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
