
namespace ShopUku_DAL.Model
{
    public class Categories
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
