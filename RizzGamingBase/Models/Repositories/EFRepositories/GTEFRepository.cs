using Microsoft.Ajax.Utilities;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
	public class GTEFRepository : IGTRepository
	{
		AppDbContext db = new AppDbContext();
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
				.AsEnumerable()
				.Select(g => g.EFToEntity())
				.ToList();
		}

		public List<GTEntity> GetGameTags(int id)
		{
			return db.GameTags.AsNoTracking()
				.Where(g=> g.GameId == id)
				.AsEnumerable()
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

			model.TagId = entity.TagId;
			model.GameId = entity.GameId;

			db.SaveChanges();
		}
	}
}