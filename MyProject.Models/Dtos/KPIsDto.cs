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
        public string Revenue { get; set; }
        
        public int DayOfMonth { get; set; }

        public virtual ICollection<KPIs> Deleted { get; set; }
    }
}
