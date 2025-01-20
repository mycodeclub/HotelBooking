using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Areas.Admin
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
