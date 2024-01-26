using Microsoft.Ajax.Utilities;
using RizzGameingBase.Models.Dtos;
using RizzGameingBase.Models.IServices;
using RizzGameingBase.Models.Repositories.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGameingBase.Models.Services
{
    // MemberService 类实现了 IMemberService 接口，用于处理会员相关的业务逻辑
    public class MemberService : IMemberService
    {
        // 使用 MemberEFRepository 对象处理与 Entity Framework 相关的数据库操作
        private readonly MemberEFRepository _memberEFRepository;


        // 构造函数，接收 MemberEFRepository 作为依赖注入的方式
        public MemberService(MemberEFRepository memberEFRepository)
        {
            //轉換
            _memberEFRepository = memberEFRepository;
        }



        //todo  寫商業邏輯判斷
        public void CreateMember(MemberDto memberDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteMember(int id)
        {
            throw new NotImplementedException();
        }

        public List<MemberDto> GetAllMember()
        {
            throw new NotImplementedException();
        }

        public MemberDto GetGMemberById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMember(MemberDto memberDto)
        {
            throw new NotImplementedException();
        }
    }
}