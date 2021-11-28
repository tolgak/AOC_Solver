using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Common
{

  public static class Matrix<T>
  {
    public static T[,] TransposeMatrix(T[,] matrix)
    {
      var rows = matrix.GetLength(0);
      var columns = matrix.GetLength(1);

      var result = new T[columns, rows];
      for (var c = 0; c < columns; c++)
      {
        for (var r = 0; r < rows; r++)
        {
          result[c, r] = matrix[r, c];
        }
      }

      return result;
    }
  }


  public static class Utils
  {
    private static readonly char[] trimChars = { '\r', '\n', ' ' };

    public static int ToIntDef(this string x, int defaultValue = 0)
    {
      if (string.IsNullOrEmpty(x))
        return defaultValue;

      return int.TryParse(x.TrimEnd(trimChars).TrimStart(trimChars), out int value) ? value : defaultValue;
    }

    // https://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect
    private static int Orientation(Point p, Point q, Point r)
    {
      // See https://www.geeksforgeeks.org/orientation-3-ordered-points
      int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

      if (val == 0)
        return 0; // collinear

      return (val > 0) ? 1 : 2; // clock or counterclock wise
    }

    private static Boolean OnSegment(Point p, Point q, Point r)
    {
      return q.X <= Math.Max(p.X, r.X)
          && q.X >= Math.Min(p.X, r.X)
          && q.Y <= Math.Max(p.Y, r.Y)
          && q.Y >= Math.Min(p.Y, r.Y);
    }

    public static Boolean DoIntersect(Point p1, Point q1, Point p2, Point q2)
    {
      // Find the four orientations needed for general and special cases
      int o1 = Utils.Orientation(p1, q1, p2);
      int o2 = Utils.Orientation(p1, q1, q2);
      int o3 = Utils.Orientation(p2, q2, p1);
      int o4 = Utils.Orientation(p2, q2, q1);

      // General case
      if (o1 != o2 && o3 != o4)
        return true;

      // Special Cases
      // p1, q1 and p2 are collinear and p2 lies on segment p1q1
      if (o1 == 0 && Utils.OnSegment(p1, p2, q1)) 
        return true;

      // p1, q1 and q2 are collinear and q2 lies on segment p1q1
      if (o2 == 0 && Utils.OnSegment(p1, q2, q1)) 
        return true;

      // p2, q2 and p1 are collinear and p1 lies on segment p2q2
      if (o3 == 0 && Utils.OnSegment(p2, p1, q2)) 
        return true;

      // p2, q2 and q1 are collinear and q1 lies on segment p2q2
      if (o4 == 0 && Utils.OnSegment(p2, q1, q2)) 
        return true;

      return false; // Doesn't fall in any of the above cases
    }


  }
}
