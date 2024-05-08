namespace FinalProjectASP.Models
{
    public class Order
    {
        public int orderId {  get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public int productPrice { get; set; }
        public string userName { get; set; }

    }
}
