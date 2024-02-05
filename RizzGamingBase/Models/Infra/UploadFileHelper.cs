using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;

namespace RizzGamingBase.Models.Infra
{
	public class UploadFileHelper
	{
		public void UploadFile(HttpPostedFileBase file, string categoryFolderName, int developerId, int gameId, string[] allowedExtensions)
		{
			//判斷是否上傳
			if (file == null || file.ContentLength == 0)
				throw new ArgumentNullException("file");

			// 获取文件的扩展名，并检查是否为允许的文件类型
			//string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
			string ext = Path.GetExtension(file.FileName).ToLower();
			if (!allowedExtensions.Contains(ext))
				throw new ArgumentException($"不允許上傳此類檔案({ext})");

			//用相對路徑找出絕對路徑
			string absolutePath = HostingEnvironment.MapPath("/Images");

			//合併成類別資料夾路徑
			string categoryFolderPath = Path.Combine(absolutePath, categoryFolderName);

			// 检查文件夾是否存在，如果不存在则创建
			if (!Directory.Exists(categoryFolderPath))
				Directory.CreateDirectory(categoryFolderPath);

			// 使用开发商的ID創建文件夾路徑，可自訂命名規則
			string developerFolderPath = Path.Combine(categoryFolderPath, $"{developerId}");

			// 检查文件夹是否存在，如果不存在則創建
			if (!Directory.Exists(developerFolderPath))
				Directory.CreateDirectory(developerFolderPath);

			// 使用遊戲的ID創建文件夾路徑，可自訂命名規則
			string developerGameFolderPath = Path.Combine(developerFolderPath, $"{gameId}");

			//檢查developerGameFolderPath是否存在，不存在則創建
			if (!Directory.Exists(developerGameFolderPath))
				Directory.CreateDirectory(developerGameFolderPath);


			// 合并文件名和路径生成完整的文件路径
			string fileName = file.FileName;
			string fullPath = Path.Combine(developerGameFolderPath, fileName);

			// 将上传的文件保存到指定路径
			file.SaveAs(fullPath);
		}

		public void DeleteFile(string categoryFolderName, int developerId, int gameId, string fileName)
		{
			var fullPath = HostingEnvironment.MapPath($"/Images/{categoryFolderName}/{developerId}/{gameId}/{fileName}");
			File.Delete(fullPath);
		}
	}
}