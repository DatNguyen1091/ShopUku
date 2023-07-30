
namespace ShopUku_DAL.Model
{
    public class Brands
    {
        public int id { get; set; }
        public string? name { get; set; }
        public bool isDelete { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
