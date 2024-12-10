using MLM.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Service.Interfaces
{
    public interface ISimulationRun
    {
      public int Hours { get; set; }
      public List<GridPerHour> GridPerHour { get; set; }
    }
}