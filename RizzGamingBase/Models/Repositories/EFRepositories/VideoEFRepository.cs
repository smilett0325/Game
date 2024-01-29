using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
	public class VideoEFRepository : IVideoRepository
	{
		AppDbContext db = new AppDbContext();

		public void Create(VideoEntity entity)
		{
			Video model = new Video()
			{
				Id = entity.Id,
				GameId = entity.GameId,
				DisplayVideo = entity.DisplayVideo
			};

			db.Videos.Add(model);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			Video model = db.Videos.Find(id);
			db.Videos.Remove(model);
			db.SaveChanges();
		}


		//public VideoEntity Search(int id)
		//{
		//	return db.Videos.AsNoTracking()
		//		.Where(d => d.Id == id)
		//		.Select(v => new VideoEntity
		//		{
		//			Id = v.Id,
		//			GameId = v.GameId,
		//			DisplayVideo = v.DisplayVideo
		//		})
		//		.FirstOrDefault();
		//}

		//public void Update(VideoEntity entity)
		//{
		//	Video model = db.Videos.Find(entity.Id);

		//	model.GameId = entity.GameId;
		//	model.DisplayVideo = entity.DisplayVideo;

		//	db.SaveChanges();
		//}

		public List<VideoEntity> GetAll(int id)
		{
			return db.Videos.AsNoTracking()
				.Where(d => d.GameId == id)
				.Select(v => new VideoEntity
				{
					Id = v.Id,
					GameId = v.GameId,
					DisplayVideo = v.DisplayVideo
				}).
				ToList();
		}
	}
}