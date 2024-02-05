using Microsoft.Ajax.Utilities;
using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Infra;
using RizzGamingBase.Models.Interfaces;
using RizzGamingBase.Models.Repositories.EFRepositories;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Services
{
	public class GameService
	{
		private IGameRepository _repo;

		public GameService(IGameRepository repo)
		{
			_repo = repo;
		}
		public void Save(DeveloperGameEditVm vm, int developerId, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImages, HttpPostedFileBase displayVideo, string[] selectedTags, string[] attachedGame, string[] originalImages)
		{
			var iRepo = new ImageEFRepository();
			var gRepo = new GTEFRepository();
			var dlcRepo = new DLCEFRepository();
			var uploadFileHelper = new UploadFileHelper();

			var game = new GameDto();

			var originalGame = _repo.Search(vm.Id);
			//update gmae
			game.Id = vm.Id;
			game.Name = vm.Name;
			game.Introduction = vm.Introduction;
			game.Description = vm.Description;
			game.ReleaseDate = vm.ReleaseDate;
			game.Price = vm.Price;
			game.DeveloperId = vm.DeveloperId;
			game.MaxPercent = vm.MaxPercent;
			game.Cover = cover != null ? cover.FileName : originalGame.Cover;
			game.Video = displayVideo != null ? displayVideo.FileName : originalGame.Video;

			var updatedGame = game.DtoToEntity();
			_repo.Update(updatedGame);

			string[] imgAllowedExtensions = { ".jpg", ".jpeg", ".png" };
			string[] vdoAllowedExtensions = { ".mp4", ".webm" };

			if (cover != null)
			{ 
				uploadFileHelper.DeleteFile("Covers", vm.DeveloperId, vm.Id, originalGame.Cover);
				uploadFileHelper.UploadFile(cover, "Covers", vm.DeveloperId, vm.Id, imgAllowedExtensions);
			}

			if (displayVideo != null)
			{
				uploadFileHelper.DeleteFile("DisplayVideos", vm.DeveloperId, vm.Id, originalGame.Video);
				uploadFileHelper.UploadFile(displayVideo, "DisplayVideos", vm.DeveloperId, vm.Id, vdoAllowedExtensions);
			}

			//Update image
			List<string> dataImageString = new List<string>();
			var dataImageList = iRepo.GetAll(vm.Id);
			foreach (var data in dataImageList) dataImageString.Add(data.DisplayImage); //get dat

			//刪除圖片
			List<string> undeletedImages = originalImages.ToList();

			var deleteImages = dataImageString.Except(undeletedImages).ToList();
			dataImageList.Where(x => deleteImages.Contains(x.DisplayImage)).ToList().ForEach(i => iRepo.Delete(i.Id));
			//deleteImages.ForEach(item => uploadFileHelper.DeleteFile("DisplayImages", developerId, vm.Id, item));
			foreach (var di in deleteImages)
			{
				uploadFileHelper.DeleteFile("DisplayImages", vm.DeveloperId, vm.Id, di);
			}
			string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

			//新增圖片
			if (displayImages != null)
			{
				foreach (var di in displayImages)
				{
					uploadFileHelper.UploadFile(di, "DisplayImages", vm.DeveloperId, vm.Id, allowedExtensions);//, displayImagePath
					var image = new ImageEntity
					{
						GameId = vm.Id,
						DisplayImage = di.FileName,
					};

					iRepo.Create(image);
				};
			}

			//Update or Create gt
			var dataTagList = gRepo.GetGameTags(vm.Id);
			List<string> dataTagStrings = dataTagList.Select(data => data.TagId.ToString()).ToList();

			var selectedTagList = selectedTags.ToList();

			var intersectTags = dataTagStrings.Intersect(selectedTagList);

			if(intersectTags.Count() == 0)
			{
				foreach (var item in dataTagList)
				{
					gRepo.Delete(item.Id);
				}
				foreach (var item in selectedTagList)
				{
					var gt = new GTEntity
					{
						GameId = vm.Id,
						TagId = Convert.ToInt32(item),
					};
					gRepo.Create(gt);
				}
			}
			else
			{
				var tagsToAdd = selectedTagList.Except(dataTagStrings);
				var tagsToDelete = dataTagStrings.Except(selectedTagList);

				if (tagsToAdd.Count() > 0)
				{

					foreach (var item in tagsToAdd)
					{
						var gt = new GTEntity
						{
							GameId = vm.Id,
							TagId = Convert.ToInt32(item),
						};
						gRepo.Create(gt);
					}
				}

				// 要删除的标签

				if (tagsToDelete.Count() > 0)
				{

					foreach (var item in tagsToDelete)
					{
						var deletetag = dataTagList
								.Where(x => string.Equals(x.TagId.ToString(), item, StringComparison.OrdinalIgnoreCase))
								.Select(tag => tag.Id)
								.FirstOrDefault(); 
						//var deletetag = dataTagList.Where(x => x.TagId == Convert.ToInt32(item)).Select(tag => tag.Id).FirstOrDefault();
						gRepo.Delete(deletetag);
					}
				}
			}

			//Update or Create dlc
			var dataDLC = dlcRepo.SearchByGameId(vm.Id);
			//var empty = "";		


			foreach (var item in attachedGame)
			{
				if(item == "none")
				{
					dlcRepo.Delete(dataDLC.Id);
				}else 
				{
					if (dataDLC != null && dataDLC.AttachedGameId != Convert.ToInt32(item))
					{
						var dlc = new DLCEntity
						{
							GameId = vm.Id,
							AttachedGameId = Convert.ToInt32(item),
						};
						dlcRepo.Update(dlc);
					}
				}
			};
		}

		//public void Create(DeveloperGameEditVm vm, int developerId, string displayImagePath, string coverScratchPath, string displayVideoScratchPath, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImages, HttpPostedFileBase displayVideo, string[] selectedTags, string[] attachedGame)
		public void Create(DeveloperGameEditVm vm, int developerId, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImages, HttpPostedFileBase displayVideo, string[] selectedTags, string[] attachedGame)
		{
			var iRepo = new ImageEFRepository();
			var gtRepo = new GTEFRepository();
			var dlcRepo = new DLCEFRepository();
			var uploadFileHelper = new UploadFileHelper();

			var game = new GameDto
			{
				Name = vm.Name,
				Introduction = vm.Introduction,
				Description = vm.Description,
				ReleaseDate = vm.ReleaseDate,
				Price = vm.Price,
				//DeveloperId = vm.DeveloperId,
				DeveloperId = developerId,
				MaxPercent = vm.MaxPercent,
				Cover = cover.FileName,
				Video = displayVideo.FileName,
			};

			int gameId = _repo.Create(game.DtoToEntity());
			uploadFileHelper.UploadFile(cover, "Covers", developerId, gameId, new string[] { ".jpg", ".jpeg", ".png" });
			uploadFileHelper.UploadFile(displayVideo, "DisplayVideos", developerId, gameId, new string[] { ".mp4" , ".webm"});

			//Create image
			var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png"};

			foreach (var di in displayImages)
			{
				var image = new ImageEntity
				{
					GameId = gameId,
					DisplayImage = di.FileName,
				};

				uploadFileHelper.UploadFile(di, "DisplayImages", developerId, gameId, allowedExtensions);
				iRepo.Create(image);
			};

			//Update or Create gt

			foreach (var tag in selectedTags)
			{
				var gt = new GTEntity
				{
					GameId = gameId,
					TagId = Convert.ToInt32(tag),
				};
				gtRepo.Create(gt);
			};

			//Update or Create dlc
			if (attachedGame != null)
			{
				foreach (var item in attachedGame)
				{
					if(item != "none")
					{
						var dlc = new DLCEntity
						{
							GameId = Convert.ToInt32(item),
							AttachedGameId = gameId,
						};
						dlcRepo.Create(dlc);
					};
				};
			};
		}

		public GameDto Search(int id)
		{
			return _repo.Search(id).EntityToDto();
		}

		public List<GameDto> Filter(Func<Game, bool> condition = null)
		{
			return _repo.Filter(condition).EntityToDto();
			//         var data = _repo.Filter();

			//         var result = new List<GameDto>();

			//         foreach (var item in data)
			//{
			//	result.Add(item.EntityToDto());
			//         }

			//         return result;
		}

		public List<GameDto> FilterByDeveloper(int? developerId)
		{
			var data = _repo.Filter(g => g.DeveloperId == developerId);

			var result = new List<GameDto>();

			foreach (var item in data)
			{
				result.Add(item.EntityToDto());
			}

			return result;
		}

		public List<GameDto> FilterByDiscount(int discountId)
		{
			var db = new AppDbContext();

			return db.DiscountItems.AsNoTracking()
				.Where(g => g.DiscountId == discountId)
				.Include(g => g.Game)
				.Select(g => new GameDto
				{
					Id = g.GameId,
					Name = g.Game.Name,
					Introduction = g.Game.Introduction,
					Description = g.Game.Description,
					ReleaseDate = g.Game.ReleaseDate,
					Price = g.Game.Price,
					Cover = g.Game.Cover,
					DeveloperId = g.Game.DeveloperId,
					MaxPercent = g.Game.MaxPercent,
				})
				.ToList();
		}

		public List<GameDto> FilterByTag(int tagId)
		{
			//tagid => gt gameid => game
			var db = new AppDbContext();

			return db.GameTags.AsNoTracking()
				.Where(g => g.TagId == tagId)
				.Include(g => g.Game)
				.Select(g => new GameDto
				{
					Id = g.GameId,
					Name = g.Game.Name,
					Introduction = g.Game.Introduction,
					Description = g.Game.Description,
					ReleaseDate = g.Game.ReleaseDate,
					Price = g.Game.Price,
					Cover = g.Game.Cover,
					DeveloperId = g.Game.DeveloperId,
					MaxPercent = g.Game.MaxPercent,
				})
				.ToList();
		}

		public List<TagDto> GetAllTag()
		{
			TagEFRepository tagRepo = new TagEFRepository();
			var tags = tagRepo.GetAll().ToList();
			List<TagDto> result = new List<TagDto>();

			foreach (var item in tags)
			{
				result.Add(item.EntityToDto());
			}

			return result;
		}

		public List<ImageDto> GetDisplayImages(int id)
		{
			var iRepo = new ImageEFRepository();
			return iRepo.GetAll(id).EntityToDto();
		}

		public List<TagDto> GetSelectedTags(int id)
		{
			var tRepo = new TagEFRepository();
			return tRepo.GetAll(id).Select(x => new TagDto { Id = x.Id, Name = x.Name }).ToList();
		}

		public GameDto GetAttachedGame(int id)
		{
			var attachedGame = _repo.GetAttachedGame(id);
			if (attachedGame != null)
			{
				return attachedGame.EntityToDto();
			}
			return null;
		}
	}
}