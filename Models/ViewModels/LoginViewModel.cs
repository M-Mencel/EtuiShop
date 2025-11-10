using System.ComponentModel.DataAnnotations;

namespace Etui.Models.ViewModels
{
        public class LoginViewModel
        {
                [Required, MinLength(2, ErrorMessage = "Minimalna długość to 2")]
                [Display(Name = "Nazwa użytkownika")]
                public string UserName { get; set; }

                [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimalna długość to 4")]
                public string Password { get; set; }

                public string ReturnUrl { get; set; }
        }
}