using AOC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC_2016
{
  public class Room
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public string Checksum { get; set; }

    public override string ToString()
    {
      return $"Name: {this.Name} Id: {this.Id} Chacecksum: {this.Checksum} Computed: {this.ComputedChecksum}";
    }

    public string ComputedChecksum => this.ComputeChecksum();

    public bool Valid => this.Checksum == ComputedChecksum;

    private string ComputeChecksum()
    {
      var nodash = this.Name.Replace("-", "");

      var stats = nodash.Select(x => new Tuple<char, int>(x, nodash.Count(y => y == x)))
                        .DistinctBy(z => z.Item1)
                        .ToList();

      stats.Sort((x, y) => x.Item2 == y.Item2 ? x.Item1.CompareTo(y.Item1) : y.Item2.CompareTo(x.Item2));

      return string.Join("", stats.Select(x => x.Item1).Take(5));
    }
  }


  public class Problem_04 : IProblem
  {

    private StringBuilder _logger = new();

    public int Day() => 4;

    public string Log(int part)
    {
      return _logger.ToString();
    }

    public string Solve(int part, string input)
    {
      _logger.Clear();
      var roomLabels = input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.TrimEntries);

      if (part == 1)
        return this.Solve_Part1(roomLabels);

      return this.Solve_Part2(roomLabels);
    }

    private string Solve_Part1(string[] roomLabels)
    {
      //var cntValid = 0;
      //var cntInvalid = 0;

      List<Room> rooms = new();

      foreach (var label in roomLabels)
      {
        var m = Regex.Matches(label, @"(?<name>[\w-]+)-(?<id>\d+)\[(?<checksum>\w*)\]");
        var room = m.Select(x => new Room() { Name = x.Groups["name"].Value
                                            , Id = x.Groups["id"].Value.ToIntDef()
                                            , Checksum = x.Groups["checksum"].Value}).ToList();
        rooms.AddRange(room);
      }
      var summedId = rooms.Where(x => x.Valid).Sum(x => x.Id);
      return $"{summedId}";
    }



    private string Solve_Part2(string[] triangles)
    {
      throw new NotImplementedException();
    }

  }
}
