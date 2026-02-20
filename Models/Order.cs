public class Order
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public decimal TotalAmount { get; set; }

    public string Status { get; set; }

//Snapshot danych
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Email { get; set; }

    public string Ulica { get; set; }
    public string NrDomu { get; set; }
    public string NrLokalu { get; set; }

    public string KodPocztowy { get; set; }
    public string Miejscowosc { get; set; }

    public string NrTelefonu { get; set; }

    public List<OrderItem> Items { get; set; }
}