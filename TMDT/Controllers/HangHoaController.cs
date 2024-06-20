using Microsoft.AspNetCore.Mvc;
using TMDT.Data;
using TMDT.ViewModels;

namespace TMDT.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly TmdtContext db;

        public HangHoaController(TmdtContext context) {
            db = context;
        }
        public IActionResult Index(int? loai)
        {
            var hangHoas = db.HangHoas.AsQueryable();

            if (loai.HasValue)
            {
                hangHoas = hangHoas.Where(p => p.MaLoai == loai.Value);
            }

            var result = hangHoas.Select(P => new HangHoaVM
            {
                MaHH = P.MaHh,
                TenHH = P.TenHh,
                DonGia = P.DonGia ?? 0,
                Hinh = P.Hinh ?? "",
                MoTaNgan = P.MoTaDonVi ?? "",
                TenLoai = P.MaLoaiNavigation.TenLoai
            });
            return View(result);
        }
        public IActionResult Search(string? query)
        {
            var hangHoas = db.HangHoas.AsQueryable();

            if (query != null)
            {
                hangHoas = hangHoas.Where(p => p.TenHh.Contains(query));
            }

            var result = hangHoas.Select(P => new HangHoaVM
            {
                MaHH = P.MaHh,
                TenHH = P.TenHh,
                DonGia = P.DonGia ?? 0,
                Hinh = P.Hinh ?? "",
                MoTaNgan = P.MoTaDonVi ?? "",
                TenLoai = P.MaLoaiNavigation.TenLoai
            });
            return View(result);
        }
    }
}
