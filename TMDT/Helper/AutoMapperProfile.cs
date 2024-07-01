using AutoMapper;
using TMDT.Data;
using TMDT.ViewModels;
namespace TMDT.Helper
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile() {
			CreateMap<RegisterVM, KhachHang>();
			
		}
	}
}
