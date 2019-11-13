using System;
using System.Linq;
using NUnit.Framework;
using AdventureWorksDB = AdventureWorks.Business.Entities.AdventureWorksDB;
using Harbin.Common.Queries;
using System.Collections.Generic;
using AdventureWorks.Business.Entities;
using Harbin.Common.TypeSafeEnums;
using System.Data.SqlClient;

namespace AdventureWorks.Business.Tests
{
    [TestFixture]
    public class EFQueryTests
    {
        [Test(Description = "Filter table by filtering single Type-Safe-Enum")]
        public void FilterTSE1()
        {
            var db = new AdventureWorksDB();

            // explicit types and inferred types
            var orders = db.SalesOrderHeaders.WhereEnum<SalesOrderHeader, ShipMethodEnum, int>(order => order.ShipMethod, shipMethod => shipMethod == ShipMethodEnum.CARGO_TRANSPORT_5);
            Assert.NotNull(orders);
            Assert.IsNotEmpty(orders);
            orders = db.SalesOrderHeaders.WhereEnum(order => order.ShipMethod, shipMethod => shipMethod == ShipMethodEnum.CARGO_TRANSPORT_5);
            Assert.NotNull(orders);
            Assert.IsNotEmpty(orders);
        }

        [Test(Description = "Filter table by filtering multiple Type-Safe-Enums")]
        public void FilterTSE2()
        {
            var db = new AdventureWorksDB();

            // explicit types and inferred types
            var orders = db.SalesOrderHeaders.WhereEnum<SalesOrderHeader, ShipMethodEnum, int>(order => order.ShipMethod, shipMethod => shipMethod == ShipMethodEnum.CARGO_TRANSPORT_5 || shipMethod == ShipMethodEnum.OVERNIGHT_J_FAST);
            Assert.NotNull(orders);
            Assert.IsNotEmpty(orders);
            orders = db.SalesOrderHeaders.WhereEnum(order => order.ShipMethod, shipMethod => shipMethod == ShipMethodEnum.CARGO_TRANSPORT_5 || shipMethod == ShipMethodEnum.OVERNIGHT_J_FAST);
            Assert.NotNull(orders);
            Assert.IsNotEmpty(orders);
        }

        [Test(Description = "Filter table by filtering for a property on Type-Safe-Enums")]
        public void FilterTSE3()
        {
            var db = new AdventureWorksDB();

            // explicit types and inferred types
            var orders = db.SalesOrderHeaders.WhereEnum<SalesOrderHeader, ShipMethodEnum, int>(order => order.ShipMethod, shipMethod => shipMethod.CanCancelShipment);
            Assert.NotNull(orders);
            Assert.IsNotEmpty(orders);
            orders = db.SalesOrderHeaders.WhereEnum(order => order.ShipMethod, shipMethod => shipMethod.CanCancelShipment);
            Assert.NotNull(orders);
            Assert.IsNotEmpty(orders);
        }

        [Test(Description = "Filters table by using extension which filters for Type-Safe-Enum")]
        public void FilterTSE4()
        {
            var db = new AdventureWorksDB();
            var orders1 = db.SalesOrderHeaders.Where(c => c.ShipMethodId == ShipMethodEnum.CARGO_TRANSPORT_5.Key).ToList();
            var orders2 = db.SalesOrderHeaders.FilterByShipMethod(ShipMethodEnum.CARGO_TRANSPORT_5).ToList();
            Assert.AreEqual(orders1.Count, orders2.Count);

            var orders2Query = db.SalesOrderHeaders.FilterByShipMethod(ShipMethodEnum.CARGO_TRANSPORT_5).ToString();
        }


