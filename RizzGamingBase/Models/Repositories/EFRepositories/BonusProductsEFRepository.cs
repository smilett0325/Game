using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
    public class BonusProductsEFRepository : IBonusProductsRepository
    {
        public void Create(BonusProductsEntity model)
        {
            var db = new AppDbContext();

            BonusProduct entity = new BonusProduct
            {
                Id = model.Id,
                ProductTypeId = model.ProductTypeid,
                Price = model.Price,
                URL = model.URL,
                Name = model.Name
            };

            db.BonusProducts.Add(entity);
            db.SaveChanges();
        }

        public void Delete(BonusProductsEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Search(BonusProductsEntity entity)
        {
            var db = new AppDbContext();

            var BonusProducts = db.BonusProducts.AsNoTracking()
            .Include(bp => bp.BonusProductType)
            .Select(bp => new BonusProductsEntity
            {
                Id = bp.Id,
                ProductTypeid = bp.BonusProductType.Type,
                Price = bp.Price,
                URL = bp.URL,
                Name = bp.Name
            })
            .ToList();
            return;
        }

        public List<BonusProductsEntity> GetAll()
        {
            var db = new AppDbContext();

            var BonusProducts = db.BonusProducts.AsNoTracking()
                .Include(bp => bp.BonusProductType)
                .Select(bp => new BonusProductsEntity
                {
                    Id = bp.Id,
                    ProductTypeid = bp.BonusProductType.Type,
                    TypeName = bp.BonusProductType.Name,
                    Price = bp.Price,
                    URL = bp.URL,
                    Name = bp.Name
                })
                .ToList();
            return BonusProducts;
        }

        public void Update(BonusProductsEntity entity)
        {
            var db = new AppDbContext();

            var BonusProduct = db.BonusProducts.Find(entity.Id);


        }

        public BonusProductsEntity SearchByName(string bonusName)
        {
            throw new NotImplementedException();
        }

        public BonusProductsEntity SearchById(int id)
        {
            var db = new AppDbContext();
            var model = db.BonusProducts.Find(id);
            var data = new BonusProductsEntity
            {
                Id = model.Id,
                ProductTypeid = model.ProductTypeId,
                Price = model.Price,
                URL = model.URL,
                Name = model.Name
            };
            return data;
        }
    }
}