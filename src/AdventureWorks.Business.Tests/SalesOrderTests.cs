using System;
using System.Collections.Generic;
using System.Linq;
using AdventureWorks.Business.Entities;
using Harbin.Common.TypeSafeEnums;
using NUnit.Framework;
using AdventureWorksDB = AdventureWorks.Business.Entities.AdventureWorksDB;

namespace AdventureWorks.Business.Tests
{
    [TestFixture]
    public class SalesOrderTests
    {
        [Test]
        public void Test1()
        {
            var service = SetupTests.resolver.Resolve<Services.SalesOrderServices>();
            var order = new Entities.SalesOrderHeader() { };
            Assert.Throws<Exception>(() =>
            {
                var result = service.CreateSalesOrder(order);
            });
        }
        
    }
}
