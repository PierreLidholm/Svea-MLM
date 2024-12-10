using MLM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLM.Service.Models
{
   public class Person : IPerson
   {
      public bool IsSalesman { get; set; }
      public Position Position { get; set; } = new Position();
      
  }
}
