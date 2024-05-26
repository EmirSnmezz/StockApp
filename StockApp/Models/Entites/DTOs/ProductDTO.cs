namespace StockApp.Models.Entites.DTOs
{
    public class ProductDTO
    {
        public string? ProductName { get; set; }
        public string? CategoryName { get; set; }
        public string? Brand { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
