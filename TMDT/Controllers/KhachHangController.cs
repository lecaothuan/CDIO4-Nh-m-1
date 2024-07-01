using Microsoft.AspNetCore.Mvc;
using TMDT.Data;
using TMDT.ViewModels;

namespace TMDT.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly TmdtContext db;
        public KhachHangController(TmdtContext context) 
        { 
            db=context;
        }
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(RegisterVM model)
        {
            if (ModelState.IsValid) 
            {
                var khachHang = model;
            }
            return View();
        }
    }
}
