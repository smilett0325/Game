using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Repositories.EFRepositories;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RizzGamingBase.Models.Services
{
    public class DeveloperService
    {
        IDeveloperRepository _repo;
        public DeveloperService(IDeveloperRepository repo)
        {
            _repo = repo;
        }

        public void CreateDevelopers(DeveloperDto dto)
        {
            var developer = new DeveloperEntity();

            developer.Name = dto.Name;
            developer.Account = dto.Account;
            developer.Password = dto.Password;
            developer.Mail = dto.Mail;
            developer.Number = dto.Number;

            _repo.Create(developer);
        }
        public List<DeveloperDto> GetAllDevelopers()
        {
            var data = _repo.GetAll();//
            var members = data.Select(x => new DeveloperDto
            {
                Id = x.Id,
                Name = x.Name,
                Account = x.Account,
                Password = x.Password,
                Mail = x.Mail,
                Number=x.Number
            })
                .ToList();
            return members;

        }

       

        

        public void Update(DeveloperDto dto)
        {
            // todo 進行必要的業務邏輯檢查

            // 叫用 repository 存檔
            DeveloperEntity entity = new DeveloperEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Account = dto.Account,
                Password = dto.Password,
                Mail = dto.Mail,
                Number = dto.Number,
                BanTime= dto.BanTime

            };

            _repo.Create(entity);
        }




    }


}