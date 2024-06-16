using System.ComponentModel.DataAnnotations;

namespace StockApp.Models.Entites.Concrete
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "MÜşteri Adı Boş Geçilemez")]
        public string? CustomerName { get; set; }
        [Required(ErrorMessage = "Müşteri Soyadı Boş Geçilemez")]
        public string? CustomerSurname { get; set; }
    }
}
