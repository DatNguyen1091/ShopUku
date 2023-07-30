
namespace ShopUku_DAL.Model
{
    public class Feedback
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
        public DateTime createdAt { get; set; }
    }
}
