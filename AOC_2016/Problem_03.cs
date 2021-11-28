using AOC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2016
{
  public class Problem_03 : IProblem
  {
    private readonly char[] trimChars = { '\r', '\n', ' ' };

    public StringBuilder _logger = new();
    public int Day() => 3;

    public string Log(int part)
    {
      return _logger.ToString();
    }

    public string Solve(int part, string input)
    {
      _logger.Clear();
      var triangles = input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.TrimEntries);

      if (part == 1)
        return this.Solve_Part1(triangles);

      return this.Solve_Part2(triangles);
    }

    private string Solve_Part1(string[] triangles)
    {
      int cntInvalid = 0;
      int cntValid = 0; 
      foreach (var item in triangles)
      {
        var lengths = item.Split(this.trimChars, StringSplitOptions.TrimEntries)
                          .Select(x => x.ToIntDef(-999999))
                          .Where( x => x > -999999).ToArray();

        if (lengths.Length == 0)
          throw new Exception("chunk is empty");

        if (this.ValidTriangle(lengths))
          cntValid++;
        else
        {
          cntInvalid++;
          _logger.AppendLine($"{lengths[0]} {lengths[1]} {lengths[2]}");
        }
      }
      
      return $"Valid : {cntValid} | Invalid : {cntInvalid}";
    }

    private bool ValidTriangle(int[] lengths)
    {
      var result = (lengths[0] < lengths[1] + lengths[2]) 
                && (lengths[1] < lengths[2] + lengths[0])
                && (lengths[2] < lengths[0] + lengths[1]);

      return result;
    }

    private string Solve_Part2(string[] digits)
    {


      return "";
    }




  }
}
