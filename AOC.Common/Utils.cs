using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Common
{
  public static class Utils
  {
    public static int ToIntDef(this string x, int defaultValue = 0)
    {
      if (string.IsNullOrEmpty(x))
        return defaultValue;

      int value = 0;
      return int.TryParse(x, out value) ? value : defaultValue;

    }
  }
}
