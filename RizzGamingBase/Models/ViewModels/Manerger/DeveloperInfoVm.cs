using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class DeveloperInfoVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }

        public string Password { get; set; }
        public string Mail { get; set; }
        public string Number { get; set; }
    }
}