using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.ViewModels.Account
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Zły format adresu email")]
        [Required(ErrorMessage = "Adres email jest wymagany")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
