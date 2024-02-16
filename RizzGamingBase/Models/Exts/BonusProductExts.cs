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
using RizzGamingBase.Models.Infra;

namespace RizzGamingBase.Models.Exts
{
    public static class BonusProductExts
    {
        public static List<BonusProductsIndexVm> GetAll(AppDbContext context, string keyword = null)
        {
            var repo = new BonusProductsEFRepository(context);
            var service = new BonusProductsService(repo);
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

        public static void CreateProduct(this BonusProductsCreateVm model, AppDbContext context, HttpPostedFileBase URL)
        {
            var repo = new BonusProductsEFRepository(context);
            var service = new BonusProductsService(repo);

            BonusProductsDto dto = new BonusProductsDto
            {
                Id = model.Id,
                ProductTypeId = model.ProductTypeId,
                Price = model.Price,
                URL = URL.FileName,
                Name = model.Name
            };
            service.Create(dto);

            UploadFileHelper uploadFileHelper = new UploadFileHelper();
            string[] allowExts = { ".jpg", ".jpeg", ".png", ".gif" };

            uploadFileHelper.UploadFile(URL, "BonusProducts", model.ProductTypeId, allowExts);
        }

        // todo 完成三層式編輯
        #region 三層式編輯
        public static BonusProductsEditVm LoadProdct(this AppDbContext db, int id)//找到編輯欄位
        {
            //using (var db = new AppDbContext());//using會在連線字串完後自然釋放比上面更省效能也不用擔心資料外洩
            var model = db.BonusProducts.Find(id);
            if (model == null)
            {
                throw new InvalidOperationException("未取得產品");
            }

            return new BonusProductsEditVm
            {
                Id = model.Id,
                ProductTypeId = model.ProductTypeId,
                ProductTypeName = model.BonusProductType.Name,
                Price = model.Price,
                URL = model.URL,
                Name = model.Name
            };
        }

        public static void UpdateProduct(this AppDbContext db, BonusProductsEditVm model, HttpPostedFileBase URL)//修改
        {
            var findProduct = db.BonusProducts.Find(model.Id);
            var uploadFileHelper = new UploadFileHelper();

            if (findProduct == null)
            {
                throw new InvalidOperationException("未取得產品");
            }

            string[] imgAllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            if (URL != null)
            {
                uploadFileHelper.DeleteFile("BonusProducts", findProduct.ProductTypeId, findProduct.URL);
                uploadFileHelper.UploadFile(URL, "BonusProducts", model.ProductTypeId, imgAllowedExtensions);
            }
            findProduct.ProductTypeId = model.ProductTypeId;
            findProduct.Price = model.Price;
            findProduct.URL = URL != null ? URL.FileName : findProduct.URL;
            findProduct.Name = model.Name;

            db.SaveChanges();
        }
        #endregion
    }
}