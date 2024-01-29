using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entity;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RizzGamingBase.Models.Exts
{
	public static class GameDataExts
	{
		public static List<GameDataDto> EntityToDto (this List<GameDataEntity> entity)
		{
			var dto = new List<GameDataDto>();

			foreach (var item in entity) 
			{ 
				var dtoItem = new GameDataDto
				{
					Id = item.Id,
					GameName = item.GameName,
					TransactionDate = item.TransactionDate,
					Price = item.Amount
				};
				dto.Add(dtoItem);
			}
			return dto;
		}

		public static List<GameDataVm> DtoToIndexVm(this List<GameDataDto> dtos)
		{
			var listvm = new List<GameDataVm>();

			foreach (var dto in dtos)
			{
				var vm = new GameDataVm
				{
					Id = dto.Id,
					GameName = dto.GameName,
					TransactionDate = dto.TransactionDate,
					Amount = dto.Price
				};
				listvm.Add(vm);
			}

			return listvm;
		}

	}
}