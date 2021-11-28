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
        var lengths = this.MakeIntArray(item);
        if (this.ValidateTriangle(lengths))
          cntValid++;
        else
        {
          cntInvalid++;
          _logger.AppendLine($"{lengths[0]} {lengths[1]} {lengths[2]}");
        }
      }
      
      return $"Valid : {cntValid} | Invalid : {cntInvalid}";
    }

    private bool ValidateTriangle(int[] lengths)
    {
      var result = (lengths[0] < lengths[1] + lengths[2]) 
                && (lengths[1] < lengths[2] + lengths[0])
                && (lengths[2] < lengths[0] + lengths[1]);

      return result;
    }

    private string Solve_Part2(string[] triangles)
    {
      int cntValid = 0;

      for (int i = 0; i <= triangles.Length - 3; i += 3)
      {
        var t = new int[3, 3];
        SetMatrixRow(t, 0, this.MakeIntArray(triangles[i    ]));
        SetMatrixRow(t, 1, this.MakeIntArray(triangles[i + 1]));
        SetMatrixRow(t, 2, this.MakeIntArray(triangles[i + 2]));

        var transposed = Matrix<int>.TransposeMatrix(t);
        var t1 = Matrix<int>.GetRow(transposed, 0);
        if (this.ValidateTriangle(t1))
          cntValid++;

        var t2 = Matrix<int>.GetRow(transposed, 1);
        if (this.ValidateTriangle(t2))
          cntValid++;

        var t3 = Matrix<int>.GetRow(transposed, 2);
        if (this.ValidateTriangle(t3))
          cntValid++;
      }

      return $"Valid: {cntValid}";
    }


    private int[] MakeIntArray(string entry) => entry.Split(trimChars, StringSplitOptions.TrimEntries)
                                                     .Select(x => x.ToIntDef(-99999))
                                                     .Where(x => x > 0)
                                                     .ToArray();

    private void SetMatrixRow(int[,] matrix, int rowIndex, int[] rowArray)
    {
      matrix[rowIndex, 0] = rowArray[0];
      matrix[rowIndex, 1] = rowArray[1];
      matrix[rowIndex, 2] = rowArray[2];
    }




  }
}
