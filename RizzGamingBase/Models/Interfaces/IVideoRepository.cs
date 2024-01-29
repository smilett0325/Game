using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
	public interface IVideoRepository
	{
		void Create(VideoEntity entity);

		List<VideoEntity> GetAll(int id);

		//ImageEntity Search(int id);

		//void Update(VideoEntity entity);

		void Delete(int id);
	}
}
