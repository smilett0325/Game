using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Services;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
    public class DeveloperRepository : IDeveloperRepository

    {  // 繼承IRepository   加 :IRepository
        // 這裡先是實作曾山茶改  之後給 service使用 

        //這是= var db= new AppDbContext();  相對前面較 1.安全 2.維護姓 3.配置靈活性
        APPDbContext _dbContext = new APPDbContext();
        public void Create(DeveloperEntity entity)
        {
                Developer model = entity.EntityToEF();
                _dbContext.Developers.Add(model);
                _dbContext.SaveChanges();
            
        }
    

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(DeveloperEntity entity)
        {
            throw new NotImplementedException();
        }

        public DeveloperEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        //得到所有的值
        public List<DeveloperEntity> GetAll()
        {

            List<DeveloperEntity> developerList =
            _dbContext.Developers.AsNoTracking()
                            .Select(d => new DeveloperEntity
                            {
                                Id = d.Id,
                                Name = d.Name,
                                Account = d.Account,
                                Password = d.Password,
                                Mail=d.Mail,
                                Number= d.Number
                            })
                            .ToList();

            return developerList;
        }


        public DeveloperEntity Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(DeveloperEntity model)
        {
            // 在此, 採用EF,ADO.NET or Dapper將model各屬性值存放到db

            var db = new APPDbContext();
            Developer entity = new Developer
            {
                Id = model.Id,
                Name = model.Name,
                Account = model.Account,
                Password = model.Password,
                Mail = model.Mail,
                Number = model.Number,
                BanTime= model.BanTime


            };

            db.Developers.Add(entity);
            db.SaveChanges();
        }

        public void SignUp(DeveloperEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Login(string name, string password)
        {
            throw new NotImplementedException();
        }

        private bool IsDeveloperValid(string name, string password)
        {
            throw new NotImplementedException();
        }


    }
}