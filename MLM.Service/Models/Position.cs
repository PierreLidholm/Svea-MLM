using MLM.Service.Interfaces;

namespace MLM.Service.Models
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}