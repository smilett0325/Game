using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
	public class DiscountEFRepository : IDiscountRepository
	{
		public void Create(DiscountEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<DiscountEventEntity> GetAllEvent()
		{

			return DiscountEventExts.DbToEntity();
		}

		public List<DiscountEntity> GetEventDetail(int eventId)
		{

			return DiscountExts.DbToEntity(eventId);
		}

		public DiscountItemEntity GetEventItem(int eventId)
		{
			return DiscountItemExts.DbToEntity(eventId);
		}

		//public List<DiscountEntity> GetAll(int id)
		//{
		//          var db = new AppDbContext();

		//	return db.DiscountItems.AsNoTracking()
		//              .Where(x => x.GameId == id)
		//		.Join(
		//				db.Discounts,
		//				di => di.DiscountId,
		//				d => d.Id,
		//				(di, d) => d
		//			)
		//		.Select(x => new DiscountEntity
		//              {
		//                  Id = x.Id,
		//			GameId = x.GameId,
		//			DiscountId = x.DiscountId
		//		})
		//              .ToList();
		//}


		public void Update(DiscountEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}