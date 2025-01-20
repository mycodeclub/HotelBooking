using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Areas.Admin
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
