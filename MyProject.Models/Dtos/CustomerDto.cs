using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Dtos
{
    public class CustomerDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
