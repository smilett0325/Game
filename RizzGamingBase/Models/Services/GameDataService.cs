using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.Entity;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RizzGamingBase.Models.Services
{
	public class GameDataService
	{
		private IGameDataRepository _repository;

		public GameDataService(IGameDataRepository repository) //傳入interface
		{
			_repository = repository;
		}

		public List<decimal> SearchGameName(string name)
		{
			string gameName = name;
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
				if (item.TransactionDate > new DateTime(2022, 12, 31) && item.TransactionDate < new DateTime(2023, 04, 01))
				{
					s1 += item.Price;
				}
				else if (item.TransactionDate > new DateTime(2023, 03, 31) && item.TransactionDate < new DateTime(2023, 07, 01))
				{
					s2 += item.Price;
				}
				else if (item.TransactionDate > new DateTime(2023, 06, 30) && item.TransactionDate < new DateTime(2023, 10, 01))
				{
					s3 += item.Price;
				}
				else if (item.TransactionDate > new DateTime(2023, 09, 30) && item.TransactionDate < new DateTime(2024, 1, 01))
				{
					s4 += item.Price;
				}
				
			}

			List<decimal> dto = new List<decimal> {s1,s2,s3,s4};

			return dto;
		}
	}
}