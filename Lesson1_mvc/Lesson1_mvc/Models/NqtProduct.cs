namespace Lesson1_mvc.Models
{
    public class NqtProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageUrl { get; set; }
    }
}