using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Model
{
    public class Employees 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Competence { get; set; }
        public int Id { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public DateTime? DeleteOn { get; set; }
        public virtual ICollection<KPIs> KPIs { get; set; }
        public IList<AdminEmployees> AdminEmployees { get; set; }
    }
}
