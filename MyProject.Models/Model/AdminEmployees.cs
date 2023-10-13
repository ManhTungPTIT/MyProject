using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Model
{
    public class AdminEmployees 
    {
        public int Id { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employees Employee { get; set; }
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
