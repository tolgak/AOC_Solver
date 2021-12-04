using AOC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2016
{
  public class Problem_06 : IProblem
  {
    private StringBuilder _logger = new();
    private int[,] _freq = new int[8, 26];

    public int Day() => 6;

    public string Log(int part)
    {
      return _logger.ToString();
    }

    public string Solve(int part, string input)
    {
      _logger.Clear();
      var items = input.Split(Environment.NewLine);
      for (int i = 0; i < items.Length; i++)
      {
        for (int j = 0; j < items[i].Length; j++)
        {
           int index = items[i].ElementAt(j) - 97;
          _freq[j, index] += 1;
        }
      }

      if (part == 1)
        return this.Solve_Part1();

      return this.Solve_Part2();
    }

    private string Solve_Part1(string input = "")
    {
      var word = string.Empty;      
      for (int j = 0; j < _freq.GetLength(0); j++)
      {
        var row = Matrix<int>.GetRow(_freq, j);
        var value = Array.IndexOf(row, row.Max());
        word += (char) (value + 97);
      }

      return word;
    }

    private string Solve_Part2(string input = "")
    {
      var word = string.Empty;
      for (int j = 0; j < _freq.GetLength(0); j++)
      {
        var row = Matrix<int>.GetRow(_freq, j);
        var value = Array.IndexOf(row, row.Min());
        word += (char)(value + 97);
      }

      return word;
    }


  }
}
