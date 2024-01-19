using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using RizzGameBase.Models.Exts;
using RizzGameBase.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGameBase.Models.Repositories.EFRepository
{
	public class GTEFRepository : IGTRepository
	{
		AppDbContext db;
		public void Create(GTEntity entity)
		{
			GameTag model = entity.EntityToEF();
			db.GameTags.Add(model);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			GameTag model = db.GameTags.Find(id);
			db.GameTags.Remove(model);
			db.SaveChanges();
		}

		public List<GTEntity> Filter(Func<GameTag, bool> condition = null)
		{
			return db.GameTags.AsNoTracking()
				.Where(condition ?? (x => true))
				.Select(g => g.EFToEntity())
				.ToList();
		}

		public GTEntity Search(int id)
		{
			return db.GameTags.AsNoTracking()
				.Where(d => d.Id == id)
				.Select(d => d.EFToEntity())
				.Single();
		}

		public void Update(GTEntity entity)
		{
			GameTag model = db.GameTags.Find(entity.Id);

			entity.GameId = model.GameId;
			entity.TagId = model.TagId;

			db.SaveChanges();
		}
	}
}