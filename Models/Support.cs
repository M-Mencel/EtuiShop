using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Etui.Models
{
    public class Support
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Login jest wymagany")]
        [DisplayName("Imię")]
        [StringLength(160)]
        public string nazwa { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [DisplayName("E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}",
        ErrorMessage = "Email jest nie poprawny.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "podaj poprawny adres Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Temat jest wymagany")]
        [DisplayName("Temat")]
        [StringLength(160)]
        public string temat { get; set; }

        [Required(ErrorMessage = "Wiadomość jest wymagana")]
        [MinLength(50)]
        [DisplayName("Wiadomość")]
        [StringLength(600)]
        public string wiadomosc { get; set; }

            public class typzgloszenialist
        {
            [Required(ErrorMessage = "Typ zgłoszenia jest wymagany")]
            public List<Support> typ_zgłoszenia { get; set; }
        }

    }
}
