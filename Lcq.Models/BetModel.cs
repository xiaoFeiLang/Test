using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcq.Models
{
    public class BetModel
    { 
        public string userId { get; set; }
        public int before { get; set; }
        public int after { get; set; }  
        public int input { get; set; }
        public int salary { get; set; }
    }
}
