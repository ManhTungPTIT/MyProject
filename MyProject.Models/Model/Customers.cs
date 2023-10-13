using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Model
{
    public class Customers 
    {
        public int Id { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public DateTime? DeleteOn { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public IList<AdminCustomers> AdminCustomers { get; set; } 
    }
}
