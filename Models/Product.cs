namespace FinalProjectASP.Models
{
    public class Product
    {   
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Descritpion { get; set; }
        public string Description2 { get; set; }
        public string Image { get; set; }

        public Order order { get; set; }
    }
}