using Rehber.API.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.API.Models.VM
{
    public class KisiDetailVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string company { get; set; }
        public List<IletisimBilgisi> iletisimList { get; set; }
    }
}
