using AOC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2016
{
  public class Problem_05 : IProblem
  {
    private StringBuilder _logger = new();

    public int Day() => 5;

    public string Log(int part)
    {
      return _logger.ToString();
    }

    public string Solve(int part, string input)
    {
      _logger.Clear();

      if (part == 1)
        return this.Solve_Part1(input);

      return this.Solve_Part2(input);
    }

    private string Solve_Part1(string input)
    {

      var hash = Utils.CreateMD5(input);
      _logger.AppendLine(hash);

      return hash;
      
    }

    private string Solve_Part2(string input)
    {
      throw new NotImplementedException();
    }


  }
}
