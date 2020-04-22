using System.ComponentModel.DataAnnotations;
using Yerel.Entities;

namespace Yerel.aws.Models
{
    public class LoginViewModel
    {
        public User User { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(30, ErrorMessage = "Geçerli uzunlukta bir e-mail adresi girin..", MinimumLength = 8)]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
    ErrorMessage = "E-mail is not valid..")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(10, ErrorMessage = "Please enter a valid password..", MinimumLength = 4)]
        public string Password { get; set; }
    }
}