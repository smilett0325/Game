using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
	public class ImageEFRepository : IImageRepository
	{
		AppDbContext db = new AppDbContext();

		public void Create(ImageEntity entity)
		{
			Image model = new Image()
			{
				Id = entity.Id,
				GameId = entity.GameId,
				DisplayImage = entity.DisplayImage
			};

			db.Images.Add(model);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			Image model = db.Images.Find(id);
			db.Images.Remove(model);
			db.SaveChanges();
		}


		//public ImageEntity Search(int id)
		//{
		//	return db.Images.AsNoTracking()
		//		.Where(d => d.Id == id)
		//		.Select(v => new ImageEntity
		//		{
		//			Id = v.Id,
		//			GameId = v.GameId,
		//			DisplayImage = v.DisplayImage
		//		})
		//		.FirstOrDefault();
		//}

		//public void Update(ImageEntity entity)
		//{
		//	Image model = db.Images.Find(entity.Id);

		//	model.GameId = entity.GameId;
		//	model.DisplayImage = entity.DisplayImage;

		//	db.SaveChanges();
		//}

		public List<ImageEntity> GetAll(int id)
		{
			return db.Images.AsNoTracking()
				.Where(d => d.GameId == id)
				.Select(v => new ImageEntity
				{
					Id = v.Id,
					GameId = v.GameId,
					DisplayImage = v.DisplayImage
				}).
				ToList();
		}
	}
}