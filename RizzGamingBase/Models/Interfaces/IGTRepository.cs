using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
	public interface IGTRepository
	{
		void Create(GTEntity entity);

		//GTEntity Search(int id);

		void Update(GTEntity entity);

		void Delete(int id);
	}
}
