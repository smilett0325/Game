using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Repositories.EFRepositories;
using RizzGamingBase.Models.Services;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Exts
{
	public static class DiscountDisplayExts
	{
		public static List<DiscountEventVm> GetAllEvent()
		{
			var repo = new DiscountEFRepository();
			var service = new DiscountService(repo);
			var vm = service.GetAllEvent();

			return DiscountEventExts.DtoToIndexVm(vm);
		}

		public static List<DiscountVm> GetEventDetail(int eventId)
		{
			var repo = new DiscountEFRepository();
			var service = new DiscountService(repo);
			var vm = service.GetEventDetail(eventId);

			return DiscountExts.DtoToVm(vm);
		}

		public static DiscountEditVm GetEventItem(int eventId)
		{
			var repo = new DiscountEFRepository();
			var service = new DiscountService(repo);
			var dto = service.GetEventItem(eventId);
			var vm = DiscountItemExts.DtoToIndexVm(dto);

			return vm;
		}
	}
}