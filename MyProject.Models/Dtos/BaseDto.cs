using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public DateTime? DeleteOn { get; set; }
    }
}
