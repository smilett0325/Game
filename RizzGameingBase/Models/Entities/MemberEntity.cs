using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGameingBase.Models.Entities
{   //                                                                          挑需要的欄位
	// DataBase => EFModels => Entities(新增欄位驗證) => Dtos(資料轉換銜接用) => ViewModels(For單一網頁用，抓要的就好)
	//							repository				service					controller
	public class MemberEntity
	{
		//最後的防線
		//這裡要給欄位驗證           !!EFModel建置的不要動!!
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Account { get; set; }

		[Required]
		[StringLength(50)]
		public string Password { get; set; }

		[Required]
		[StringLength(50)]
		public string Mail { get; set; }

		[StringLength(200)]
		public string AvatarURL { get; set; }

		public DateTime? RegistrationDate { get; set; }

		public DateTime? BanTime { get; set; }

		public int? Bonus { get; set; }

		public DateTime? LastLoginDate { get; set; }

		public DateTime? Birthday { get; set; }

		[StringLength(50)]
		public string NickName { get; set; }
	}
}