using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPro.Domain.Models
{
    public class WorkHours : BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? RealStartDate { get; set; }

        public DateTime? RealEndDate { get; set; }
    }
}
