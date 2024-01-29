using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
	public interface IDiscountRepository
	{
		List<DiscountEventEntity> GetAllEvent();
		List<DiscountEntity> GetEventDetail(int eventId);
		DiscountItemEntity GetEventItem(int eventId);
		void Create(DiscountEntity entity);
		void Update(DiscountEntity entity);
		void Delete(int id);

	}
}
