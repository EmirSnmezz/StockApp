namespace StockApp.Models.Entites.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? CategoryId { get; set; }
        public string? Brand { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
