using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.Entity;

namespace RizzGamingBase.Models.InterFaces
{
	public interface IGameDataRepository
	{
		List<GameDataEntity> SearchGameNameToBI(string name);

		
		int SearchGameNameToId(string name);
		List<GameDataEntity> SearchDeveloperIdToGame(int id);


	}
}
