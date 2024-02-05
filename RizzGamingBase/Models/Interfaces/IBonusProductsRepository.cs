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
        List<BonusProductsEntity> GetAll();
        BonusProductsEntity SearchById(int id);
        void Edit(BonusProductsEntity entity);
        void Delete(BonusProductsEntity entity);
    }
}
