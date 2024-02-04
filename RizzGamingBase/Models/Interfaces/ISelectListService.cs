using RizzGamingBase.Models.Interfaces;
using System.Collections.Generic;

namespace RizzGamingBase.Controllers
{
    public interface ISelectListService
    {
        IEnumerable<ISelectListItem> GetSelectListItems();

        IEnumerable<ISelectListItem> GetSelectListItemsDeveloper(int id);
    }
}