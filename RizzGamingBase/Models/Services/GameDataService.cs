using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.Entity;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Interfaces;
using RizzGamingBase.Models.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace RizzGamingBase.Models.Services
{
	public class GameDataService : ISelectListService
	{
		private IGameDataRepository _repository;

		public GameDataService(IGameDataRepository repository) //傳入interface
		{
			_repository = repository;
		}

		public List<decimal> SearchGameName(string name,int Year)
		{
			string gameName = name;
			int year =Year;
			if (string.IsNullOrEmpty(gameName))
			{
				//todo
				gameName = "遊戲1";
			}


			List<GameDataEntity> entity = _repository.SearchGameNameToBI(gameName);

			var initialdto = GameDataExts.EntityToDto(entity);


			decimal s1=0,s2=0,s3=0,s4=0;
			foreach (var item in initialdto)
			{
				if (item.TransactionDate > new DateTime((year-1), 12, 31) && item.TransactionDate < new DateTime(year, 04, 01))
				{
					s1 += item.Price;
				}
				else if (item.TransactionDate > new DateTime(year, 03, 31) && item.TransactionDate < new DateTime(year, 07, 01))
				{
					s2 += item.Price;
				}
				else if (item.TransactionDate > new DateTime(year, 06, 30) && item.TransactionDate < new DateTime(year, 10, 01))
				{
					s3 += item.Price;
				}
				else if (item.TransactionDate > new DateTime(year, 09, 30) && item.TransactionDate < new DateTime((year + 1), 1, 01))
				{
					s4 += item.Price;
				}
				
			}

			List<decimal> dto = new List<decimal> {s1,s2,s3,s4};

			return dto;
		}


		public List<GameDataDto> SearchGames(int id)
		{
			List<GameDataEntity> entity = _repository.SearchDeveloperIdToGame(id);

			var initialdto = GameDataExts.EntityToDto(entity);




			return initialdto;
		}

		public List<GameDataDto> SearchDevelopers()
		{
			List<GameDataEntity> entity = _repository.SearchAllDevelopersGames();


			var initialdto = GameDataExts.EntityToDto(entity);



			//相同開發商資料合併
			Dictionary<string, decimal> mergedValues = new Dictionary<string, decimal>();

			foreach (GameDataDto dto in initialdto)
			{
				if (mergedValues.ContainsKey(dto.GameName))
				{
					mergedValues[dto.GameName] += dto.Price;
				}
				else
				{
					mergedValues[dto.GameName] = dto.Price;
				}
			}

			// 將字典轉換回 List<Entity>
			List<GameDataDto> dtos = mergedValues.Select(kv => new GameDataDto { GameName = kv.Key, Price = kv.Value }).ToList();



			return dtos;
		}

		//
		public IEnumerable<ISelectListItem> GetSelectListItems()
		{
			return _repository.SearchAllDeveloper();
		}

		public IEnumerable<ISelectListItem> GetSelectListItemsDeveloper(int id)
		{
			return _repository.SearchAllDevelopersGame(id);
		}
	}
}