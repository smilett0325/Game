using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
	public interface IDLCRepository
	{
		void Create(DLCEntity entity);

		//DLCEntity Search(int id);

		void Update(DLCEntity entity);

		void Delete(int id);
	}
}
