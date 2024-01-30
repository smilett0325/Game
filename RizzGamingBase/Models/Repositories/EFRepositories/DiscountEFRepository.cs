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
        public DiscountEntity GetEvent(int id)
        {
           return DiscountExts.GetDbToEntity(id);
        }

        public List<DiscountEntity> GetAllEvent()
        {

            return DiscountExts.GetDbToEntity();
        }

        public void Create(DiscountEntity entity)
        {
            DiscountExts.EntityToDb(entity);
        }

        public void Edit(DiscountEntity entity)
        {
            DiscountExts.EditEntityToDb(entity);
        }
    }
}