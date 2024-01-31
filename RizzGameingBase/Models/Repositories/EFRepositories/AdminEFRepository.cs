using Microsoft.Ajax.Utilities;
using RizzGameingBase.Models.EFModels;
using RizzGameingBase.Models.Entities;

using RizzGamingBase.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
    public class AdminEFRepository : IAdminRepository
    {
        AppDbContext _dbContext = new AppDbContext();
        public void Create(AdminEntity entity)
        {
            var admin = new Admin
            {
                // 這邊是所有都要有 
                Id = entity.Id,
                Account = entity.Account,
                Password = entity.Password,
                CinfrimPassword = entity.CinfrimPassword,
                AvatarURL = entity.AvatarURL,
                NickName = entity.NickName,
                Permission = entity.Permission,
                PermissionId = entity.PermissionId,
                Position = entity.Position,
                PositionId = entity.PositionId


            };
            //todo
              _dbContext.Admins.Add(admin);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var admins = GetAll();
            var admin = admins.Single(x => x.Id == id);
            admins.Remove(admin);

            _dbContext.SaveChanges();
        }

        public void Edit(AdminEntity entity)
        {
            var admin = _dbContext.Admins.Find(entity.Id);
            if (admin != null)
            {
                admin.Password = entity.Password;
                admin.NickName = entity.NickName;
                admin.AvatarURL = entity.AvatarURL;
                admin.CinfrimPassword = entity.CinfrimPassword;
                admin.Position = entity.Position;
                admin.PositionId = entity.PositionId;
                admin.Permission = entity.Permission;
                admin.PermissionId = entity.PermissionId;
                admin.NickName = entity.NickName;
            }
            _dbContext.SaveChanges();
        }

        public List<AdminEntity> GetAll()
        {
            List<AdminEntity> adminlist = _dbContext.Admins.AsNoTracking().Select(m => new AdminEntity()
            {
                Id = m.Id,
                Account = m.Account,
                Password = m.Password,
                AvatarURL = m.AvatarURL,
                NickName = m.NickName,
                CinfrimPassword = m.CinfrimPassword,
                Position = m.Position,
                PositionId = m.PositionId,
                Permission = m.Permission,
                PermissionId = m.PermissionId,
            }).ToList();
            return adminlist;
        }

        public AdminEntity GetId(int id)
        {
            //用GetAll去找每個id
            var result =
                GetAll().SingleOrDefault(x => x.Id == id);
            return result;
        }

        public AdminEntity Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(AdminEntity entity)
        {
            var existingAdminsEntity = _dbContext.Admins.Find(entity.Id);

            if (existingAdminsEntity != null)
            {
                existingAdminsEntity.Id = entity.Id;

                
                    existingAdminsEntity.Password = entity.Password;
                
                existingAdminsEntity.CinfrimPassword = entity.CinfrimPassword;
                existingAdminsEntity.AvatarURL = entity.AvatarURL;
                existingAdminsEntity.NickName = entity.NickName;
                existingAdminsEntity.Position = entity.Position;
                existingAdminsEntity.PositionId = entity.PositionId;
                existingAdminsEntity.Permission = entity.Permission;
                existingAdminsEntity.PermissionId = entity.PermissionId;
            }
            _dbContext.SaveChanges();
        }
    }

        

        

        
    }
