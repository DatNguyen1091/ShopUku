
namespace ShopUku_DAL.Model
{
    public class Customers
    {
        public int id { get; set; }
        public string? fullName { get; set; }
        public string? emailAddress { get; set; }
        public string? phoneNumber { get; set; }
        public string? addressLine { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
