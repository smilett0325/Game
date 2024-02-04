using RizzGamingBase.Models.Entities;
using System.Collections.Generic;

namespace RizzGamingBase.Controllers
{
    public interface IGameDataRepository
    {
        List<GameDataEntity> SearchGameNameToBI(string name);


        int SearchGameNameToId(string name);
        List<GameDataEntity> SearchDeveloperIdToGame(int id);

        List<GameDataEntity> SearchDeveloperIdToGameNoGroup(int id);

        List<GameDataEntity> SearchAllDevelopersGames();

        List<GameDataEntity> SearchAllGamesBi();

        IEnumerable<GameDataEntity> SearchAllDeveloper();

        IEnumerable<GameDataEntity> SearchAllDevelopersGame(int id);

        List<GameDataEntity> SearchDeveloperGamesBi(int id);

        List<GameDataEntity> SearchNoDeveloperGamesBi();
    }
}