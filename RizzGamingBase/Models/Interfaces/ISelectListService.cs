using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RizzGamingBase.Models.Interfaces
{
	public interface ISelectListService
	{
		IEnumerable<ISelectListItem> GetSelectListItems();
	}
}
