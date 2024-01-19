using RizzGameBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGameBase.Models.Exts
{
	public static class GameExts
	{
		public static GameEntity EFToEntity(this EFModels.Game model)
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
	}
}