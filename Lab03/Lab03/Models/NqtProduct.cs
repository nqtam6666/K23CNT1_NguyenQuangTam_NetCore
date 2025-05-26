using Microsoft.AspNetCore.Mvc;

namespace lab3.Models
{
    public class NqtProduct : Controller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
