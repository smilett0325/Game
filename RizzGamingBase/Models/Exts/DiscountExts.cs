using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RizzGamingBase.Models.Exts
{
	public static class DiscountExts
	{
		public static List<DiscountEntity> DbToEntity(int eventId)
		{
			var db = new AppDbContext();

			var entity = db.DiscountItems.AsNoTracking()
						   .Include(d => d.Discount)
						   .Include(d => d.Game)
						   .Include(d => d.Game.Developer)
						   //.Include(d => d.Game.GameTag.Tag)
						   .Where(d => d.DiscountId == eventId)
						   .Select(d => new DiscountEntity
						   {
							   Id = d.Id,
							   DiscountType = d.Discount.DiscountType,
							   Game = d.Game.Name,
							   //GameTag = d.Game.GameTag.Tag.Name,
							   StartDate = d.Discount.StartDate,
							   EndDate = d.Discount.EndDate,
							   Persent = d.Discount.Persent,
							   Price = d.Game.Price,
							   Developer = d.Game.Developer.Name
						   }).ToList();

			return entity;
		}


		public static List<DiscountDto> EntityToDto(this List<DiscountEntity> Entity)
		{
			var listdtos = new List<DiscountDto>();
			foreach (var entity in Entity)
			{
				var dto = new DiscountDto
				{
					Id = entity.Id,
					DiscountType = entity.DiscountType,
					Game = entity.Game,
					GameTag = entity.GameTag,
					StartDate = entity.StartDate,
					EndDate = entity.EndDate,
					Persent = entity.Persent,
					Price = entity.Price,
					Developer = entity.Developer
				};
				listdtos.Add(dto);
			}
			return listdtos;
		}

		public static List<DiscountVm> DtoToVm(this List<DiscountDto> dtos)
		{
			var listvm = new List<DiscountVm>();

			foreach (var dto in dtos)
			{
				var vm = new DiscountVm
				{
					Id = dto.Id,
					DiscountType = dto.DiscountType,
					Game = dto.Game,
					GameTag = dto.GameTag,
					Developer = dto.Developer,
					StartDate = dto.StartDate,
					EndDate = dto.EndDate,
					Persent = dto.Persent,
					Price = dto.Price
				};
				listvm.Add(vm);
			}

			return listvm;
		}


	}
}