
namespace ShopUku_DAL.Model
{
    public class CartItems
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public int cartId { get; set; }
        public int productId { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
