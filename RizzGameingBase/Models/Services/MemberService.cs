using Microsoft.Ajax.Utilities;
using RizzGameingBase.Models.Dtos;
using RizzGameingBase.Models.EFModels;
using RizzGameingBase.Models.Entities;
using RizzGameingBase.Models.IRepositories;
using RizzGameingBase.Models.Repositories.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGameingBase.Models.Services
{
    public class MemberService 
    {

        // 。

        private readonly IRepository _repo;

        //// 
        public MemberService(IRepository repo)
        {
            // 。

            _repo = repo;
        }

        
        //將資料從 MemberDto 轉換為 MemberEntity 並創建。
        public void CreateMember(MemberDto memberDto)
        {
            if (memberDto == null) throw new NotImplementedException();

            //還要再寫其他判斷
            var member = new MemberEntity();
            member.Account= memberDto.Account;
            member.Password= memberDto.Password;
            member.Mail= memberDto.Mail;
            member.AvatarURL= memberDto.AvatarURL;
            member.Birthday= memberDto.Birthday;
            member.NickName= memberDto.NickName;

            _repo.Create(member);

        }

        //刪除
        public void DeleteMember(int memberId)
        {
            _repo.Delete(memberId);
        }


        public List<MemberDto> GetAllMembers()
        {
            var data = _repo.GetAll();//
            var members = data.Select(x => new MemberDto
            {
                Id = x.Id,
                Account = x.Account,
                Password = x.Password,
                Mail = x.Mail,
                AvatarURL = x.AvatarURL,
                Birthday = x.Birthday,
                NickName = x.NickName,
                RegistrationDate = x.RegistrationDate,
                BanTime = x.BanTime,
                LastLoginDate = x.LastLoginDate,
            })
                .ToList();
                return members;

        }
        

        public MemberDto GetMemberById(int memberId)
        {
            var member = _repo.Find(memberId);
            return new MemberDto
            {
                Id= member.Id,
                Account= member.Account,
                Password= member.Password,
                Mail= member.Mail,
                AvatarURL= member.AvatarURL,
                Birthday= member.Birthday,
                NickName= member.NickName,
                RegistrationDate= member.RegistrationDate,
                BanTime= member.BanTime,
                LastLoginDate= member.LastLoginDate,
            };
        }

        public void UpdateMember(MemberDto memberDto)
        {
            if (memberDto == null) throw new NotImplementedException();

            //還要再寫其他判斷
            //不確定是不是每個都要?

            var member = new MemberEntity();
            member.Account = memberDto.Account;
            member.Password = memberDto.Password;
            member.Mail = memberDto.Mail;
            member.AvatarURL = memberDto.AvatarURL;
            member.Birthday = memberDto.Birthday;
            member.NickName = memberDto.NickName;

            _repo.Update(member);
        }
    }
}