using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entity;
using RizzGamingBase.Models.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Xml.Linq;
using System.Diagnostics;

namespace RizzGamingBase.Models.Repositories
{
	public class GameDataEFRepository : IGameDataRepository
	{
		public List<GameDataEntity> SearchGameNameToBI(string name)
		{

				var db = new AppDbContext();

			    var gameId = SearchGameNameToId(name);

			    var queryList = SearchGameIdToBI(gameId,name);

			    return queryList;
		}

		public int SearchGameNameToId(string name)
		{
			var db = new AppDbContext();

			var gameId = db.Games.AsNoTracking()
			   //.Where(g => g.Name == name)
			   //.Select(g => g.Id)
			   //.First();
			   .First(g=>g.Name==name).Id;

			return gameId ;
		}

		public List<GameDataEntity> SearchDeveloperIdToGame(int id)
		{
			var db = new AppDbContext();

			var game = db.Games.AsNoTracking()
				.Where(g => g.DeveloperId == id)
				.Select(g => new GameDataEntity
				{
					Id = g.Id,
					GameName = g.Name
				})
				.Distinct()
				.ToList();
			var queryList = SearchGameIdToBI(game);
			return queryList;
		}

		private List<GameDataEntity> SearchGameIdToBI(int gameId, string name = "")
		{
			var db = new AppDbContext();

			var query = db.BillItems.AsNoTracking()
						.Include(bi => bi.BillDetail)
						.Include(bi => bi.Game)
						.Where(bi => bi.GameId == gameId)
						.Select(bi => new GameDataEntity
						{
							Id = bi.Id,
							GameName = bi.Game.Name,
							TransactionDate = bi.BillDetail.TransactionDate,
							Amount = bi.Price
						});
			if (!string.IsNullOrWhiteSpace(name))
			{
				query = query.Where(bi => bi.GameName.Contains(name));
			}

			return query.ToList();
		}

		private List<GameDataEntity> SearchGameIdToBI(List<GameDataEntity> game)
		{
			var db = new AppDbContext();

			var queryList = new List<GameDataEntity>();

			foreach (var item in game)
			{
				var query = db.BillItems.AsNoTracking()
			                            .Include(bi => bi.BillDetail)
			                            .Include(bi => bi.Game)
			                            .Where(bi => bi.GameId == item.Id)
										.OrderBy(bi => bi.Game.Name) // 按 GameName 排序
				                        .GroupBy(bi => bi.Game.Name) // 按 GameName 分組
										.Select(group => new GameDataEntity
			                 {
											GameName = group.Key,
				                            Amount = group.Sum(bi=>bi.Price)
			                  });

				queryList.AddRange(query);
			}

			return queryList;
		}
	}
}