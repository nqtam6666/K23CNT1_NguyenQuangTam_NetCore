using lab3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

public class NqtHotProductViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var hotProducts = new List<NqtProduct>
        {
            new NqtProduct { Name = "Nồi cơm điện tử Nagakawa NAG0102", Image = "hotproduct1.jpg" },
            new NqtProduct { Name = "Nồi cơm điện tử Nagakawa NAG0102", Image = "hotproduct2.jpg" },
            new NqtProduct { Name = "Nồi cơm điện tử Nagakawa NAG0102", Image = "hotproduct3.jpg" }
        };
        return View(hotProducts);
    }
}

public class Product
{
    public string Name { get; set; }
    public string Image { get; set; }
}