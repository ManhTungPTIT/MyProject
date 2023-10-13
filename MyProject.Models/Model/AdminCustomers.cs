using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Model
{
    public class AdminCustomers
    {
        public int Id { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public int CustomerId { get; set; }
        public virtual Customers Customers { get; set; }
        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
