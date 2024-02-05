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
        public void UploadFile(HttpPostedFileBase file, string categoryFolderName, int? developerId, string[] allowedExtensions)
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


            // 合并文件名和路径生成完整的文件路径
            string fileName = file.FileName;
            string fullPath = Path.Combine(developerFolderPath, fileName);

            // 将上传的文件保存到指定路径
            file.SaveAs(fullPath);
        }

        public void UploadFile(HttpPostedFileBase file, string categoryFolderName, string[] allowedExtensions)
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



            // 合并文件名和路径生成完整的文件路径
            string fileName = file.FileName;
            string fullPath = Path.Combine(categoryFolderPath, fileName);

            // 将上传的文件保存到指定路径
            file.SaveAs(fullPath);
        }
        public void DeleteFile(string categoryFolderName, int developerId, int gameId, string fileName)
        {
            var fullPath = HostingEnvironment.MapPath($"/Images/{categoryFolderName}/{developerId}/{gameId}/{fileName}");
            File.Delete(fullPath);
        }

        //public void UploadDisplayVideoFileToScratch(HttpPostedFileBase displayVideos)
        //{
        //	// 判断是否有上传文件，若没有，抛出异常
        //	if (displayVideos == null || displayVideos.ContentLength == 0)
        //		throw new ArgumentNullException("file");

        //	// 获取文件的扩展名，并检查是否为允许的文件类型
        //	string[] allowedExtensions = { ".mp4", ".webm" };
        //	string ext = Path.GetExtension(displayVideos.FileName).ToLower();
        //	if (!allowedExtensions.Contains(ext))
        //		throw new ArgumentException($"不允許上傳此類檔案({ext})");


        //	// 合并文件名和路径生成完整的文件路径
        //	string absolutePath = HostingEnvironment.MapPath("/Images/Scratch/DisplayVideo");

        //	string fileName = displayVideos.FileName;
        //	string fullPath = Path.Combine(absolutePath, fileName);

        //	// 将上传的文件保存到指定路径
        //	displayVideos.SaveAs(fullPath);
        //}

        //public void MoveCoverFromScratch(string fileName,int developerId ,int gameId)
        //{
        //	//相對跟路徑
        //	string absolutePath = HostingEnvironment.MapPath("/Images");

        //	//根路徑/圖片/開發商id資料夾
        //	string developerFolderPath = Path.Combine(absolutePath, "Covers", $"{developerId}");

        //	//检查文件夹是否存在，如果不存在则创建
        //	if (!Directory.Exists(developerFolderPath)) 
        //		Directory.CreateDirectory(developerFolderPath);

        //	//根路徑/圖片/開發商id/遊戲id資料夾
        //	string developerGameFolderPath = Path.Combine(developerFolderPath , $"{gameId}");

        //	//檢查developerGameFolderPath是否存在，不存在則創建
        //	if (!Directory.Exists(developerGameFolderPath))
        //		Directory.CreateDirectory(developerGameFolderPath);

        //	//暫存封面路徑
        //	string scratchPath = Path.Combine(absolutePath, "Scratch\\Cover", fileName);

        //	//實際搬移路徑
        //	string destinationAbsolutePath = Path.Combine(developerGameFolderPath, fileName);

        //	File.Move(scratchPath, destinationAbsolutePath);
        //}

        //public void MoveVideoFromScratch(string fileName, int developerId, int gameId)
        //{
        //	string absolutePath = HostingEnvironment.MapPath("/Images");

        //	//根路徑/影片/開發商id資料夾
        //	string developerFolderPath = Path.Combine(absolutePath, "DisplayVideos", $"{developerId}");

        //	//检查文件夹是否存在，如果不存在则创建
        //	if (!Directory.Exists(developerFolderPath))
        //		Directory.CreateDirectory(developerFolderPath);

        //	//根路徑/影片/開發商id/遊戲id資料夾
        //	string developerVideoFolderPath = Path.Combine(developerFolderPath, $"{gameId}");

        //	//檢查developerGameFolderPath是否存在，不存在則創建
        //	if (!Directory.Exists(developerVideoFolderPath))
        //		Directory.CreateDirectory(developerVideoFolderPath);

        //	//暫存封面路徑
        //	string scratchPath = Path.Combine(absolutePath, "Scratch\\DisplayVideo", fileName);

        //	//實際搬移路徑
        //	string destinationAbsolutePath = Path.Combine(developerVideoFolderPath, fileName);

        //	File.Move(scratchPath, destinationAbsolutePath);
        //}


    }
}