        [Test]
        public void TestCombinedFilters()
        {
            var db = new AdventureWorksDB();


            // Combining (AND/OR) Expressions on Type-Safe-Enums (created using TypeSafeEnumsQuery.CreateExpression) and Expressions on primitive properties
            var filter1 = TypeSafeEnumsQueryHelper.CreateExpression<SalesOrderHeader, ShipMethodEnum, int>(order => order.ShipMethod, shipMethod => shipMethod == ShipMethodEnum.OVERNIGHT_J_FAST);
            System.Linq.Expressions.Expression<Func<SalesOrderHeader, bool>> filter3 = (x) => x.SalesOrderNumber.StartsWith("SO4");
            var filter2 = TypeSafeEnumsQueryHelper.CreateExpression<SalesOrderHeader, ShipMethodEnum, int>(order => order.ShipMethod, shipMethod => !shipMethod.CanCancelShipment);
            var filter1OrFilterAnd3 = filter1.OrElse(filter2.AndAlso(filter3));
            var s = db.SalesOrderHeaders.Where(filter1OrFilterAnd3).Select(x => new { x.SalesOrderId, x.SalesOrderNumber, x.SalesPersonId });
            System.Diagnostics.Debug.WriteLine(s.ToString());
            var anonOrders = s.ToList();

            // testing combining multiple filters (AND filters all in LINQ)
            var andsQuery = db.SalesOrderHeaders
                //.FilterByShipMethod(ShipMethodEnum.CARGO_TRANSPORT_5)
                //.Where(x => x.OrderDate >= new DateTime(2014, 1, 1) && x.OrderDate < new DateTime(2014 + 1, 1, 1))
                .FilterByFiscalYear(2014)
                .WhereEnum(order => order.ShipMethod, shipMethod => shipMethod.CanCancelShipment)
                ;
            Assert.That(andsQuery.ToString().Contains("WHERE "));
            Assert.That(andsQuery.Count() > 0);
            Assert.That(andsQuery.ToList().Where(x => !x.ShipMethod.CanCancelShipment).Count() == 0);

            // bring all cancellable orders, plus(or) all orders which OrderNumber starts with "SO4" (OR filters all in LINQ)
            var cancellableMethods = ShipMethodEnum.Values.Where(x => x.CanCancelShipment).Select(x => x.Key).ToArray();
            var orsQuery = db.SalesOrderHeaders.Where(order =>
                cancellableMethods.Contains(order.ShipMethodId)
                ||
                order.SalesOrderNumber.StartsWith("SO4")
            );
            Assert.That(orsQuery.ToString().Contains("WHERE "));
            Assert.That(orsQuery.Count() > 0);
            Assert.That(andsQuery.ToList().Where(x => !x.ShipMethod.CanCancelShipment).Count() >= 0);
            Assert.That(andsQuery.ToList().Where(x => x.SalesOrderNumber.StartsWith("SO4")).Count() >= 0);
            Assert.That(andsQuery.ToList().Where(x => !x.ShipMethod.CanCancelShipment).All(y => y.SalesOrderNumber.StartsWith("SO4")));
            var andsQuery2 = andsQuery.ToList();

            // OR filters, using unsupported LINQ properties
            var orsQuery2 = db.SalesOrderHeaders.ToList().Where(order =>
                order.SalesOrderNumber.ToLower().StartsWith("so4") || // my SQL Server instance is case insensitive!
                order.ShipMethod.CanCancelShipment
            );
            Assert.That(orsQuery.Count() == orsQuery2.Count());

        }

        [Test]
        public void TestIQueryableFilterExtensions1()
        {
            var db = new AdventureWorksDB();

            var orders1 = db.SalesOrderHeaders.WherePropertyIn(x => x.ShipMethodId, new List<int>() { 1, 2 }).ToList();
            var qry = db.SalesOrderHeaders.WherePropertyIn(x => x.ShipMethodId, new List<int>() { 1, 2 }).ToString();
            System.Diagnostics.Debug.WriteLine(qry);
            Assert.IsTrue(qry.Contains("IN (1, 2)"));

            Assert.That(orders1.Count > 0);
        }

        [Test]
        public void TestInExpression1()
        {
            var db = new AdventureWorksDB();

            var customQuery = db.SalesOrderHeaders.Where
                (
                    QueryHelper.CreateInExpression<SalesOrderHeader, int>(order => order.ShipMethodId, new int[] { 1 })
                );
            var customQuery2 = customQuery.ToList();


        }

