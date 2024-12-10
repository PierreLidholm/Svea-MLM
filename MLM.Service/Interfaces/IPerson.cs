using MLM.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Service.Interfaces
{
    public interface IPerson
    {
      public bool IsSalesman { get; set; }

      public Position Position { get; set; }
    }
}
