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
	public class TagEFRepository : ITagRepository
	{
		AppDbContext db = new AppDbContext();
		public void Create(TagEntity entity)
		{
			Tag model = entity.EntityToEF();
			db.Tags.Add(model);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			Tag model = db.Tags.Find(id);
			db.Tags.Remove(model);
			db.SaveChanges(); ;
		}

		public TagEntity SearchById(int id)
		{
			return db.Tags.AsNoTracking()
				.Where(d => d.Id == id)
				.Select(d => d.EFToEntity())
				.Single();
		}

		public TagEntity SearchByName(string name)
		{
			return db.Tags.AsNoTracking()
				.Where(d => d.Name == name)
				.Select(d => d.EFToEntity())
				.Single();
		}

		public void Update(TagEntity entity)
		{
			Tag model = db.Tags.Find(entity.Id);

			entity.Name = model.Name;

			db.SaveChanges();
		}
	}
}