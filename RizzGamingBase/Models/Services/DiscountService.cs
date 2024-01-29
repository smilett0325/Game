using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Services
{
	public class DiscountService
	{
		private readonly IDiscountRepository _repo;
		public DiscountService(IDiscountRepository repo)
		{
			_repo = repo;
		}

		public List<DiscountEventDto> GetAllEvent()
		{
			var enetity = _repo.GetAllEvent();
			return DiscountEventExts.EntityToDto(enetity);
		}

		public List<DiscountDto> GetEventDetail(int eventId)
		{
			var enetity = _repo.GetEventDetail(eventId);
			return DiscountExts.EntityToDto(enetity);
		}

		public DiscountItemDto GetEventItem(int eventId)
		{
			var enetity = _repo.GetEventItem(eventId);
			var dto = DiscountItemExts.EntityToDto(enetity);
			return dto;
		}
	}
}