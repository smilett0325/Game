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

		TagEntity SearchById(int id);

		TagEntity SearchByName(string name);

		void Update(TagEntity entity);

		void Delete(int id);
	}
}