        [Test(Description = "Test updating enum property")]
        public void TestEnumUpdate()
        {
            var db = new AdventureWorksDB();

            // get order with shipMethod XRQ_TRUCK_GROUND, check enum
            var order = db.SalesOrderHeaders.Where(x => x.ShipMethodId == 1).First();
            Assert.AreEqual(order.ShipMethod, ShipMethodEnum.XRQ_TRUCK_GROUND);
            Assert.AreNotEqual(order.ShipMethod, ShipMethodEnum.OVERSEAS_DELUXE);

            // update ShipMethodEnum to OVERNIGHT_J_FAST using EF dynamic SQL (syntax 1)
            int ret = db.Database.ExecuteSqlCommand("UPDATE sales.SalesOrderHeader SET ShipMethodID=@ShipMethodID WHERE SalesOrderID=@ID", 
                new SqlParameter("ShipMethodID", ShipMethodEnum.OVERNIGHT_J_FAST.Key), 
                new SqlParameter("ID", order.SalesOrderId));
            Assert.That(ret == 1);

            // update ShipMethodEnum to OVERNIGHT_J_FAST using EF dynamic SQL (syntax 2)
            ret = db.Database.ExecuteSqlCommand("UPDATE sales.SalesOrderHeader SET ShipMethodID={0} WHERE SalesOrderID={1}",
                ShipMethodEnum.OVERNIGHT_J_FAST.Key, 
                order.SalesOrderId);
            Assert.That(ret == 1);

            // check ShipMethod was updated
            var newShipMethod = ShipMethodEnum.FromKey(db.Database.SqlQuery<int>("SELECT ShipMethodID FROM sales.SalesOrderHeader WHERE SalesOrderID=@ID", 
                new SqlParameter("ID", order.SalesOrderId)).SingleOrDefault());
            Assert.That(newShipMethod == ShipMethodEnum.OVERNIGHT_J_FAST);
            Assert.That(newShipMethod != ShipMethodEnum.XRQ_TRUCK_GROUND);
            Assert.That(ShipMethodEnum.OVERNIGHT_J_FAST.Key == 4);

            // update back to XRQ_TRUCK_GROUND
            db.Database.ExecuteSqlCommand("UPDATE sales.SalesOrderHeader SET ShipMethodID=@ShipMethodID WHERE SalesOrderID=@ID", 
                new SqlParameter("ShipMethodID", ShipMethodEnum.XRQ_TRUCK_GROUND.Key), 
                new SqlParameter("ID", order.SalesOrderId));
            newShipMethod = ShipMethodEnum.FromKey(db.Database.SqlQuery<int>("SELECT ShipMethodID FROM sales.SalesOrderHeader WHERE SalesOrderID=@ID", 
                new SqlParameter("ID", order.SalesOrderId)).SingleOrDefault());
            Assert.That(newShipMethod == ShipMethodEnum.XRQ_TRUCK_GROUND);
            Assert.That(newShipMethod != ShipMethodEnum.OVERNIGHT_J_FAST);
            Assert.That(newShipMethod.Key == 1);
        }

        [Test(Description = "Test different query syntaxes")]
        public void TestQuerySyntax()
        {
            var db = new AdventureWorksDB();

            // EF dynamic (inline) SQL
            // then parametrized EF syntax 1 
            // then parametrized EF syntax 2
            // then parametrized Dapper syntax 1 (passing primitive type)
            // then parametrized Dapper syntax 2 (passing primitive type)
            // then parametrized Dapper syntax 3 (passing TSE itself, which is correctly converted into underlying type)
            var orders1 = db.Database.SqlQuery<SalesOrderHeader>("SELECT * FROM sales.SalesOrderHeader WHERE ShipMethodID=1").ToList();
            var orders2 = db.Database.SqlQuery<SalesOrderHeader>("SELECT * FROM sales.SalesOrderHeader WHERE ShipMethodID=@ShipMethodID", new SqlParameter("ShipMethodID", ShipMethodEnum.XRQ_TRUCK_GROUND.Key)).ToList();
            var orders3 = db.Database.SqlQuery<SalesOrderHeader>("SELECT * FROM sales.SalesOrderHeader WHERE ShipMethodID={0}", ShipMethodEnum.XRQ_TRUCK_GROUND.Key).ToList();
            var orders4 = db.Query<SalesOrderHeader>("SELECT * FROM sales.SalesOrderHeader WHERE ShipMethodID=@Status", new { Status = ShipMethodEnum.XRQ_TRUCK_GROUND.Key }).ToList();
            var orders5 = db.Query<SalesOrderHeader>("SELECT * FROM sales.SalesOrderHeader WHERE ShipMethodID=@XRQ_TRUCK_GROUND", new { ShipMethodEnum.XRQ_TRUCK_GROUND }).ToList();

            // check all equal
            Assert.That(orders1.Count > 0);
            Assert.AreEqual(orders1.Count, orders2.Count);
            Assert.AreEqual(orders1.Count, orders3.Count);
            Assert.AreEqual(orders1.Count, orders4.Count);
            Assert.AreEqual(orders1.Count, orders5.Count);
        }
    }
}
