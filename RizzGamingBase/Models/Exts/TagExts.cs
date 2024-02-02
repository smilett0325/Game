using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Exts
{
	public static class TagExts
	{
		public static TagEntity EFToEntity(this Tag model)
		{
			return new TagEntity
			{
				Id = model.Id,
				Name = model.Name,
			};
		}

		public static Tag EntityToEF(this TagEntity model)
		{
			return new Tag
			{
				Id = model.Id,
				Name = model.Name,
			};
		}

		public static TagDto EntityToDto(this TagEntity model)
		{
			return new TagDto
			{
				Id = model.Id,
				Name = model.Name,
			};
		}

		public static TagEntity DtoToEntity(this TagDto model)
		{
			return new TagEntity
			{
				Id = model.Id,
				Name = model.Name,

			};
		}
	}
}