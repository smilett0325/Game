using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Exts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
    public class DeveloperRepository : IDeveloperRepository

    {  // 繼承IRepository   加 :IRepository
        // 這裡先是實作曾山茶改  之後給 service使用 

        //這是= var db= new AppDbContext();  相對前面較 1.安全 2.維護姓 3.配置靈活性
        AppDbContext _dbContext = new AppDbContext();
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

        public void Update(DeveloperEntity entity)
        {
            throw new NotImplementedException();
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