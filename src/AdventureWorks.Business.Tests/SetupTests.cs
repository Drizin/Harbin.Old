using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Tests
{
    [SetUpFixture]
    public class SetupTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Logging.SetupLog();
            resolver = new DependencyResolver();
            Harbin.Common.TypeSafeEnums.TypeSafeDapper.RegisterDapperConverters(typeof(AdventureWorks.Business.Entities.Person).Assembly);
        }

        public static DependencyResolver resolver;

    }
}
