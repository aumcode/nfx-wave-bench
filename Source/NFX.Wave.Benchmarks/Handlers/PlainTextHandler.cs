using System;
using System.Text;

using NFX;
using NFX.Environment;

namespace NFX.Wave.Benchmarks.Handlers
{
  public class PlainTextHandler : WorkHandler
  {
    private static readonly byte[] CONST_HELLO_WORLD = Encoding.UTF8.GetBytes("Hello, World!");

    protected PlainTextHandler(WorkDispatcher dispatcher, IConfigSectionNode confNode) : base(dispatcher, confNode) { }

    protected override void DoHandleWork(WorkContext work)
    {
      var response = work.Response;
      response.ContentType = Web.ContentType.TEXT;

      response.GetDirectOutputStreamForWriting().Write(CONST_HELLO_WORLD, 0, CONST_HELLO_WORLD.Length);
    }
  }
}
