using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using RizzGameBase.Models.IRepositories;
using RizzGameBase.Models.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGameBase.Models.Services
{
	public class GameService : IGameService
	{
		private IGameRepository _repo;

		public GameService(IGameRepository repo)
		{
			_repo = repo;
		}

		public List<GameEntity> Filter(Func<Game, bool> condition = null)
		{
			return _repo.Filter(condition);
		}

		public List<GameEntity> FilterByDeveloper(int developerId)
		{
			return _repo.Filter(g => g.DeveloperId == developerId);
		}

		public List<GameEntity> FilterByDiscount(int discountId)
		{
			return _repo.Filter(g => g.DiscountId == discountId);
		}

		public List<GameEntity> FilterByTag(int tagId)
		{
			return _repo.Filter(g => g.GameTagId == tagId);
		}
	}
}