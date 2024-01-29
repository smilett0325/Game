using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Exts
{
	public static class VideoExts
	{
		public static VideoEntity EFToEntity(this Video model)
		{
			return new VideoEntity
			{
				Id = model.Id,
				GameId = model.GameId,
				DisplayVideo = model.DisplayVideo
			};
		}

		public static Video EntityToEF(this VideoEntity model)
		{
			return new Video
			{
				Id = model.Id,
				DisplayVideo = model.DisplayVideo,
				GameId = model.GameId
			};
		}

		public static VideoDto EntityToDto(this VideoEntity model)
		{
			return new VideoDto
			{
				Id = model.Id,
				DisplayVideo = model.DisplayVideo,
				GameId = model.GameId
			};
		}

		public static VideoEntity DtoToEntity(this VideoDto model)
		{
			return new VideoEntity
			{
				Id = model.Id,
				DisplayVideo = model.DisplayVideo,
				GameId = model.GameId
			};
		}
	}
}