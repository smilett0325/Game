using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGameBase.Models.IRepositories
{
	public interface IGameRepository
	{
		void Create(GameEntity entity);

		GameEntity Search(int id);

		List<GameEntity> Filter(Func<Game, bool> condition = null);

		void Update(GameEntity entity);
		
		void Delete(int id);
	}
}
