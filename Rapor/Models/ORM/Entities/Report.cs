using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapor.API.Models.ORM.Entities
{
    public class Report
    {
        public int ID { get; set; }

        private DateTime _adddate = DateTime.Now;
        public DateTime AddDate
        {
            get
            {
                return _adddate;
            }
            set
            {
                _adddate = value;
            }
        }

        private bool _isdeleted = false;
        public bool IsDeleted
        {
            get
            {
                return _isdeleted;
            }
            set
            {
                _isdeleted = value;
            }
        }

        private bool _status = false;
        public bool ReportStatus
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public string Address { get; set; }
        public int TotalKisi { get; set; }
        public int TotalPhone { get; set; }
    }
}
