using AOC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2016
{
  public class Problem_02 : IProblem
  {
    private StringBuilder _logger = new();

    private string[,] _keypad1 = new string[,] { { "1", "2", "3" }
                                               , { "4", "5", "6" }
                                               , { "7", "8", "9" } 
    };

    private string[,] _keypad2 = new string[,] { { "0", "0", "1", "0", "0" }
                                               , { "0", "2", "3", "4", "0" }
                                               , { "5", "6", "7", "8", "9" }
                                               , { "0", "A", "B", "C", "0" }
                                               , { "0", "0", "D", "0", "0" }
    };

    private Point _position;
    private int j;

    public int Day() => 2;

    public string Log(int part)
    {
      return _logger.ToString();
    }

    private void Move_1(string instruction)
    {
      _position = instruction switch
      {
        "U" when _position.Y > 0 => new Point(_position.X, _position.Y - 1),
        "D" when _position.Y < 2 => new Point(_position.X, _position.Y + 1),
        "L" when _position.X > 0 => new Point(_position.X - 1, _position.Y),
        "R" when _position.X < 2 => new Point(_position.X + 1, _position.Y),
        _ => _position,
      };

      _logger.AppendLine($"{instruction} {_position} {_keypad1[_position.Y, _position.X]}");
    }

    private void Move_2(string instruction)
    {
      var nextPosition = new Point(_position.X, _position.Y);
      nextPosition = instruction switch
      {
        "U" when nextPosition.Y > 0 => new Point(nextPosition.X, nextPosition.Y - 1),
        "D" when nextPosition.Y < 4 => new Point(nextPosition.X, nextPosition.Y + 1),
        "L" when nextPosition.X > 0 => new Point(nextPosition.X - 1, nextPosition.Y),
        "R" when nextPosition.X < 4 => new Point(nextPosition.X + 1, nextPosition.Y),
        _ => nextPosition,
      };

      if (_keypad2[nextPosition.Y, nextPosition.X] != "0")
        _position = nextPosition;


      _logger.AppendLine($"{instruction} {_position} {_keypad2[_position.Y, _position.X]}");
    }

    public string Solve(int part, string input)
    {
      _logger.Clear();
      var digits = input.Split(Utils.trimChars, StringSplitOptions.TrimEntries);

      if (part == 1)
        return this.Solve_Part1(digits);

      return this.Solve_Part2(digits);
    }

    private string Solve_Part1(string[] digits)
    {
      _position = new Point(1, 1); // center upper left, position for button 5 on keypad1
      string combination = string.Empty;

      foreach (var chunk in digits)
      {
        var m = Regex.Matches(chunk, @"(?<Dir>\w)");
        var instructions = m.Select(x => x.Groups["Dir"].ToString()).ToList();
        instructions.ForEach(x => {
          this.Move_1(x);
        });

        combination += _keypad1[_position.Y, _position.X].ToString();
      }

      return combination;
    }

    private string Solve_Part2(string[] digits)
    {
      _position = new Point(0, 2); // center upper left, position for button 5 on keypad2
      string combination = string.Empty;

      foreach (var chunk in digits)
      {
        var m = Regex.Matches(chunk, @"(?<Dir>\w)");
        var instructions = m.Select(x => x.Groups["Dir"].ToString()).ToList();
        instructions.ForEach(x => {
          this.Move_2(x);
        });

        combination += _keypad2[_position.Y, _position.X].ToString();
      }

      return combination;
    }







  }
}
