using Microsoft.Ajax.Utilities;
using RizzGameingBase.Models.EFModels;
using RizzGameingBase.Models.Entities;
using RizzGameingBase.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Member = RizzGameingBase.Models.EFModels.Member;

namespace RizzGameingBase.Models.Repositories.EFRepositories
{


    public class MemberEFRepository : IRepository
	{
        // 繼承IRepository   加 :IRepository
        // 這裡先是實作曾山茶改  之後給 service使用 

        //這是= var db= new AppDbContext();  相對前面較 1.安全 2.維護姓 3.配置靈活性
        AppDbContext _dbContext = new AppDbContext();
       

        public void Create(MemberEntity entity)
		{
			var member = new Member
			{
				// 這邊是所有都要有 ?

				Id = entity.Id,
				Account=entity.Account,
				Password=entity.Password,
				Mail=entity.Mail,
				AvatarURL=entity.AvatarURL,
				NickName=entity.NickName,
				
			};
			_dbContext.Members.Add(member);
			_dbContext.SaveChanges();
		}

		public void Delete(int memberId)
		{
			//GetAll > 用single 找那一個id > 將他刪除

			//不確定這樣行不行!
			var members = GetAll();
			var member = members.Single(x => x.Id == memberId);
			members.Remove(member);

            _dbContext.SaveChanges();
        }

		//private void Save(List<MemberEntity> members)
		//{
		//	//還不確定要不要做
		//}

		public MemberEntity Find(int memberId)
		{
			//用GetAll去找每個id
			var result =
				GetAll().SingleOrDefault(x => x.Id == memberId);
			return result;
		}

        //得到所有的值
        public List<MemberEntity> GetAll()
		{
			
			List<MemberEntity> memberList = _dbContext.Members
											.AsNoTracking()
											.Select(m => new MemberEntity()
											{
												//這邊將ef型態 轉型成 entity型態
												Id = m.Id,
												Account= m.Account,
												Password= m.Password,
												Mail= m.Mail,
												AvatarURL= m.AvatarURL,
												RegistrationDate= m.RegistrationDate,
												Bonus= m.Bonus,
												LastLoginDate= m.LastLoginDate,
												Birthday= m.Birthday,
												BanTime= m.BanTime,
												NickName = m.NickName,

											})
											.ToList();
												
			return memberList;
		}

		public void Update(MemberEntity entity)
		{
            var existingMembersEntity = _dbContext.Members.Find(entity.Id);
			if (existingMembersEntity != null)
			{
				//不確定是不是全部要做
				existingMembersEntity.Id = entity.Id;
				existingMembersEntity.Account= entity.Account;
				existingMembersEntity.Password= entity.Password;
				existingMembersEntity.Mail= entity.Mail;
				existingMembersEntity.AvatarURL = entity.AvatarURL;
				existingMembersEntity.RegistrationDate= entity.RegistrationDate;
				existingMembersEntity.BanTime= entity.BanTime;
				existingMembersEntity.Bonus= entity.Bonus;
				existingMembersEntity.LastLoginDate= entity.LastLoginDate;
				existingMembersEntity.Birthday= entity.Birthday;
				existingMembersEntity.NickName= entity.NickName;

			}
			_dbContext.SaveChanges();


        }

        public List<MemberEntity> Search(string name)
        {
			var memberList = _dbContext.Members
				.Where(m => m.NickName.Contains(name))
				.Select(m => new MemberEntity
				{
					Id = m.Id,
					Account = m.Account,
					Mail = m.Mail,
					AvatarURL = m.AvatarURL,
					RegistrationDate = m.RegistrationDate,
					BanTime = m.BanTime,
					Bonus = m.Bonus,
					LastLoginDate = m.LastLoginDate,
					Birthday = m.Birthday,
					NickName = m.NickName,
				})
				.ToList();
			return memberList;
		}

        public void Edit(MemberEntity entity)
        {
			var member = _dbContext.Members.Find(entity.Id);
			if (member != null)
			{
				member.Password = entity.Password;
				member.Mail = entity.Mail;
				member.AvatarURL = entity.AvatarURL;
				member.Birthday = entity.Birthday;
				member.NickName = entity.NickName;
			}
			_dbContext.SaveChanges();
		}





		//以下是明確實做(X)  用實作就好!!!  


        //     List<MemberEntity> IRepository.Search(string name)
        //     {
        //var memberList = _dbContext.Members
        //	.Where(m => m.NickName.Contains(name))
        //	.Select(m => new MemberEntity {
        //		Id=m.Id,
        //		Account=m.Account,
        //		Mail=m.Mail,
        //		AvatarURL=m.AvatarURL,
        //		RegistrationDate=m.RegistrationDate,
        //		BanTime = m.BanTime,
        //		Bonus=m.Bonus,
        //		LastLoginDate=m.LastLoginDate,
        //		Birthday=m.Birthday,
        //		NickName=m.NickName,
        //	})
        //	.ToList();
        //return memberList;

        //     }

        //     void IRepository.Edit(MemberEntity entity)
        //     {
        //var member = _dbContext.Members.Find(entity.Id);
        //if (member != null)
        //{
        //	member.Password= entity.Password;
        //	member.Mail= entity.Mail;
        //	member.AvatarURL= entity.AvatarURL;
        //	member.Birthday=entity.Birthday;
        //	member.NickName= entity.NickName;
        //}
        //_dbContext.SaveChanges();
        //     }
    }
}