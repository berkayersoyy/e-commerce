namespace ECommerce.Basket.API.Entities
{
    public class ShoppingCartItem
    {
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}