using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Dtos
{
    public class EmployeeDto : BaseDto
    {
        public string UserName { get; set; }
        public string Competence { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
