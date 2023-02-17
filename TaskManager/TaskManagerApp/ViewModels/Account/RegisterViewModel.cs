using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerApp.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress (ErrorMessage = "Zły format adresu email")]
        [Required (ErrorMessage = "Adres email jest wymagany")]
        public string Email { get; set; }
        [Required (ErrorMessage = "Imię jest wymagane")]
        public string FirstName{ get; set; }
        [Required (ErrorMessage = "Nazwisko jest wymagane")]
        public string LastName { get; set; }
        [Required (ErrorMessage = "Hasło jest wymagane")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required (ErrorMessage = "Potwierdzenie hasła jest wymagane")]
        [Compare(nameof(Password), ErrorMessage = "Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Telefon jest wymagany")]
        [Phone(ErrorMessage = "Zły format numeru telefonu")]
        public string CellPhone { get; set; }
    }
}
