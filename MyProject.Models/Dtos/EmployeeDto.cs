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
        public decimal Revenue { get; set; }
        public int DayOfMonth { get; set; }
        public decimal Kpis { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public DateTime? DeleteOn { get; set; }
        
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<ProductDto> ProductDtos { get; set; }
    }
}
