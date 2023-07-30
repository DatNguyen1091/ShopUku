
namespace ShopUku_DAL.Model
{
    public class Users
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public bool isAdmin { get; set; }
    }
}
