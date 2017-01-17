using System;
using System.Text;

using NFX;
using NFX.Environment;
using NFX.Serialization.JSON;

namespace NFX.Wave.Benchmarks.Handlers
{
  public class JsonHandler : WorkHandler
  {
    protected JsonHandler(WorkDispatcher dispatcher, IConfigSectionNode confNode) : base(dispatcher, confNode) { }

    protected override void DoHandleWork(WorkContext work)
    {
      work.Response.WriteJSON(new { message = "Hello World!" }, JSONWritingOptions.Compact);
    }
  }
}
