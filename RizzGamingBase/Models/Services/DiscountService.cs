using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Services
{
    public class DiscountService
    {
        private readonly IDiscountRepository _repo;
        public DiscountService(IDiscountRepository repo)
        {
            _repo = repo;
        }

        public List<DiscountDto> GetAllEvent()
        {
            var enetity = _repo.GetAllEvent();
            return DiscountExts.GetEntityToDto(enetity);
        }

        public DiscountDto GetEvent(int id)
        {
            var entity = _repo.GetEvent(id);

            return DiscountExts.GetEntityToDto(entity);
        }

        public void Create(DiscountCreateDto dto) 
        {
            var entity = DiscountExts.CreateDtoToEntity(dto);
            _repo.Create(entity);
        }

        public void Edit(DiscountDto dto)
        {
            var entity = DiscountExts.EditDtoToEntity(dto);
            _repo.Edit(entity);

        }
    }
}