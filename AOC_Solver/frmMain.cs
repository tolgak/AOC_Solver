using System.Net;
using System.Reflection;
using System.Text;
using HtmlAgilityPack;
using AOC.Common;
using AOC_2016;

namespace AOC_Solver
{
  public partial class frmMain : Form
  {
    private readonly Assembly _solver;

    public frmMain()
    {
      InitializeComponent();
      var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
      _solver = Assembly.LoadFrom($"{path}\\AOC_2016.dll");
    }

    private IProblem GetProblem(int n)
    {
      var problemName = n > 9 ? $"Problem_{n}" : $"Problem_0{n}";
      var problemType = typeof(IProblem);
      var problems = _solver.GetTypes().Where(p => problemType.IsAssignableFrom(p));
      var problem = problems.FirstOrDefault( x=> x.Name == problemName);

      return problem == null ? null : (IProblem) Activator.CreateInstance(problem);
    }

    private async void btnDownload_Click(object sender, EventArgs e)
    {
      var url = "https://adventofcode.com/2016/day/1";
      var web = new HtmlWeb();
      var doc = await web.LoadFromWebAsync(url);
      var node = doc.DocumentNode.SelectSingleNode("//article[@class='day-desc']");

      var sb = new StringBuilder();
      node.ChildNodes.ToList().ForEach( n => sb.AppendLine(n.InnerText) );

      txtLog.Text = sb.ToString(); 
    }

    private void btnSolve_Click(object sender, EventArgs e)
    {
      var input = txtInput.Text;
      var day = (int) spinDay.Value;
      var part = (int) spinPart.Value;

      var problem = this.GetProblem(day);
      var solution = problem.Solve(part, input);

      txtLog.Clear(); 
      txtSolution.Text = solution;

      txtLog.AppendText( problem.Log(part) );
    }


  }
}