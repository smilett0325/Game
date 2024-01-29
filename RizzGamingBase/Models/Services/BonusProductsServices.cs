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
                ProductTypeid = dto.ProductTypeid,
                Price = dto.Price,
                URL = dto.URL,
                Name = dto.Name
            };
            _repo.Create(entity);
        }

        public void Delete(BonusProductsDto dto)
        {
            throw new NotImplementedException();
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
                    ProductTypeid = dtoitem.ProductTypeid,
                    TypeName = dtoitem.TypeName,
                    Price = dtoitem.Price,
                    URL = dtoitem.URL,
                    Name = dtoitem.Name
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public void Search(BonusProductsDto dto)
        {
            throw new NotImplementedException();
        }

        public BonusProductsDto LoadProdct(int id)
        {
            var entity = _repo.SearchById(id);

            var dto = new BonusProductsDto
            {
                Id = entity.Id,
                ProductTypeid = entity.ProductTypeid,
                TypeName = entity.TypeName,
                Price = entity.Price,
                URL = entity.URL,
                Name = entity.Name
            };
            return dto;
        }

        public void Update(BonusProductsDto dto)
        {
            BonusProductsEntity entity = new BonusProductsEntity
            {
                Id = dto.Id,
                ProductTypeid = dto.ProductTypeid,
                Price = dto.Price,
                TypeName = dto.TypeName,
                URL = dto.URL,
                Name = dto.Name
            };
            _repo.Update(entity);
        }
    }
}