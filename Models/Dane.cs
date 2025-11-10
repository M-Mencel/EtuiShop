using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etui.Models
{
    public class Dane
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Imie jest wymagane")]
        [DisplayName("Imie")]
        [StringLength(160)]
        public string imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [DisplayName("Nazwisko")]
        [StringLength(160)]
        public string nazwisko { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [DisplayName("E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}",
        ErrorMessage = "Email jest nie poprawny.")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Ulica jest wymagana")]
        [DisplayName("Ulica")]
        [StringLength(30)]
        public string ulica { get; set; }

        [Required(ErrorMessage = "Nr domu jest wymagany")]
        [DisplayName("Nr domu")]
        [StringLength(10)]
        public string nrdomu { get; set; }

        [Required(ErrorMessage = "Nr lokalu jest wymagany")]
        [DisplayName("Nr lokalu")]
        [StringLength(10)]
        public string nrlokalu { get; set; }


        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        [DisplayName("Kod pocztowy")]
        [StringLength(10)]
        public int kodpocztowy { get; set; }

        [Required(ErrorMessage = "Miejscowość jest wymagana")]
        [DisplayName("Miejscowość")]
        [StringLength(40)]
        public string miejscowosc { get; set; }

        [Required(ErrorMessage = "Nr Telefonu jest wymagany")]
        [DisplayName("Numer Telefonu")]
        [MinLength(9, ErrorMessage = "Nr jest zbyt krótki.")]
        [StringLength(12, ErrorMessage = "Nr jest zbyt długi.")]
        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$",
        ErrorMessage = "Nr jest nie poprawny.")]
        public int nrtelefonu { get; set; }
        
    }
}
