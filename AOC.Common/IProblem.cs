using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Common
{
  public interface IProblem
  {
    int Day();
    string Solve(int part, string input);
    string Log(int part);
  }
}
