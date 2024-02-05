using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Exts
{
	public static class ImageExts
	{
		public static ImageEntity EFToEntity(this Image model)
		{
			return new ImageEntity
			{
				Id = model.Id,
				GameId = model.GameId,
				DisplayImage = model.DisplayImage
			};
		}

		public static Image EntityToEF(this ImageEntity model)
		{
			return new Image
			{
				Id = model.Id,
				DisplayImage = model.DisplayImage,
				GameId = model.GameId
			};
		}

		public static ImageDto EntityToDto(this ImageEntity model)
		{
			return new ImageDto
			{
				Id = model.Id,
				DisplayImage = model.DisplayImage,
				GameId = model.GameId
			};
		}

		public static List<ImageDto> EntityToDto(this List<ImageEntity> model)
		{
			return model.Select(x => x.EntityToDto()).ToList();
		}

		public static ImageEntity DtoToEntity(this ImageDto model)
		{
			return new ImageEntity
			{
				Id = model.Id,
				DisplayImage = model.DisplayImage,
				GameId = model.GameId
			};
		}
	}
}