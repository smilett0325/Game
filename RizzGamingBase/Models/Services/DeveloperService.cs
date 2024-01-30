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

        // 使用更安全的雜湊算法，例如 SHA256
        



    }


}