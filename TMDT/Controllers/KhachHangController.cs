using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMDT.Data;
using TMDT.Helper;
using TMDT.ViewModels;

namespace TMDT.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly TmdtContext db;
		private readonly IMapper _mapper;

		public KhachHangController(TmdtContext context, IMapper mapper) 
        { 
            db=context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(RegisterVM model, IFormFile Hinh)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    var khachHang = _mapper.Map<KhachHang>(model);
                    khachHang.RandomKey = MyUtil.GenerateRamdomkey();
                    khachHang.MatKhau = model.MatKhau.ToMd5Hash(khachHang.RandomKey);
                    khachHang.HieuLuc = true;
                    khachHang.VaiTro = 0;

                    if (Hinh != null)
                    {
                        khachHang.Hinh = MyUtil.UploadHinh(Hinh, "KhachHang");
                    }

                    db.Add(khachHang);
                    db.SaveChanges();
                    return RedirectToAction("Index", "HangHoa");
                }
                catch (Exception ex) 
                { 

                }
            }
            return View();
        }
    }
}
