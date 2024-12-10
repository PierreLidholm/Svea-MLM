using MLM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Service.Models
{
    public class GridPerHour : IGridPerHour
    {
        public int Hour { get; set; }
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
