using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Tests
{
    [SetUpFixture]
    class SetupTests
    {
        public void Setup()
        {
            Harbin.Common.TypeSafeEnums.TypeSafeDapper.RegisterDapperConverters(typeof(AdventureWorks.Business.Entities.Person).Assembly);
        }
    }
}
