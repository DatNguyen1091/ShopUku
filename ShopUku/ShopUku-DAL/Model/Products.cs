
namespace ShopUku_DAL.Model
{
    public class Products
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public decimal price { get; set; }
        public decimal oldPrice { get; set; }
        public string? imageUrl { get; set; }
        public int quantity { get; set; }
        public int categoryId { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
