using RizzGameBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGameBase.Models.IRepositories
{
	internal interface IGameRepository
	{
		//Create
		void Create(GameEntity entity);
		//Read GetAll, Search, ByDeveloper, ByTag

		GameEntity Search(int id);

		List<GameEntity> FilterGames(Func<EFModels.Game, bool> filterCondition = null);

		List<GameEntity> ByDeveloper(int DeveloperId);

		List<GameEntity> ByTag(int GameTagId);

		List<GameEntity> ByDiscount(int DiscountId);

		//Update
		void Update(GameEntity entity);
		//Delete
		void Delete(int id);
	}
}
