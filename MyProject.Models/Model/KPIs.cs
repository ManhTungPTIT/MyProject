using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Model
{
    public class KPIs
    {
        public string Revenue { get; set; }
        public int DayOfMonth { get; set; }
        public int Id { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
