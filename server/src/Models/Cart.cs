namespace Server.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public List<CartItem> Items { get; set; }

        public decimal TotalPrice { get; set; }
        public Country Country { get; set; }
        
        public int TotalQuantity => Items?.Sum(i => i.Quantity) ?? 0;

    }
}