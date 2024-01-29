using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Services
{
	public class GTService
	{
		private IGTRepository _repo;

		public GTService(IGTRepository repo)
		{
			_repo = repo;
		}
	}
}