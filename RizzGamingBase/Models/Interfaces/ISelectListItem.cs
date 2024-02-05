using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizzGamingBase.Models.Interfaces
{
    public interface ISelectListItem
    {
        int Id { get; set; }
        string DeveloperName { get; set; }

        string GameName { get; set; }
    }
}
