namespace ShopBook187.API.Models
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
