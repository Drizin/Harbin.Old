using Serilog;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Tests
{
    class Logging
    {
        public static void SetupLog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithProperty("SourceContext", null)
                .Destructure.ByTransforming<ExpandoObject>(e => new Dictionary<string, object>(e)) // https://stackoverflow.com/questions/48958444/serilog-and-expandoobject
                .WriteTo.Debug(Serilog.Events.LogEventLevel.Verbose)
                .CreateLogger();

        }
    }
}
