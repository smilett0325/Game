using RizzGameingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGameingBase.Models.IRepositories
{
	public interface IRepository
	{
		// 這邊先看需要什麼功能  增刪茶改  只是個介面  
		void Create(MemberEntity entity);
		List<MemberEntity> GetAll();

		List<MemberEntity> Search(string name);
		MemberEntity Find(int memberId);

		void Delete(int memberId);

		void Update(MemberEntity entity);

        void Edit(MemberEntity entity);


    }
}
