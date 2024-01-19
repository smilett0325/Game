using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGameBase.Models.IServices
{
	public interface IGameService
	{
		List<GameEntity> Filter(Func<Game, bool> condition = null);

		List<GameEntity> FilterByDeveloper(int developerId);

		List<GameEntity> FilterByDiscount(int discountId);

		List<GameEntity> FilterByTag(int tagId);

	}
}
