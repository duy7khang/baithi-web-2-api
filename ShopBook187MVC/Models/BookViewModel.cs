using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopBook187MVC.Models
{
    public class BookViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [DisplayName("Book Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid price")]
        public decimal Price { get; set; }
    }
}
