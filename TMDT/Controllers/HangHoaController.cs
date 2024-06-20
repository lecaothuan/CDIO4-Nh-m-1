using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMDT.Data;
using TMDT.ViewModels;

namespace TMDT.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly TmdtContext db;

        public HangHoaController(TmdtContext context)
        {
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

        public IActionResult Detail(int id)
        {
            var data = db.HangHoas
                .Include(p => p.MaLoaiNavigation)
                .SingleOrDefault(p => p.MaHh == id);
            if (data == null)
            {
                TempData["Message"] = $"Không thấy sãn phẩm có mã {id}";
                return Redirect("/404");
            }
            var result = new ChiTietHangHoaVM
            {
                MaHH = data.MaHh,
                TenHH = data.TenHh,
                DonGia = data.DonGia ?? 0,
                ChiTiet = data.MoTa ?? string.Empty,
                Hinh = data.Hinh ?? string.Empty,
                MoTaNgan = data.MoTaDonVi ?? string.Empty,
                TenLoai = data.MaLoaiNavigation.TenLoai,
                SoLuongTon = 10,
                DiemDanhGia = 5,

            };


            return View(result);
        }
    }
}
