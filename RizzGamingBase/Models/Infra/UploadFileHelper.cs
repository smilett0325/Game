using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;

namespace RizzGamingBase.Models.Infra
{
	public class UploadFileHelper
	{
		public void UploadCoverFileToScratch(HttpPostedFileBase cover)
		{
			// 判断是否有上传文件，若没有，抛出异常
			if (cover == null || cover.ContentLength == 0)
				throw new ArgumentNullException("file");

			// 获取文件的扩展名，并检查是否为允许的文件类型
			string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
			string ext = Path.GetExtension(cover.FileName).ToLower();
			if (!allowedExtensions.Contains(ext))
				throw new ArgumentException($"不允許上傳此類檔案({ext})");

			// 合并文件名和路径生成完整的文件路径
			string absolutePath = HostingEnvironment.MapPath("/Images/Scratch/Cover");

			string fileName = cover.FileName;
			string fullPath = Path.Combine(absolutePath, fileName);


			// 将上传的文件保存到指定路径
			cover.SaveAs(fullPath);
		}

		public void UploadDisplayImageFile(HttpPostedFileBase displayImage, int developerId, int gameId)
		{
			//var imageObjects = new List<object>();

			//foreach (var file in displayImage)
			//{
			// 判断是否有上传文件，若没有，抛出异常

			string absolutePath = HostingEnvironment.MapPath("/Images/DisplayImages");

			if (displayImage == null || displayImage.ContentLength == 0)
				throw new ArgumentNullException("file");

			// 获取文件的扩展名，并检查是否为允许的文件类型
			string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
			string ext = Path.GetExtension(displayImage.FileName).ToLower();
			if (!allowedExtensions.Contains(ext))
				throw new ArgumentException($"不允許上傳此類檔案({ext})");

			// 使用开发商的ID创建文件夹路径
			string developerFolderPath = Path.Combine(absolutePath, $"{developerId}");

			// 检查文件夹是否存在，如果不存在则创建
			if (!Directory.Exists(developerFolderPath))
			{
				Directory.CreateDirectory(developerFolderPath);
			}

			//檢查developerGameFolderPath是否存在，不存在則創建
			string developerGameFolderPath = Path.Combine(developerFolderPath, $"{gameId}");

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
		}

		public void UploadDisplayVideoFileToScratch(HttpPostedFileBase displayVideos)
		{
			// 判断是否有上传文件，若没有，抛出异常
			if (displayVideos == null || displayVideos.ContentLength == 0)
				throw new ArgumentNullException("file");

			// 获取文件的扩展名，并检查是否为允许的文件类型
			string[] allowedExtensions = { ".mp4", ".webm" };
			string ext = Path.GetExtension(displayVideos.FileName).ToLower();
			if (!allowedExtensions.Contains(ext))
				throw new ArgumentException($"不允許上傳此類檔案({ext})");


			// 合并文件名和路径生成完整的文件路径
			string absolutePath = HostingEnvironment.MapPath("/Images/Scratch/DisplayVideo");

			string fileName = displayVideos.FileName;
			string fullPath = Path.Combine(absolutePath, fileName);

			// 将上传的文件保存到指定路径
			displayVideos.SaveAs(fullPath);
		}

		public void MoveCoverFromScratch(string fileName,int developerId ,int gameId)
		{
			//相對跟路徑
			string absolutePath = HostingEnvironment.MapPath("/Images");

			//根路徑/圖片/開發商id資料夾
			string developerFolderPath = Path.Combine(absolutePath, "Covers", $"{developerId}");

			//检查文件夹是否存在，如果不存在则创建
			if (!Directory.Exists(developerFolderPath)) 
				Directory.CreateDirectory(developerFolderPath);

			//根路徑/圖片/開發商id/遊戲id資料夾
			string developerGameFolderPath = Path.Combine(developerFolderPath , $"{gameId}");

			//檢查developerGameFolderPath是否存在，不存在則創建
			if (!Directory.Exists(developerGameFolderPath))
				Directory.CreateDirectory(developerGameFolderPath);

			//暫存封面路徑
			string scratchPath = Path.Combine(absolutePath, "Scratch\\Cover", fileName);

			//實際搬移路徑
			string destinationAbsolutePath = Path.Combine(developerGameFolderPath, fileName);

			File.Move(scratchPath, destinationAbsolutePath);
		}

		public void MoveVideoFromScratch(string fileName, int developerId, int gameId)
		{
			string absolutePath = HostingEnvironment.MapPath("/Images");

			//根路徑/影片/開發商id資料夾
			string developerFolderPath = Path.Combine(absolutePath, "DisplayVideos", $"{developerId}");

			//检查文件夹是否存在，如果不存在则创建
			if (!Directory.Exists(developerFolderPath))
				Directory.CreateDirectory(developerFolderPath);

			//根路徑/影片/開發商id/遊戲id資料夾
			string developerVideoFolderPath = Path.Combine(developerFolderPath, $"{gameId}");

			//檢查developerGameFolderPath是否存在，不存在則創建
			if (!Directory.Exists(developerVideoFolderPath))
				Directory.CreateDirectory(developerVideoFolderPath);

			//暫存封面路徑
			string scratchPath = Path.Combine(absolutePath, "Scratch\\DisplayVideo", fileName);

			//實際搬移路徑
			string destinationAbsolutePath = Path.Combine(developerVideoFolderPath, fileName);

			File.Move(scratchPath, destinationAbsolutePath);
		}

		public void DeleteFile(string path)

		{

		}
		//File.Delete(fullPath);
	}
}