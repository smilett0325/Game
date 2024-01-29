using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Infra
{
	public class UploadFileHelper
	{
		/// <summary>
		/// 將上傳檔案存放到指定資料夾
		/// </summary>
		/// <param name="file">上傳的檔案</param>
		/// <param name="path">檔案存放資料夾</param>
		/// <returns>回傳實際存取檔名</returns>
		/// <exception cref="ArgumentNullException">若沒上傳檔案，丟出此例外</exception>
		/// <exception cref="ArgumentException">上傳非圖片，丟出此例外</exception>
		/// <exception cref="Exception">指定檔案資料夾不存在，丟出此例外</exception>
		public string UploadImageFile(HttpPostedFileBase file, string path)
		{
			//判斷有沒有上傳檔案,若沒有,丟出例外
			if (file == null || file.ContentLength == 0) throw new ArgumentNullException("file");

			//取得副檔名並判斷是否為允許的檔案類型
			//可用委派來增加擴展性
			string[] allowExts = { ".jpg", ".jpeg", ".png" };
			string ext = Path.GetExtension(file.FileName).ToLower();
			if (!allowExts.Contains(ext)) throw new ArgumentException($"不允許上傳此類檔案({ext})");

			//為避免不同時間上傳相同檔名,造成覆蓋,所以每次都要取一格唯一檔名
			string fileName = Path.GetRandomFileName();

			//與附檔名合併成一個正常檔名
			string newFileName = fileName + ext;
			string fullName = Path.Combine(path, newFileName);

			//將上傳檔案存放並取得檔名
			file.SaveAs(fullName);

			return newFileName;
		}
	}
}