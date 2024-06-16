using System.ComponentModel.DataAnnotations;

namespace StockApp.Models.Entites.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Kategori Adı Boş Geçilemez")]
        public string CategoryName { get; set; }
    }
}
