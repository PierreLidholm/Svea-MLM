using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Service.Interfaces
{
    public interface ISimulationResult
    {
        public List<SimulationRun> SimulationRuns { get; set; }
        public double AverageHours { get; set; }
  }
}
