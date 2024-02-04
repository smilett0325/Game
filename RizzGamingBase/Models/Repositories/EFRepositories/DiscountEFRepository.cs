using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
    public class DiscountEFRepository : IDiscountRepository
    {
        public DiscountCreateEntity GetEvent(int id)
        {
           return DiscountExts.GetDbToEntity(id);
        }

        public List<DiscountCreateEntity> GetAllEvent()
        {

            return DiscountExts.GetDbToEntity();
        }

        public void Create(DiscountCreateEntity entity)
        {
            DiscountExts.CreateEntityToDb(entity);
        }

        public void Edit(DiscountCreateEntity entity)
        {
            DiscountExts.EditEntityToDb(entity);
        }
    }
}