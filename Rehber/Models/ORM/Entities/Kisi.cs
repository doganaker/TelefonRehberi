using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.API.Models.ORM.Entities
{
    public class Kisi : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<IletisimBilgisi> IletisimList { get; set; }
    }
}
