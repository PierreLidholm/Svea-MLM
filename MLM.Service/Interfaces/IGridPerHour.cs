using MLM.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Service.Interfaces
{
    public interface IGridPerHour
    {
        public int Hour { get; set; }
        public List<Person> Persons { get; set; }
    }
}


