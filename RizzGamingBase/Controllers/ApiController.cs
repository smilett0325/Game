using RizzGamingBase.Models.EFModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RizzGamingBase.Controllers
{
    public class ApiController : Controller
    {
		// GET: Api
		//public IActionResult Register(Member member, IFormFile avatar)
		//{
		//	var db = new AppDbContext();

		//	string uploadPath = Path.Combine(_host.WebRootPath, "uploads", avatar?.FileName ?? "empty.jpg");

		//	using (var fileStream = new FileStream(uploadPath, FileMode.Create))
		//	{
		//		avatar?.CopyTo(fileStream);
		//	}

		//	//轉成二進位
		//	byte[]? imgByte = null;
		//	using (var memotyStream = new MemoryStream())
		//	{
		//		avatar?.CopyTo(memotyStream);
		//		imgByte = memotyStream.ToArray();
		//	}
		//	member.FileName = avatar?.FileName;
		//	member.FileData = imgByte;


		//	db.Members.Add(member);
		//	db.SaveChanges();

		//	return Content($"{member.Name}註冊成功");
		//}
	}
}