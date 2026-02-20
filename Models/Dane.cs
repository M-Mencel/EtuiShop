using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Dane
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Imię jest wymagane")]
    [DisplayName("Imię")]
    [StringLength(160)]
    public string Imie { get; set; }

    [Required(ErrorMessage = "Nazwisko jest wymagane")]
    [DisplayName("Nazwisko")]
    [StringLength(160)]
    public string Nazwisko { get; set; }

    [Required(ErrorMessage = "Email jest wymagany")]
    [DisplayName("E-mail")]
    [EmailAddress(ErrorMessage = "Email jest niepoprawny")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Ulica jest wymagana")]
    [DisplayName("Ulica")]
    [StringLength(100)]
    public string Ulica { get; set; }

    [Required(ErrorMessage = "Nr domu jest wymagany")]
    [DisplayName("Nr domu")]
    [StringLength(10)]
    public string NrDomu { get; set; }

    [DisplayName("Nr lokalu")]
    [StringLength(10)]
    public string NrLokalu { get; set; }

    [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
    [DisplayName("Kod pocztowy")]
    [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Format: 00-000")]
    public string KodPocztowy { get; set; }

    [Required(ErrorMessage = "Miejscowość jest wymagana")]
    [DisplayName("Miejscowość")]
    [StringLength(100)]
    public string Miejscowosc { get; set; }

    [Required(ErrorMessage = "Nr telefonu jest wymagany")]
    [DisplayName("Numer telefonu")]
    [Phone(ErrorMessage = "Numer telefonu jest niepoprawny")]
    public string NrTelefonu { get; set; }
}