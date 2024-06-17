using Microsoft.AspNetCore.Mvc;
using TMDT.Data;
using TMDT.ViewModels;
namespace TMDT.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly TmdtContext db;

        public MenuLoaiViewComponent(TmdtContext context) => db = context; 
        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai = lo.MaLoai, TenLoai = lo.TenLoai, SoLuong = lo.HangHoas.Count
            });
            return View(data);
        }
    }
}
