
namespace ShopUku_DAL.Model
{
    public class Carts
    {
        public int id { get; set; }
        public string? uniqueCartId { get; set; }
        public string? cartStatus { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
