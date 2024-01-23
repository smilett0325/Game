using RizzGameBase.Models.Dtos;
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
		List<GameDto> Filter(Func<Game, bool> condition = null);

		List<GameDto> FilterByDeveloper(int developerId);

		List<GameDto> FilterByDiscount(int discountId);

		List<GameDto> FilterByTag(int tagId);

	}
}
