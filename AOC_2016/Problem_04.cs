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

    private string _cc = string.Empty;
    public string ComputedChecksum
    {
      get
      {
        if (string.IsNullOrEmpty(_cc))
          _cc = this.ComputeChecksum();
        return _cc;
      }
    }

    private string _dn = string.Empty;
    public string DecryptedName
    { 
      get 
      { 
        if (string.IsNullOrEmpty(_dn)) 
          _dn = this.DecryptName(); 
        return _dn; 
      } 
    }

    private string DecryptName()
    {
      var asciiBytes = Encoding.ASCII.GetBytes(this.Name.Replace("-", " "));
      var asciiIncremented = asciiBytes.Select(x => x switch {
        122 => 97,
        32 => 32,
         _ => x + (this.Id % 26)});

      var decrypted = string.Join("", asciiIncremented.Select(x => (char) x));
      return decrypted;
    }


    //private char Shift()

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



    private string Solve_Part2(string[] roomLabels)
    {
      List<Room> rooms = new();
      foreach (var label in roomLabels)
      {
        var m = Regex.Matches(label, @"(?<name>[\w-]+)-(?<id>\d+)\[(?<checksum>\w*)\]");
        var room = m.Select(x => new Room()
        {
          Name = x.Groups["name"].Value,
          Id = x.Groups["id"].Value.ToIntDef(),
          Checksum = x.Groups["checksum"].Value
        }).ToList();
        rooms.AddRange(room);
      }
      rooms.ToList().ForEach(x => _logger.AppendLine(x.DecryptedName));
      rooms.Where(x => x.Valid).ToList().ForEach( x => _logger.AppendLine(x.DecryptedName));
      var summedId = rooms.Where(x => x.Valid).Sum(x => x.Id);

      return $"{summedId}";
    }

  }
}
