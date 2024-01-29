using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
    public interface IBonusProductsRepository
    {
        void Create(BonusProductsEntity entity);
        BonusProductsEntity SearchByName(string bonusName);
        BonusProductsEntity SearchById(int id);
        void Update(BonusProductsEntity entity);
        void Delete(BonusProductsEntity entity);
        List<BonusProductsEntity> GetAll();
    }
}
