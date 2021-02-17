using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.API.Models.VM
{
    public class IletisimBilgisiAddVM
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int KisiId { get; set; }
    }
}
