using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Services
{
    public class BonusProductsServices : IBonusProductsServices
    {
        private readonly IBonusProductsRepository _repo;

        public BonusProductsServices(IBonusProductsRepository repo)
        {
            _repo = repo;
        }
        public void Create(BonusProductsDto dto)
        {
            BonusProductsEntity entity = new BonusProductsEntity
            {
                Id = dto.Id,
                ProductTypeId = dto.ProductTypeId,
                Price = dto.Price,
                URL = dto.URL,
                Name = dto.Name
            };
            _repo.Create(entity);
        }

        public List<BonusProductsDto> GetAll()
        {
            var entity = _repo.GetAll();

            var dtoList = new List<BonusProductsDto>();
            foreach (var dtoitem in entity)
            {
                var dto = new BonusProductsDto
                {
                    Id = dtoitem.Id,
                    ProductTypeId = dtoitem.ProductTypeId,
                    ProductTypeName = dtoitem.ProductTypeName,
                    Price = dtoitem.Price,
                    URL = dtoitem.URL,
                    Name = dtoitem.Name
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<BonusProductsDto> SearchByName(string keyword)
        {
            var entity = _repo.SearchByName(keyword);

            var dtoList = new List<BonusProductsDto>();
            foreach (var dtoitem in entity)
            {
                var dto = new BonusProductsDto
                {
                    Id = dtoitem.Id,
                    ProductTypeId = dtoitem.ProductTypeId,
                    ProductTypeName = dtoitem.ProductTypeName,
                    Price = dtoitem.Price,
                    URL = dtoitem.URL,
                    Name = dtoitem.Name
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public BonusProductsDto LoadProdct(int id)
        {
            var entity = _repo.SearchById(id);

            var dto = new BonusProductsDto
            {
                Id = entity.Id,
                ProductTypeId = entity.ProductTypeId,
                ProductTypeName = entity.ProductTypeName,
                Price = entity.Price,
                URL = entity.URL,
                Name = entity.Name
            };
            return dto;
        }

        // todo 完成3層式，編輯Service
        public void Edit(BonusProductsDto dto)
        {
            //BonusProductsEntity entity = new BonusProductsEntity
            //{
            //    Id = dto.Id,
            //    ProductTypeId = dto.ProductTypeId,
            //    Price = dto.Price,
            //    ProductTypeName = dto.ProductTypeName,
            //    URL = dto.URL,
            //    Name = dto.Name
            //};
            //_repo.Edit(entity);
        }

        // todo 完成3層式，刪除Service
        public void Delete(BonusProductsDto dto)
        {
            throw new NotImplementedException();
        }
    }
}