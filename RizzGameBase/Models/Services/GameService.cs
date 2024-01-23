using RizzGameBase.Models.Dtos;
using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using RizzGameBase.Models.Exts;
using RizzGameBase.Models.IRepositories;
using RizzGameBase.Models.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGameBase.Models.Services
{
	public class GameService : IGameService
	{
		private IGameRepository _repo;

		public GameService(IGameRepository repo)
		{
			_repo = repo;
		}

		
		public List<GameDto> Filter(Func<Game, bool> condition = null)
		{
			return _repo.Filter().EntityToDto();
			//         var data = _repo.Filter();

			//         var result = new List<GameDto>();

			//         foreach (var item in data)
			//{
			//	result.Add(item.EntityToDto());
			//         }

			//         return result;
		}

		public List<GameDto> FilterByDeveloper(int developerId)
		{
			var data = _repo.Filter(g => g.DeveloperId == developerId);

            var result = new List<GameDto>();

            foreach (var item in data)
            {
                result.Add(item.EntityToDto());
            }

            return result;
        }

		public List<GameDto> FilterByDiscount(int discountId)
		{
            var data = _repo.Filter(g => g.DiscountId == discountId);

            var result = new List<GameDto>();

            foreach (var item in data)
            {
                result.Add(item.EntityToDto());
            }

            return result;
        }

		public List<GameDto> FilterByTag(int tagId)
		{
            var data = _repo.Filter(g => g.GameTagId == tagId);

            var result = new List<GameDto>();

            foreach (var item in data)
            {
                result.Add(item.EntityToDto());
            }

            return result;
        }
	}
}