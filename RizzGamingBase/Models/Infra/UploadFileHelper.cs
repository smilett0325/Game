using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

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
		//public string UploadImageFile(HttpPostedFileBase file, string path)
		//{
		//	//判斷有沒有上傳檔案,若沒有,丟出例外
		//	if (file == null || file.ContentLength == 0) throw new ArgumentNullException("file");

		//	//取得副檔名並判斷是否為允許的檔案類型
		//	//可用委派來增加擴展性
		//	string[] allowExts = { ".jpg", ".jpeg", ".png" };
		//	string ext = Path.GetExtension(file.FileName).ToLower();
		//	if (!allowExts.Contains(ext)) throw new ArgumentException($"不允許上傳此類檔案({ext})");

		//	//為避免不同時間上傳相同檔名,造成覆蓋,所以每次都要取一格唯一檔名
		//	string fileName = Path.GetRandomFileName();

		//	//與附檔名合併成一個正常檔名
		//	string newFileName = fileName + ext;
		//	string fullName = Path.Combine(path, newFileName);

		//	//將上傳檔案存放並取得檔名
		//	file.SaveAs(fullName);

		//	return newFileName;
		//}

		//public void DeleteScratchFile(HttpPostedFileBase file, string path)
		//{
		//	string scratchPath = path;

		//	// 合并文件名和路径生成完整的文件路径
		//	string fileName = file.FileName;
		//	string fullPath = Path.Combine(scratchPath, fileName);

		//	// 将上传的文件保存到指定路径
		//	File.Delete(fullPath);
		//}

		//public void DeleteScratchFile(string[] fileNames, string path)
		//{
		//	string scratchPath = path;

		//	foreach (var fileName in fileNames)
		//	{
		//		string fullPath = Path.Combine(scratchPath, fileName);
		//		File.Delete(fullPath);
		//	}
		//}


		//public List<object> ScratchFile(IEnumerable<HttpPostedFileBase> cover, string path)
		//{
		//	var scratchObjects = new List<object>();

		//	foreach (var file in cover)
		//	{
		//		// 判断是否有上传文件，若没有，抛出异常
		//		if (file == null || file.ContentLength == 0)
		//			throw new ArgumentNullException("file");

		//		// 获取文件的扩展名，并检查是否为允许的文件类型
		//		string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
		//		string ext = Path.GetExtension(file.FileName).ToLower();
		//		if (!allowedExtensions.Contains(ext))
		//			throw new ArgumentException($"不允許上傳此類檔案({ext})");

		//		string scratchPath = path;
		//		string idName = Path.GetFileNameWithoutExtension(file.FileName).ToLower();

		//		// 合并文件名和路径生成完整的文件路径
		//		string fileName = file.FileName;
		//		string fullPath = Path.Combine(scratchPath, fileName);

		//		// 将上传的文件保存到指定路径
		//		file.SaveAs(fullPath);
		//		scratchObjects.Add(new { Name = fileName, NameForId = idName });
		//	}

		//	return scratchObjects;
		//}

		public void UploadCoverFile(HttpPostedFileBase cover, string path, int developerId)
		{
			// 判断是否有上传文件，若没有，抛出异常
			if (cover == null || cover.ContentLength == 0)
				throw new ArgumentNullException("file");

			// 获取文件的扩展名，并检查是否为允许的文件类型
			string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
			string ext = Path.GetExtension(cover.FileName).ToLower();
			if (!allowedExtensions.Contains(ext))
				throw new ArgumentException($"不允許上傳此類檔案({ext})");


			// 使用开发商的ID创建文件夹路径
			string developerFolderPath = Path.Combine(path, $"{developerId}");

			// 检查文件夹是否存在，如果不存在则创建
			if (!Directory.Exists(developerFolderPath))
			{
				Directory.CreateDirectory(developerFolderPath);
			}

			//檢查developerGameFolderPath是否存在，不存在則創建
			//string developerGameFolderPath = Path.Combine(path, $"{developerId}", $"{gameId}");

			//if (!Directory.Exists(developerGameFolderPath))
			//{
			//	Directory.CreateDirectory(developerGameFolderPath);
			//}

			// 合并文件名和路径生成完整的文件路径
			string fileName = cover.FileName;
			string fullPath = Path.Combine(developerFolderPath, fileName);

			// 将上传的文件保存到指定路径
			cover.SaveAs(fullPath);

			// 返回新的文件名，可以用于记录到数据库或其他用途
			//return fullPath;
			//return fileName;
		}

		public void UploadDisplayImageFile(HttpPostedFileBase displayImage, string path, int developerId, int gameId)
		{
			//var imageObjects = new List<object>();

			//foreach (var file in displayImage)
			//{
			// 判断是否有上传文件，若没有，抛出异常
			if (displayImage == null || displayImage.ContentLength == 0)
				throw new ArgumentNullException("file");

			// 获取文件的扩展名，并检查是否为允许的文件类型
			string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
			string ext = Path.GetExtension(displayImage.FileName).ToLower();
			if (!allowedExtensions.Contains(ext))
				throw new ArgumentException($"不允許上傳此類檔案({ext})");

			// 使用开发商的ID创建文件夹路径
			string developerFolderPath = Path.Combine(path, $"{developerId}");

			// 检查文件夹是否存在，如果不存在则创建
			if (!Directory.Exists(developerFolderPath))
			{
				Directory.CreateDirectory(developerFolderPath);
			}

			//檢查developerGameFolderPath是否存在，不存在則創建
			string developerGameFolderPath = Path.Combine(path, $"{developerId}", $"{gameId}");

			if (!Directory.Exists(developerGameFolderPath))
			{
				Directory.CreateDirectory(developerGameFolderPath);
			}

			// 合并文件名和路径生成完整的文件路径
			string fileName = displayImage.FileName;
			string fullPath = Path.Combine(developerGameFolderPath, fileName);

			// 将上传的文件保存到指定路径
			displayImage.SaveAs(fullPath);
			//imageObjects.Add(new { GameId = gameId, DisplayIamge = fileName });
			//}

			// 返回新的文件名，可以用于记录到数据库或其他用途
			//return imageObjects;
		}

		public void UploadDisplayVideoFile(HttpPostedFileBase displayVideos, string path, int developerId)
		{
			// 判断是否有上传文件，若没有，抛出异常
			if (displayVideos == null || displayVideos.ContentLength == 0)
				throw new ArgumentNullException("file");

			// 获取文件的扩展名，并检查是否为允许的文件类型
			string[] allowedExtensions = { ".mp4", ".webm" };
			string ext = Path.GetExtension(displayVideos.FileName).ToLower();
			if (!allowedExtensions.Contains(ext))
				throw new ArgumentException($"不允許上傳此類檔案({ext})");


			// 使用开发商的ID创建文件夹路径
			string developerFolderPath = Path.Combine(path, $"{developerId}");

			// 检查文件夹是否存在，如果不存在则创建
			if (!Directory.Exists(developerFolderPath))
			{
				Directory.CreateDirectory(developerFolderPath);
			}

			//檢查developerGameFolderPath是否存在，不存在則創建
			//string developerGameFolderPath = Path.Combine(path, $"{developerId}", $"{gameId}");

			//if (!Directory.Exists(developerGameFolderPath))
			//{
			//	Directory.CreateDirectory(developerGameFolderPath);
			//}

			// 合并文件名和路径生成完整的文件路径
			string fileName = displayVideos.FileName;
			string fullPath = Path.Combine(developerFolderPath, fileName);

			// 将上传的文件保存到指定路径
			displayVideos.SaveAs(fullPath);

			// 返回新的文件名，可以用于记录到数据库或其他用途
			//return fullPath;
			//return fileName;
		}
	}
}