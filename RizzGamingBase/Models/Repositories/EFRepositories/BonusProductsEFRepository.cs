using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RizzGamingBase.Models.Dtos;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
    public class BonusProductsEFRepository : IBonusProductsRepository
    {
        private readonly AppDbContext db;
        public BonusProductsEFRepository(AppDbContext context)
        {
            db = context;
        }

        public void Create(BonusProductsEntity model)
        {
            BonusProduct entity = new BonusProduct
            {
                Id = model.Id,
                ProductTypeId = model.ProductTypeId,
                Price = model.Price,
                URL = model.URL,
                Name = model.Name
            };

            db.BonusProducts.Add(entity);
            db.SaveChanges();
        }

        public List<BonusProductsEntity> GetAll()
        {
            var BonusProducts = db.BonusProducts.AsNoTracking()
                .Include(bp => bp.BonusProductType)
                .Select(bp => new BonusProductsEntity
                {
                    Id = bp.Id,
                    ProductTypeId = bp.BonusProductType.Id,
                    ProductTypeName = bp.BonusProductType.Name,
                    Price = bp.Price,
                    URL = bp.URL,
                    Name = bp.Name
                })
                .ToList();
            return BonusProducts;
        }

        public List<BonusProductsEntity> SearchByName(string keyword)
        {
            throw new NotImplementedException();
        }

        // todo 完成3層式，編輯Repository
        public void Edit(BonusProductsEntity entity)
        {
            //var db = new AppDbContext();

            //var BonusProduct = db.BonusProducts.Find(entity.Id);
            //BonusProduct.ProductTypeId = entity.ProductTypeId;
            //BonusProduct.Price = entity.Price;
            //BonusProduct.URL = entity.URL;
            //BonusProduct.Name = entity.Name;
            //db.SaveChanges();
        }

        // todo 關鍵字搜尋
        public BonusProductsEntity SearchById(int id)
        {
            //var db = new AppDbContext();
            var model = db.BonusProducts.Find(id);
            var data = new BonusProductsEntity
            {
                Id = model.Id,
                ProductTypeId = model.ProductTypeId,
                Price = model.Price,
                URL = model.URL,
                Name = model.Name
            };
            return data;
        }


        // todo 完成3層式，刪除Repository
        public void Delete(BonusProductsEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}