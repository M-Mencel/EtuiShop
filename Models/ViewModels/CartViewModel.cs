namespace Etui.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; }

        public Dane Dane { get; set; }
    }
}
