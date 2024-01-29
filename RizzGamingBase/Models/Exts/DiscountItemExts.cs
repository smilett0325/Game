using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RizzGamingBase.Models.Class;

namespace RizzGamingBase.Models.Exts
{
	public static class DiscountItemExts
	{
		public static DiscountItemEntity DbToEntity(int eventId)
		{
			var db = new AppDbContext();

			var entity = db.DiscountItems
						   .Include(d => d.Discount)
						   .Include(d => d.Game)
						   .Include(d => d.Game.Developer)
						   //.Include(d => d.Game.GameTag.Tag)
						   .Where(d => d.DiscountId == eventId)
						   .Select(d => new DiscountItemEntity
						   {
							   Id = d.DiscountId,
							   //DiscountImage = d.Discount.Image,
							   //DiscountName = d.Discount.Name,
							   StartDate = d.Discount.StartDate,
							   EndDate = d.Discount.EndDate,
							   Persent = d.Discount.Persent,
							   //Description = d.Discount.Desciption
						   }).FirstOrDefault();

			var gameInfo = db.DiscountItems
						   .Include(d => d.Discount)
						   .Include(d => d.Game)
						   .Include(d => d.Game.Developer)
						   //.Include(d => d.Game.GameTag.Tag)
						   .Where(d => d.DiscountId == eventId)
						   .Select(d =>
							   new GameInfo
							   {
								   Id = d.DiscountId,
								   Name = d.Game.Name,
								   Description = d.Game.Description,
								   Price = d.Game.Price,
								   Developer = d.Game.Developer.Name,
								   GameImage = d.Game.Image,
								   // GameTag = d.Game.GameTag.Tag.Name,
								   MaxPercent = d.Game.MaxPercent,

							   }).ToList();

			entity.Game = gameInfo;



			return entity;
		}

		public static DiscountItemDto EntityToDto(this DiscountItemEntity entity)
		{
			var listvm = new DiscountItemDto
			{
				Id = entity.Id,
				DiscountImage = entity.DiscountImage,
				DiscountName = entity.DiscountName,
				StartDate = entity.StartDate,
				EndDate = entity.EndDate,
				Game = entity.Game,
				Persent = entity.Persent,
				Description = entity.Description
			};

			return listvm;
		}

		public static DiscountEditVm DtoToIndexVm(this DiscountItemDto dtos)
		{
			var listvm = new DiscountEditVm
			{
				Id = dtos.Id,
				DiscountImage = dtos.DiscountImage,
				DiscountName = dtos.DiscountName,
				StartDate = dtos.StartDate,
				EndDate = dtos.EndDate,
				Game = dtos.Game,
				Persent = dtos.Persent,
				Description = dtos.Description
			};

			return listvm;
		}
	}
}