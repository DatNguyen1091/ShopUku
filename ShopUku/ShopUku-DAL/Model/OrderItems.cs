
namespace ShopUku_DAL.Model
{
    public class OrderItems
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
