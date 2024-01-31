using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RizzGamingBase.Models.Exts
{
	public static class SelectListExts
	{
		public static IEnumerable<SelectListItem> GetSelectListItems(this ISelectListService service)
		{
			var list = service.GetSelectListItems();

			var result = new List<SelectListItem>();

			foreach (var item in list)
			{
				result.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.DeveloperName });
			}

			return result.Prepend(new SelectListItem { Value = "0", Text = "請選擇..." });
		}

		public static SelectList GetSelectList(this ISelectListService service, int id)
		{
			return new SelectList(service.GetSelectListItems(), "Id", "Name", id);
		}
	}
}