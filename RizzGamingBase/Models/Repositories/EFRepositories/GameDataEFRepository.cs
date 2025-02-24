﻿using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace RizzGamingBase.Controllers
{
    public class GameDataEFRepository : IGameDataRepository
    {
        public List<GameDataEntity> SearchGameNameToBI(string name)
        {

            var db = new AppDbContext();

            var gameId = SearchGameNameToId(name);

            var queryList = SearchGameIdToBI(gameId, name);

            return queryList;
        }

        public int SearchGameNameToId(string name)
        {
            var db = new AppDbContext();

            var gameId = db.Games.AsNoTracking()
               //.Where(g => g.Name == name)
               //.Select(g => g.Id)
               //.First();
               .First(g => g.Name == name).Id;

            return gameId;
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

        public List<GameDataEntity> SearchDeveloperIdToGameNoGroup(int id)
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
            var queryList = SearchGameIdToBINoGroup(game);
            return queryList;
        }


        //
        public List<GameDataEntity> SearchAllDevelopersGames()
        {
            var db = new AppDbContext();

            var game = db.Games.AsNoTracking()
                .Select(g => new GameDataEntity
                {
                    Id = g.Id,
                    GameName = g.Name
                })
                .Distinct()
                .ToList();
            var queryList = SearchAllDeveloperGamesToBI(game);
            return queryList;
        }

        public List<GameDataEntity> SearchAllGamesBi()
        {
            var db = new AppDbContext();

            var game = db.Games.AsNoTracking()
                  .Select(g => new GameDataEntity
                  {
                      Id = g.Id,
                      GameName = g.Name
                  })
                 .Distinct()
                 .ToList();
            var queryList = SearchGameIdToBINoGroup(game);
            return queryList;
        }

        public List<GameDataEntity> SearchNoDeveloperGamesBi()
        {
            var db = new AppDbContext();

            var game = db.Games.AsNoTracking()
                            .Select(g => new GameDataEntity
                            {
                                Id = g.Id,
                                GameName = g.Name
                            })
                            .Distinct()
                            .ToList();
            var queryList = SearchGameIdToBINoGroup(game);
            return queryList;
        }
        public List<GameDataEntity> SearchDeveloperGamesBi(int id)
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
            var queryList = SearchGameIdToBINoGroup(game);
            return queryList;
        }

		public int SearchDeveloperAccountToDeveloperId(string account)
		{
			var db = new AppDbContext();

			var developerId = db.Developers.AsNoTracking()
				.Where(d => d.Account == account)
				.Select(d => d.Id)
				.First();

            return developerId;
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
                                            Amount = group.Sum(bi => bi.Price)
                                        });

                queryList.AddRange(query);
            }

            return queryList;
        }

        private List<GameDataEntity> SearchGameIdToBINoGroup(List<GameDataEntity> game)
        {
            var db = new AppDbContext();

            var queryList = new List<GameDataEntity>();

            foreach (var item in game)
            {
                var query = db.BillItems.AsNoTracking()
                                        .Include(bi => bi.BillDetail)
                                        .Include(bi => bi.Game)
                                        .Where(bi => bi.GameId == item.Id)
                                        .Select(bi => new GameDataEntity
                                        {
                                            Id = bi.Id,
                                            GameName = bi.Game.Name,
                                            TransactionDate = bi.BillDetail.TransactionDate,
                                            Amount = bi.Price
                                        });

                queryList.AddRange(query);
            }

            return queryList;
        }

        private List<GameDataEntity> SearchAllDeveloperGamesToBI(List<GameDataEntity> game)
        {
            var db = new AppDbContext();

            var queryList = new List<GameDataEntity>();

            foreach (var item in game)
            {
                var query = db.BillItems.AsNoTracking()
                                        .Include(bi => bi.BillDetail)
                                        .Include(bi => bi.Game)
                                        .Include(bi => bi.Game.Developer)
                                        .Where(bi => bi.GameId == item.Id)
                                        .OrderBy(bi => bi.Game.Developer.Name) // 按 DeveloperName 排序
                                        .GroupBy(bi => bi.Game.Developer.Name) // 按 DeveloperName 分組
                                        .ToList()
                                        .Select(group => new GameDataEntity
                                        {
                                            GameName = group.Key,
                                            Amount = group.Sum(bi => bi.Price)
                                        });

                queryList.AddRange(query);
            }

            return queryList;
        }

        public IEnumerable<GameDataEntity> SearchAllDeveloper()
        {
            var db = new AppDbContext();
            return db.Developers
                .Select(d => new GameDataEntity
                {
                    Id = d.Id,
                    DeveloperName = d.Name
                })
                .ToList();
        }

        public IEnumerable<GameDataEntity> SearchAllDevelopersGame(int id)
        {
            var db = new AppDbContext();
            return db.Games
                .Include(bi => bi.Developer)
                .Where(g => g.DeveloperId == id)
                .Select(d => new GameDataEntity
                {
                    Id = d.Id,
                    GameName = d.Name
                })
                .ToList();
        }


	}
}