using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using AOC.Common;

namespace AOC_2016
{
  public enum Direction { N, E, S, W}

  public struct Position
  {
    public Direction Facing { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public override string ToString()
    {
      return $"({this.X}, {this.Y} ) facing {(Direction) this.Facing}";
    }

    public Point ToPoint()
    {
      return new Point(this.X, this.Y);
    }
  }



  public class Problem_01 : IProblem
  {
    public int Day() => 1;

    private Position _position = new();
    private List<Position> Positions { get; set; } = new();

    private StringBuilder _logger = new();

    private void Move(Tuple<string, string> instruction)
    {
      if (instruction.Item1 == "R")
        _position.Facing = _position.Facing switch
        {
          Direction.N => Direction.E,
          Direction.E => Direction.S,
          Direction.S => Direction.W,
          Direction.W => Direction.N,
          _ => throw new NotImplementedException()
        };

      if (instruction.Item1 == "L")
        _position.Facing = _position.Facing switch
        {
          Direction.N => Direction.W,
          Direction.E => Direction.N,
          Direction.S => Direction.E,
          Direction.W => Direction.S,
          _ => throw new NotImplementedException()
        };

      switch (_position.Facing)
      {
        case Direction.N:
          _position.Y += instruction.Item2.ToIntDef();
          break;
        case Direction.E:
          _position.X += instruction.Item2.ToIntDef();
          break;
        case Direction.S:
          _position.Y -= instruction.Item2.ToIntDef();
          break;
        case Direction.W:
          _position.X -= instruction.Item2.ToIntDef();
          break;
        default:
          break;
      }

    }

    public string Solve(int part, string input)
    {
      _logger.Clear();
      this.Positions.Clear();

      var result = this.Solve_Part1(input);
      if (part == 1)
        return result;

      return this.Solve_Part2(string.Empty);
    }

    private string Solve_Part1(string input)
    {
      var m = Regex.Matches(input, @"(?<Dir>\w)(?<Amp>\d{1,3})");
      var instructions = m.Select(x => new Tuple<string, string>(x.Groups["Dir"].ToString(), x.Groups["Amp"].ToString())).ToList();
      instructions.ForEach(x =>
      {
        this.Move(x);
        this.Positions.Add(_position);
      });

      return (Math.Abs(_position.X) + Math.Abs(_position.Y)).ToString();
    }

    private string Solve_Part2(string input)
    {
      _logger.Clear();
      var t_point = new Point();
      var prevPos = new Point();

      HashSet<Point> points = new();
      var result = false;

      foreach (var p in this.Positions)
      {
        switch (p.Facing)
        {
          case Direction.N:
            for (int i = prevPos.Y +1; i <= p.Y; i++)
            {
              t_point = new Point(prevPos.X, i);
              result = points.Add(t_point);
              _logger.AppendLine(t_point.ToString());
              if (!result)
                return t_point.ToString();
            }
            
            break;
          case Direction.E:
            for (int i = prevPos.X + 1; i <= p.X; i++)
            {
              t_point = new Point(i, prevPos.Y);
              result = points.Add(t_point);
              _logger.AppendLine(t_point.ToString());
              if (!result)
                return t_point.ToString();
            }
            break;
          case Direction.S:
            for (int i = prevPos.Y - 1; i >= p.Y; i--)
            {
              t_point = new Point(prevPos.X, i);
              result = points.Add(t_point);
              _logger.AppendLine(t_point.ToString());
              if (!result)
                return t_point.ToString();
            }
            break;
          case Direction.W:
            for (int i = prevPos.X -1; i >= p.X; i--)
            {
              t_point = new Point(i, prevPos.Y);
              result = points.Add(t_point);
              _logger.AppendLine(t_point.ToString());
              if (!result)
                return t_point.ToString();
            }
            break;
          default:
            break;
        }
        prevPos = p.ToPoint();
      }
      
      return "no intersection";
    }


    public string Log(int part) 
    {
      if (part == 1)
        this.Positions.ForEach(x => _logger.AppendLine(x.ToString()));
        
      return _logger.ToString();
    }



  }
}
