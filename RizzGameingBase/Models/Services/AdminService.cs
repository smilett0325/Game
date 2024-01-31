using RizzGameingBase.Models.Dtos;
using RizzGameingBase.Models.Entities;
using RizzGamingBase.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Services
{
    public class AdminService
    {
        private readonly IAdminRepository _repo;

        public AdminService(IAdminRepository repo)
        {
          _repo = repo;
        }

        public void CreateAdmin(AdminDto adminDto)
        { if (adminDto==null)throw new NotImplementedException();
        var admin = new AdminEntity();
            admin.Id = adminDto.Id;
            admin.Account = adminDto.Account;
            admin.Password = adminDto.Password;
            admin.CinfrimPassword=adminDto.CinfrimPassword;
            admin.AvatarURL = adminDto.AvatarURL;
            admin.NickName = adminDto.NickName;
            admin.Permission = adminDto.Permission;
            admin.PermissionId = adminDto.PermissionId;
            admin.Position = adminDto.Position;
            admin.PositionId = adminDto.PositionId;

            _repo.Create(admin);
        }

        public void DeleteAdmin(int adminId)
        {
            _repo.Delete(adminId);
        }

        public List<AdminDto> GetAllAdmins()
        {
            var data = _repo.GetAll();
            var admins = data.Select(x => new AdminDto
            {
                Id = x.Id,
                Account = x.Account,
                Password = x.Password,
                CinfrimPassword = x.CinfrimPassword,
                AvatarURL = x.AvatarURL,
                NickName = x.NickName,
                Permission = x.Permission,
                PermissionId = x.PermissionId,
                Position = x.Position,
                PositionId = x.PositionId
            })
                .ToList();
            return admins;
        }

        public AdminDto GetAdminById(int adminId)
        {
            var admin = _repo.GetId(adminId);
            return new AdminDto
            {
                Id = admin.Id,
                Account = admin.Account,
                Password = admin.Password,
                CinfrimPassword = admin.CinfrimPassword,
                AvatarURL = admin.AvatarURL,
                NickName = admin.NickName,
                Permission = admin.Permission,
                PermissionId = admin.PermissionId,
                Position = admin.Position,
                PositionId = admin.PositionId
            };
        }
        public void UpdateAdmin(AdminDto adminDto)
        {
            if (adminDto == null) throw new NotImplementedException();

            var admin = new AdminEntity
            {
                Id = adminDto.Id,
                Account = adminDto.Account,
                Password = adminDto.Password,
                CinfrimPassword = adminDto.CinfrimPassword,
                AvatarURL = adminDto.AvatarURL,
                NickName = adminDto.NickName,
                Permission = adminDto.Permission,
                PermissionId = adminDto.PermissionId,
                Position = adminDto.Position,
                PositionId = adminDto.PositionId,
                

            };
            _repo.Update(admin);
        }
    }
}