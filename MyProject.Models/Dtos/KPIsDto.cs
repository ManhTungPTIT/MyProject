using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Dtos
{
    public class KPIsDto : BaseDto
    {
        public decimal Revenue { get; set; }
        public int DayOfMonth { get; set; }
        public int EmployeeId { get; set; }
        public decimal Kpis { get; set; }
        public string EMployeeName { get; set; }

        public ICollection<Employees> Employees { get; set; }
        public virtual ICollection<KPIs> Deleted { get; set; }
    }
}
