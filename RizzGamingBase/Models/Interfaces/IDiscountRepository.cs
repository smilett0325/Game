using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
    public interface IDiscountRepository
    {
        List<DiscountEntity> GetAllEvent();
        DiscountEntity GetEvent(int id);
        void Create(DiscountCreateEntity entity);
        void Edit(DiscountEntity entity);
        
    }
}
