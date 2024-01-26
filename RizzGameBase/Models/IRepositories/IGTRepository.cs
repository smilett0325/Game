using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGameBase.Models.IRepositories
{
	public interface IGTRepository
	{
		void Create(GTEntity entity);

		GTEntity Search(int id);

		List<GTEntity> Filter(Func<GameTag, bool> condition = null);

		void Update(GTEntity entity);

		void Delete(int id);
	}
}
