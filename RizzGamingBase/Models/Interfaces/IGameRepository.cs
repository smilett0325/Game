using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
	public interface IGameRepository
	{
		int Create(GameEntity entity);

		GameEntity Search(int id);

		List<GameEntity> Filter(Func<Game, bool> condition = null);

		void Update(GameEntity entity);

		void Delete(int id);
	}
}
