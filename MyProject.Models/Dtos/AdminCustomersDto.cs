using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Dtos
{
    public class AdminCustomersDto : BaseDto
    {
        public int AdminId { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<AdminDto> Admins { get; set; }
        public virtual ICollection<CustomerDto> Customers { get; set; }
    }
}
