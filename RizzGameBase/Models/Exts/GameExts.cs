using RizzGameBase.Models.Dtos;
using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using RizzGameBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGameBase.Models.Exts
{
	public static class GameExts
	{
		public static GameEntity EFToEntity(this Game model)
		{
			return new GameEntity
			{
				Id = model.Id,
				Name = model.Name,
				Introduction = model.Introduction,
				Description = model.Description,
				ReleaseDate = model.ReleaseDate,
				Price = model.Price,
				Image = model.Image,
				DeveloperId = model.DeveloperId,
				GameTagId = model.GameTagId,
				DiscountId = model.DiscountId,
				MaxPersent = model.MaxPersent,
			};
		}

		public static Game EntityToEF(this GameEntity model)
		{
			return new Game
			{
				Id = model.Id,
				Name = model.Name,
				Introduction = model.Introduction,
				Description = model.Description,
				ReleaseDate = model.ReleaseDate,
				Price = model.Price,
				Image = model.Image,
				DeveloperId = model.DeveloperId,
				GameTagId = model.GameTagId,
				DiscountId = model.DiscountId,
				MaxPersent = model.MaxPersent,
			};
		}

		public static GameDto EntityToDto(this GameEntity model)
		{
			return new GameDto
			{
				Id = model.Id,
				Name = model.Name,
				Introduction = model.Introduction,
				Description = model.Description,
				ReleaseDate = model.ReleaseDate,
				Price = model.Price,
				Image = model.Image,
				DeveloperId = model.DeveloperId,
				GameTagId = model.GameTagId,
				DiscountId = model.DiscountId,
				MaxPersent = model.MaxPersent,
			};
		}

        public static List<GameDto> EntityToDto(this List<GameEntity> model)
        {
			return model.Select(x => x.EntityToDto()).ToList();
			//return new GameDto
			//{
			//    Id = model.Id,
			//    Name = model.Name,
			//    Introduction = model.Introduction,
			//    Description = model.Description,
			//    ReleaseDate = model.ReleaseDate,
			//    Price = model.Price,
			//    Image = model.Image,
			//    DeveloperId = model.DeveloperId,
			//    GameTagId = model.GameTagId,
			//    DiscountId = model.DiscountId,
			//    MaxPersent = model.MaxPersent,
			//};
		}

        public static GameEntity DtoToEntity(this GameDto model)
		{
			return new GameEntity
			{
				Id = model.Id,
				Name = model.Name,
				Introduction = model.Introduction,
				Description = model.Description,
				ReleaseDate = model.ReleaseDate,
				Price = model.Price,
				Image = model.Image,
				DeveloperId = model.DeveloperId,
				GameTagId = model.GameTagId,
				DiscountId = model.DiscountId,
				MaxPersent = model.MaxPersent,
			};
		}

		public static GameIndexVm ToGameVm(this GameDto model)
		{
			return new GameIndexVm
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Image = model.Image,
			};
		}

		public static List<GameIndexVm> ToGameVm(this List<GameDto> model)
		{
			return model.Select(x => x.ToGameVm()).ToList();
		}
	}
}