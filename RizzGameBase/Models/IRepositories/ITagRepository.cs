using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGameBase.Models.IRepositories
{
	public interface ITagRepository
	{
		void Create(TagEntity entity);

		TagEntity Search(int id);

		List<TagEntity> Filter(Func<Tag, bool> condition = null);

		void Update(TagEntity entity);

		void Delete(int id);
	}
}
