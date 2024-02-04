using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Repositories.EFRepositories;
using RizzGamingBase.Models.Services;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RizzGamingBase.Models.Exts
{
    public static class BonusProductExts
    {
        public static List<BonusProductsIndexVm> GetAll(AppDbContext context, string keyword = null)
        {
            var repo = new BonusProductsEFRepository(context);
            var service = new BonusProductsServices(repo);
            var dto = service.GetAll();

            if (!string.IsNullOrEmpty(keyword))
            {
                // 如果有關鍵字，則根據關鍵字進行篩選
                dto = dto.Where(bp => bp.Name.Contains(keyword)).ToList();
            }

            var data = new List<BonusProductsIndexVm>();
            foreach (var item in dto)
            {
                var model = new BonusProductsIndexVm
                {
                    Id = item.Id,
                    ProductTypeId = item.ProductTypeId,
                    ProductTypeName = item.ProductTypeName,
                    Price = item.Price,
                    URL = item.URL,
                    Name = item.Name
                };
                data.Add(model);
            }
            return data;
        }

        public static void CreateProduct(this BonusProductsCreateVm model, AppDbContext context)
        {
            var repo = new BonusProductsEFRepository(context);
            var service = new BonusProductsServices(repo);

            BonusProductsDto dto = new BonusProductsDto
            {
                Id = model.Id,
                ProductTypeId = model.ProductTypeId,
                Price = model.Price,
                URL = model.URL,
                Name = model.Name
            };
            service.Create(dto);
        }

        public static void Edit(this BonusProductsVm model, AppDbContext context)
        {
            var repo = new BonusProductsEFRepository(context);
        }
    }
}