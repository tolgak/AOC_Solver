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
  }

  public class Problem_01 : IProblem
  {
    public int Day() => 1;
    private Position _position = new();
    private List<Position> Positions { get; set; } = new List<Position>();

    //private Dictionary<Direction, int> Frontier = new();

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
      //this.Frontier.Clear();
      //this.Frontier.Add(Direction.N, 0);
      //this.Frontier.Add(Direction.E, 0);
      //this.Frontier.Add(Direction.S, 0);
      //this.Frontier.Add(Direction.W, 0);

      this.Positions.Clear();
      this.Positions.Add(_position);

      var result = this.Solve_Part1(input);
      if (part == 1)
        return result;

      return this.Solve_Part2(String.Empty);
    }

    private string Solve_Part1(string input)
    {
      var m = Regex.Matches(input, @"(?<Dir>\w)(?<Amp>\d{1,3})");
      var instructions = m.Select(x => new Tuple<string, string>(x.Groups["Dir"].ToString(), x.Groups["Amp"].ToString())).ToList();
      instructions.ForEach(x =>
      {
        this.Move(x);
        this.Positions.Add(_position);

        //this.Frontier[_position.Facing] = _position.Facing switch
        //{ 
        //  Direction.N => Math.Max(this.Frontier[_position.Facing], _position.Y),
        //  Direction.E => Math.Max(this.Frontier[_position.Facing], _position.X),
        //  Direction.S => Math.Min(this.Frontier[_position.Facing], _position.Y),
        //  Direction.W => Math.Min(this.Frontier[_position.Facing], _position.X),
        //  _ => 0
        //};

      });

      return (Math.Abs(_position.X) + Math.Abs(_position.Y)).ToString();
    }

    private string Solve_Part2(string input)
    {


      return 0.ToString();
    }

    public string Log() 
    {
      var sb = new StringBuilder();
      this.Positions.ForEach(x => sb.AppendLine(x.ToString()));

      return sb.ToString();
    }



  }
}
