using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Dtos
{
    public class AdminDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Admin> Admins { get; set; } 
    }
}
