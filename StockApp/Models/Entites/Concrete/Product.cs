using System.ComponentModel.DataAnnotations;

namespace StockApp.Models.Entites.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Ürün Adı Boş Geçilemez")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Ürün Adı Boş Geçilemez")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Ürün Adı Boş Geçilemez")]
        public int BrandId { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
