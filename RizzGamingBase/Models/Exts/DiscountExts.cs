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
        public static List<DiscountEntity> GetDbToEntity()
        {
            var db = new AppDbContext();

            var entities = db.Discounts.AsNoTracking()
               .Select(d => new DiscountEntity
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

        public static List<DiscountDto> GetEntityToDto(this List<DiscountEntity> entity)
        {
            var listvm = new List<DiscountDto>();

            foreach (var e in entity)
            {
                var vm = new DiscountDto
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

        public static List<DiscountIndexVm> GetDtoToVm(this List<DiscountDto> dtos)
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

        public static DiscountEntity GetDbToEntity(int id)
        {
            var db = new AppDbContext();

            var discount = db.Discounts.FirstOrDefault(x => x.Id == id);

            var entity = new DiscountEntity
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

            var gameInfo = db.DiscountItems
                             .Where(x => x.DiscountId == id)
                             .Select(d => new DiscountItemInfo
                             {
                                 Id = d.Id,
                                 DiscountId = discount.Id,
                                 GameID = d.GameId,
                                 Game = new GameInfo
                                 {
                                     Id = d.Game.Id,
                                     Name = d.Game.Name,
                                     Developer = d.Game.Developer.Name,
                                     Price = d.Game.Price,
                                     Image = d.Game.Cover,
                                     MaxPercent = d.Game.MaxPersent
                                 }
                             });

            entity.DiscountItem = gameInfo;
            return entity;
        }

        public static DiscountDto GetEntityToDto(this DiscountEntity entity)
        {
            var dto = new DiscountDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                Image = entity.Image,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Percent = entity.Percent,
                Desciption = entity.Desciption,
                DiscountItem = entity.DiscountItem
            };
            return dto;
        }

        public static DiscountVm GetDtoToVm(this DiscountDto dto)
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
                DiscountItem = new List<DiscountItemVm>()
            };

            foreach(var g in dto.DiscountItem)
            {
                var disocuntItemVm = new DiscountItemVm
                {
                    Id = g.Id,
                    DiscountId = g.DiscountId,
                    GameId = g.GameID,
                    Game = new DiscountGameVm
                    {
                        Id = g.Game.Id,
                        Name = g.Game.Name,
                        Price = g.Game.Price,
                        Developer = g.Game.Developer,
                        Image = g.Game.Image,
                        MaxPercent = g.Game.MaxPercent,
                    }
                };

                vm.DiscountItem.Add(disocuntItemVm);
            }
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
        public static DiscountDto EditVmToDto(this DiscountVm vm)
        {
            var dto = new DiscountDto
            {
                Id = vm.Id,
                Name = vm.DiscountName,
                Type = vm.DiscountType,
                Image = vm.DiscountImage,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Percent = vm.Percent,
                Desciption = vm.Description,
                DiscountItem = vm.DiscountItem.Select(di => new DiscountItemInfo
                {
                    Id = di.Id,
                    DiscountId = di.DiscountId,
                    GameID = di.GameId, // 將字串轉換為整數
                    Game = new GameInfo
                    {
                        Id = di.Game.Id,
                        Name = di.Game.Name,
                        Developer = di.Game.Developer,
                        Price = di.Game.Price,
                        MaxPercent = di.Game.MaxPercent,
                        Image = di.Game.Image
                    }
                }).ToList()
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

        public static DiscountEntity EditDtoToEntity(this DiscountDto vm)
        {
            var entity = new DiscountEntity
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Image = vm.Image,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,
                Percent = vm.Percent,
                Desciption = vm.Desciption,
                DiscountItem = vm.DiscountItem
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

        public static void EditEntityToDb(this DiscountEntity entity)
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

                    foreach (var item in entity.DiscountItem)
                    {
                        if (item.Id == 0)
                        {
                            var newItem = new DiscountItem
                            {
                                DiscountId = discount.Id,
                                GameId = item.GameID
                            };
                            db.DiscountItems.Add(newItem);
                        }
                        else
                        {
                            var discountItem = db.DiscountItems.SingleOrDefault(d => d.DiscountId == entity.Id && d.GameId == item.GameID);
                            if (discountItem != null)
                            {
                                
                                discountItem.GameId = item.GameID;
                            }
                        }
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}