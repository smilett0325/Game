using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGameBase.Models.IServices
{
	public interface IGTService
	{
		List<GTEntity> Filter(Func<GameTag, bool> condition = null);

		List<GTEntity> FilterByGame(int developerId);

		List<GTEntity> FilterByTag(int discountId);
	}
}
