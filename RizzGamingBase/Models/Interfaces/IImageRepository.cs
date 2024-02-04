using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
	public interface IImageRepository
	{
		void Create(ImageEntity entity);

		List<ImageEntity> GetAll(int id);

		//ImageEntity Search(int id);

		//void Update(ImageEntity entity);

		void Delete(int id);
	}
}
