using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyProject.Models.Model
{
    public class Admin 
    {
        public int Id { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        
       
        public string UserName { get; set; }
        
        public string Password { get; set; }
        public string Phone { get; set; }

        public IList<AdminCustomers> AdminCustomers { get; set; }
        public IList<AdminEmployees> AdminEmployees { get; set; }
    }
}
