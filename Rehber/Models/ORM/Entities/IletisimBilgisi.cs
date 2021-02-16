using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.API.Models.ORM.Entities
{
    public class IletisimBilgisi : BaseEntity
    {
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public int KisiID { get; set; }

        [ForeignKey("KisiID")]
        public Kisi Kisi { get; set; }
    }
}
