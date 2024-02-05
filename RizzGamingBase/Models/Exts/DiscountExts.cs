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

        public static DiscountVm GetDtoToVm(this DiscountCreateDto dto)
        {
            var vm = new DiscountVm
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



        public static DiscountCreateDto CreateVmToDto(this DiscountVm vm)
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
                GameId = vm.Game,
                DeveloperId = vm.DeveloperId,

            };

            return dto;
        }
        public static DiscountCreateDto EditVmToDto(this DiscountVm vm)
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

        public static DiscountCreateEntity CreateDtoToEntity(this DiscountCreateDto dto)
        {
            var entity = new DiscountCreateEntity
            {
                Name = dto.Name,
                Type = dto.Type,
                Image = dto.Image,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Percent = dto.Percent,
                Desciption = dto.Desciption,
                GameId = dto.GameId,
                DeveloperId = dto.DeveloperId

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
                DeveloperId = entity.DeveloperId
            };
            db.Discounts.Add(discount);
            db.SaveChanges();



            foreach (var item in entity.GameId)
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
                // 假设 entity.GameId 是一个字符串数组
                string[] gameIdStrings = entity.GameId;

                // 将字符串数组转换为整数数组
                int[] gameIds = gameIdStrings.Select(int.Parse).ToArray();

                // 獲取資料庫中舊的 DiscountItems
                var oldDiscountItems = db.DiscountItems.Where(d => d.DiscountId == entity.Id).ToList();

                // 遍历现有的 gameIds 数组
                foreach (var gameId in gameIds)
                {
                    var discountItem = oldDiscountItems.SingleOrDefault(d => d.GameId == gameId);

                    if (discountItem != null)
                    {
                        // 如果在现有的 gameIds 数组中找到，更新相应的数据
                        discountItem.GameId = gameId;
                    }
                    else
                    {
                        // 如果在现有的 gameIds 数组中未找到，新建 DiscountItem
                        var newItem = new DiscountItem
                        {
                            DiscountId = entity.Id,
                            GameId = gameId
                        };
                        db.DiscountItems.Add(newItem);
                    }
                }

                // 检查是否有需要删除的项目
                foreach (var oldItem in oldDiscountItems)
                {
                    if (!gameIds.Contains(oldItem.GameId))
                    {
                        // 如果在现有的 gameIds 数组中未找到，从数据库中删除
                        db.DiscountItems.Remove(oldItem);
                    }
                }

                // 提交变更到数据库
                db.SaveChanges();

            }
        }
    }
}
