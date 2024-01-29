using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Exts
{
	public static class DiscountEventExts
	{
		public static List<DiscountEventEntity> DbToEntity()
		{
			var db = new AppDbContext();

			var entity = db.Discounts.AsNoTracking()
						   .Select(d => new DiscountEventEntity
						   {
							   Id = d.Id,
							   //DiscountName = d.Name,
							   //DiscountImage = d.Image,
							   DiscountType = d.DiscountType,
							   StartDate = d.StartDate,
							   EndDate = d.EndDate,
							   Percent = d.Persent
						   }).ToList();
			return entity;
		}

		public static List<DiscountEventDto> EntityToDto(this List<DiscountEventEntity> entity)
		{
			var listvm = new List<DiscountEventDto>();

			foreach (var e in entity)
			{
				var vm = new DiscountEventDto
				{
					Id = e.Id,
					DiscountName = e.DiscountName,
					DiscountImage = e.DiscountImage,
					DiscountType = e.DiscountType,
					StartDate = e.StartDate,
					EndDate = e.EndDate,
					Percent = e.Percent,
				};
				listvm.Add(vm);
			}

			return listvm;
		}

		public static List<DiscountEventVm> DtoToIndexVm(this List<DiscountEventDto> dtos)
		{
			var listvm = new List<DiscountEventVm>();

			foreach (var dto in dtos)
			{
				var vm = new DiscountEventVm
				{
					Id = dto.Id,
					DiscountName = dto.DiscountName,
					DiscountImage = dto.DiscountImage,
					DiscountType = dto.DiscountType,
					StartDate = dto.StartDate,
					EndDate = dto.EndDate,
					Persent = dto.Percent
				};
				listvm.Add(vm);
			}

			return listvm;
		}
	}
}