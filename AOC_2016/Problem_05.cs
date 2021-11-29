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
      var password = string.Empty;
      var cntFound = 0;
      var i = 0;

      while (cntFound < 8)
      {
        var hash = Utils.CreateMD5($"{input}{i}");
        if (hash.StartsWith("00000"))
        {
          cntFound++;
          password += hash[5];
          _logger.AppendLine($"{i}   :  {hash}");
        }
        i++;
      }

      return password;
    }

    private string Solve_Part2(string input)
    {
      var password = new char[8] { '_', '_', '_', '_', '_', '_', '_', '_' };
      var cntFound = 0;
      var i = 0;

      while (cntFound < 8)
      {
        var hash = Utils.CreateMD5($"{input}{i}");
        if (hash.StartsWith("00000"))
        {
          var position = hash[5].ToString().ToIntDef(-1);
          if (position > -1 && position < 8 && password[position] == '_')
          {
            cntFound++;
            password[position] = hash[6];
            _logger.AppendLine($"{i}   :  {hash}");
          }
        }
        i++;
      }

      return new string(password);
    }


  }
}
