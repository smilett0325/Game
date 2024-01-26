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
	public class GTService : IGTService
	{
		private IGTRepository _repo;

		public GTService(IGTRepository repo)
		{
			_repo = repo;
		}

		public List<GTEntity> Filter(Func<GameTag, bool> condition = null)
		{
			return _repo.Filter(condition);
		}

		public List<GTEntity> FilterByGame(int gameId)
		{
			return _repo.Filter(g => g.Id == gameId);
		}

		public List<GTEntity> FilterByTag(int tagId)
		{
			return _repo.Filter(t => t.Id == tagId);
		}
	}
}