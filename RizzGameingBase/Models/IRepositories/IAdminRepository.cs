using RizzGameingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.IRepositories
{
    public interface IAdminRepository
    {
        void Create(AdminEntity entity);

        void Delete(int id);
        List<AdminEntity> GetAll();

        AdminEntity Search(string name);

        void Edit(AdminEntity entity);

        AdminEntity GetId(int id);

        void Update(AdminEntity entity);
    }
}
