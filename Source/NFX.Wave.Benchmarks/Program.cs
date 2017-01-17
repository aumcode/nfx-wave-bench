using System;

using NFX;
using NFX.ApplicationModel;
using NFX.IO;

namespace NFX.Wave.Benchmarks
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        using (var app = new ServiceBaseApplication(args, null))
        using (var ws = new WaveServer())
        {
          ws.Configure(null);
          ws.Start();

          Console.WriteLine(ws.Name + " started. Press <ENTER> to terminate...");
          Console.ReadLine();
        }
      }
      catch (Exception error)
      {
        ConsoleUtils.Error(error.ToMessageWithType());
        System.Environment.ExitCode = -1;
      }
    }
  }
}
