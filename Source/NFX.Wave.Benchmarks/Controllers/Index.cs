using System;

using NFX;
using NFX.Wave.MVC;

namespace NFX.Wave.Benchmarks.Controllers
{
  public class Index : Controller
  {
    [Action]
    public object PlainText()
    {
      return "Hello World!";
    }

    [Action]
    public object Json()
    {
      return new { message = "Hello World!" };
    }
  }
}
