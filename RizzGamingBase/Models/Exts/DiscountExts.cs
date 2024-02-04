using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Helpers;
using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.ViewModels;

namespace RizzGamingBase.Models.Exts
{
    public static class DiscountExts
    {
        public static List<DiscountCreateEntity> GetDbToEntity()
        {
            var db = new AppDbContext();

            var entities = db.Discounts.AsNoTracking()
               .Select(d => new DiscountCreateEntity
               {
                   Id = d.Id,
                   Name = d.Name,
                   Type = d.DiscountType,
                   Image = d.Image,
                   StartDate = d.StartDate,
                   EndDate = d.EndDate,
                   Percent = d.Percent,
                   Desciption = d.Desciption,
               })
               .ToList();

            return entities;
        }

        public static List<DiscountCreateDto> GetEntityToDto(this List<DiscountCreateEntity> entity)
        {
            var listvm = new List<DiscountCreateDto>();

            foreach (var e in entity)
            {
                var vm = new DiscountCreateDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = e.Type,
                    Image = e.Image,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Percent = e.Percent,
                    Desciption = e.Desciption,
                };
                listvm.Add(vm);
            }

            return listvm;
        }

        public static List<DiscountIndexVm> GetDtoToVm(this List<DiscountCreateDto> dtos)
        {
            var listvm = new List<DiscountIndexVm>();

            foreach (var dto in dtos)
            {
                var vm = new DiscountIndexVm
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Type = dto.Type,
                    Image = dto.Image,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    Percent = dto.Percent,
                    Desciption = dto.Desciption,
                };
                listvm.Add(vm);
            }

            return listvm;
        }

        public static DiscountCreateEntity GetDbToEntity(int id)
        {
            var db = new AppDbContext();

            var discount = db.Discounts.FirstOrDefault(x => x.Id == id);

            var entity = new DiscountCreateEntity
            {
                Id = discount.Id,
                Name = discount.Name,
                Type = discount.DiscountType,
                Image = discount.Image,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                Percent = discount.Percent,
                Desciption = discount.Desciption,
            };


            return entity;
        }

        public static DiscountCreateDto GetEntityToDto(this DiscountCreateEntity entity)
        {
            var dto = new DiscountCreateDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                Image = entity.Image,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Percent = entity.Percent,
                Desciption = entity.Desciption,

            };
            return dto;
        }

        public static DiscountCreateVm GetDtoToVm(this DiscountCreateDto dto)
        {
            var vm = new DiscountCreateVm
            {
                Id = dto.Id,
                DiscountName = dto.Name,
                DiscountType = dto.Type,
                DiscountImage = dto.Image,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Percent = dto.Percent,
                Description = dto.Desciption,

            };

            return vm;
        }



        public static DiscountCreateDto CreateVmToDto(this DiscountCreateVm vm)
        {
            var dto = new DiscountCreateDto
            {
                Name = vm.DiscountName,
                Type = vm.DiscountType,
                Image = vm.DiscountImage,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Percent = vm.Percent,
                Desciption = vm.Description,
                GameId = vm.Game
            };

            return dto;
        }
        public static DiscountCreateDto EditVmToDto(this DiscountCreateVm vm)
        {
            var dto = new DiscountCreateDto
            {
                Id = vm.Id,
                Name = vm.DiscountName,
                Type = vm.DiscountType,
                Image = vm.DiscountImage,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Percent = vm.Percent,
                Desciption = vm.Description,
                GameId = vm.Game
            };

            return dto;
        }

        public static DiscountCreateEntity CreateDtoToEntity(this DiscountCreateDto vm)
        {
            var entity = new DiscountCreateEntity
            {
                Name = vm.Name,
                Type = vm.Type,
                Image = vm.Image,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Percent = vm.Percent,
                Desciption = vm.Desciption,
                GameId = vm.GameId
            };

            return entity;
        }

        public static DiscountCreateEntity EditDtoToEntity(this DiscountCreateDto vm)
        {
            var entity = new DiscountCreateEntity
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Image = vm.Image,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Percent = vm.Percent,
                Desciption = vm.Desciption,
                GameId = vm.GameId
            };

            return entity;
        }

        public static void CreateEntityToDb(this DiscountCreateEntity entity)
        {
            var db = new AppDbContext();

            var discount = new Discount
            {
                Name = entity.Name,
                DiscountType = entity.Type,
                Image = entity.Image,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Percent = entity.Percent,
                Desciption = entity.Desciption,
            };
            db.Discounts.Add(discount);
            db.SaveChanges();


            string[] gameIdArray = entity.GameId.Trim('[', ']')
                                   .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in gameIdArray)
            {
                if (int.TryParse(item, out int gameId))
                {
                    var discountItem = new DiscountItem
                    {
                        DiscountId = discount.Id,
                        GameId = gameId
                    };
                    db.DiscountItems.Add(discountItem);
                    db.SaveChanges();
                }
            }
        }

        public static void EditEntityToDb(this DiscountCreateEntity entity)
        {
            using (var db = new AppDbContext())
            {
                var discount = db.Discounts.SingleOrDefault(d => d.Id == entity.Id);

                if (discount != null)
                {

                    discount.Name = entity.Name;
                    discount.DiscountType = entity.Type;
                    discount.Image = entity.Image;
                    discount.StartDate = entity.StartDate;
                    discount.EndDate = entity.EndDate;
                    discount.Percent = entity.Percent;
                    discount.Desciption = entity.Desciption;
                    db.SaveChanges();
                }

                string[] gameIdArray = entity.GameId.Trim('[', ']')
                              .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // 獲取資料庫中舊的 DiscountItems
                var oldDiscountItems = db.DiscountItems.Where(d => d.DiscountId == entity.Id).ToList();

                // 遍歷現有的 gameIdArray
                foreach (var item in gameIdArray)
                {
                    if (int.TryParse(item, out int gameId))
                    {
                        var discountItem = oldDiscountItems.SingleOrDefault(d => d.GameId == gameId);

                        if (discountItem != null)
                        {
                            // 如果在現有的 gameIdArray 中找到，更新相應的資料
                            discountItem.GameId = gameId;
                        }
                        else
                        {
                            // 如果在現有的 gameIdArray 中未找到，則新建 DiscountItem
                            var newItem = new DiscountItem
                            {
                                DiscountId = entity.Id,
                                GameId = gameId
                            };
                            db.DiscountItems.Add(newItem);
                        }
                    }
                }

                // 檢查是否有需要刪除的項目
                foreach (var oldItem in oldDiscountItems)
                {
                    if (!gameIdArray.Contains(oldItem.GameId.ToString()))
                    {
                        // 如果在現有的 gameIdArray 中未找到，則從資料庫中刪除
                        db.DiscountItems.Remove(oldItem);
                    }
                }

                // 提交變更到資料庫
                db.SaveChanges();
            }
        }
    }
}
