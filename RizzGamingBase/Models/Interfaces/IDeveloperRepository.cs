using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
    public interface IDeveloperRepository
    {
        void Create(DeveloperEntity entity);

        void Delete(int id);
        List<DeveloperEntity> GetAll();

        DeveloperEntity Search(string name);

        void Edit(DeveloperEntity entity);

        DeveloperEntity Get(int id);

        void Update(DeveloperEntity entity);


    }
}