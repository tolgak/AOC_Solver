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

  public class LineSegment 
  {
    public int X1 { get; set; }
    public int Y1 { get; set; }

    public int X0 { get; set; }
    public int Y0 { get; set; }

    //public decimal A => (this.Y0 - this.Y1);
    //public decimal B => -(this.X0 - this.X1);
    //public decimal C => (this.X0 - this.X1) * this.Y0 - (this.Y0 - this.Y1) * this.X0;

  }




  public class Problem_01 : IProblem
  {
    public int Day() => 1;

    private Position _position = new();
    private List<Position> Positions { get; set; } = new();
    private List<LineSegment> LineSegments { get; set; } = new();


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
      //for (int i = 0; i < this.Positions.Count; i += 2)
      //{
      //  this.LineSegments.Add( this.GetLineSegment(this.Positions[i], this.Positions[i+1]) );
      //}

      //var l1 = this.GetLineSegment(0, 0, 8, 0);
      //var l2 = this.GetLineSegment(4, -4, 4, 4);
      //var isIntersecting = l1.IsIntersecting(l2);
      //var result = l1.Intersection(l2);

      //return $"{isIntersecting} {result}";

      return Utils.DoIntersect(new Point(0, 0), new Point(8, 0), new Point(4, -4), new Point(4, 4)) ? "YES" : "NO";
    }

    private LineSegment GetLineSegment(int x0, int y0, int x1, int y1)
    {
      return new LineSegment { X0 = x1, Y0 = y0, X1 = x1, Y1 = y1 };
    }

    private LineSegment GetLineSegment(Position p0, Position p1)
    {
      return new LineSegment { X0 = p0.X, Y0 = p0.Y, X1 = p1.X, Y1 = p1.Y };
    }

    public string Log() 
    {
      var sb = new StringBuilder();
      this.Positions.ForEach(x => sb.AppendLine(x.ToString()));

      return sb.ToString();
    }



  }
}
