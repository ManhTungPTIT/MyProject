using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Dtos
{
    public class AdminEmpoloyeeDto : BaseDto
    {
        public int AdminId { get; set; }
        public int EmployeeId { get; set; }

        public virtual AdminDto Admin { get; set; }
        public virtual EmployeeDto Employee { get; set;}
    }
}
