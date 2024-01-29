using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
	public interface ITagRepository
	{
		void Create(TagEntity entity);

		List<TagEntity> GetAll();

		TagEntity Search(int id);

		void Update(TagEntity entity);

		void Delete(int id);
	}
}
