
namespace ShopUku_DAL.Model
{
    public class Orders
    {
        public int id { get; set; }
        public decimal orderTotal { get; set; }
        public decimal orderItemTotal { get; set; }
        public decimal shippingCharge { get; set; }
        public int deliveryAddressId { get; set; }
        public int customerId { get; set; }
        public string? orderStatus { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}

