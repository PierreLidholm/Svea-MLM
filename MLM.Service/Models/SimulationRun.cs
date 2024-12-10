using MLM.Service.Interfaces;
using MLM.Service.Models;

public class SimulationRun : ISimulationRun
{
    public int Hours { get; set; }
    public List<GridPerHour> GridPerHour { get; set; } = new List<GridPerHour>();
}
