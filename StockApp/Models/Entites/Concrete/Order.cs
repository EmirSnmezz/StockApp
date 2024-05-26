namespace StockApp.Models.Entites.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductName { get; set; }
        public int CustomerId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
