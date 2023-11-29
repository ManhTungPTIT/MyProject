using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyProject.Models.Model
{
    public class Employees 
    {
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal Revenue { get; set; }
        public int DayOfMonth { get; set; }
        public decimal Kpis { get; set; }
        public int Id { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public DateTime? DeleteOn { get; set; }
        
        public IList<AdminEmployees> AdminEmployees { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
