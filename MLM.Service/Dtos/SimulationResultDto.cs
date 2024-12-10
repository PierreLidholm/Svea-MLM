using MLM.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Service.Dtos
{
  public class SimulationResultDto
  {
    public SimulationResult SimulationResult { get; set; }
    public double AverageTime { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }

    public SimulationResultDto(SimulationResult SimulationResult, double AverageTime, int columns, int rows)
    {
      this.SimulationResult = SimulationResult;
      this.AverageTime = AverageTime;
      this.Columns = columns;
      this.Rows = rows;
    }
  }
}
