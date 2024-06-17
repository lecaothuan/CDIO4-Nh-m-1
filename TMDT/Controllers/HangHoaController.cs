using Microsoft.AspNetCore.Mvc;

namespace TMDT.Controllers
{
    public class HangHoaController : Controller
    {
        public IActionResult Index(int? loai)
        {
            return View();
        }
    }
}
