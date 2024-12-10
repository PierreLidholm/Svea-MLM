using MLM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Service.Models
{
    public class SimulationResult : ISimulationResult
    {
      public List<SimulationRun> SimulationRuns { get; set; } = new List<SimulationRun>();
      public double AverageHours { get; set; }
  }
}
