namespace SelfServiceCheckoutApi.Models
{
    public class CheckoutInput
    {
        public Stock Stock { get; set; } = new();
        public int Price { get; set; }
    }
}
