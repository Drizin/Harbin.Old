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
    public class TypeSafeEnumsTests
    {
        [Test]
        public void TypeTest1()
        {
            Assert.IsTrue(Harbin.Common.General.ReflectionHelper.IsSubclassOfGeneric(typeof(List<>), typeof(List<int>)));
            Assert.IsTrue(TypeSafeEnumHelper.IsTypeSafeEnum(typeof(ContactTypeEnum)));
            Assert.IsTrue(TypeSafeEnumHelper.IsTypeSafeEnum(typeof(ContactTypeEnum)));
            Assert.IsTrue(TypeSafeEnumHelper.IsTypeSafeEnum(typeof(ContactTypeEnum.AccountingManagerContactTypeEnum)));
            Assert.False(TypeSafeEnumHelper.IsTopLevelTypeSafeEnum(typeof(ContactTypeEnum.AccountingManagerContactTypeEnum)));
            var typeSafeEnums = typeof(ContactType).Assembly.GetTopLevelTypeSafeEnums().ToList();
            Assert.Contains(typeof(ContactTypeEnum), typeSafeEnums);
            Assert.Contains(typeof(ShipMethodEnum), typeSafeEnums);
            Assert.AreEqual(2, typeSafeEnums.Count);
        }

        [Test(Description = "Loads entity using EF, checks if Enum is loaded correctly")]
        public void TestEF_FromDB()
        {
            var db = new AdventureWorksDB();
            var contacts = db.BusinessEntityContacts.Take(10).ToList();
            foreach(var contact in contacts)
            {
                ContactTypeEnum type = contact.ContactType;
                Assert.NotNull(type);
                Assert.NotNull(type.Key);
                Assert.AreEqual(type.Key, contact.ContactTypeId);
            }
        }

        [Test(Description = "Updates entity using EF, checks if Enum is saved correctly")]
        public void TestEF_UpdateEnum()
        {
            var db = new AdventureWorksDB();
            var order = db.SalesOrderHeaders.Where(c => c.ShipMethodId != ShipMethodEnum.CARGO_TRANSPORT_5.Key).First();
            ShipMethodEnum previousType = order.ShipMethod;
            Assert.NotNull(order);
            Assert.NotNull(previousType);
            Assert.AreNotEqual(previousType, ShipMethodEnum.CARGO_TRANSPORT_5);
            order.ShipMethod = ShipMethodEnum.CARGO_TRANSPORT_5;
            int saved = db.SaveChanges();
            Assert.AreEqual(1, saved);

            db = new AdventureWorksDB();
            order = db.SalesOrderHeaders.Single(c => c.SalesOrderId == order.SalesOrderId);
            Assert.NotNull(order);
            Assert.NotNull(order.ShipMethod);
            Assert.AreEqual(order.ShipMethod, ShipMethodEnum.CARGO_TRANSPORT_5);

            order.ShipMethod = previousType;
            saved = db.SaveChanges();
            Assert.AreEqual(1, saved);
        }

        [Test(Description = "Loads entity using Dapper, filtering by Enum which is converted into the underlying type")]
        public void TestDapper_DBFilter()
        {
            var db = new AdventureWorksDB();
            var contacts = db.Query<Entities.BusinessEntityContact>("SELECT * FROM person.BusinessEntityContact WHERE ContactTypeID=@ContactType",
                new { ContactType = ContactTypeEnum.ASSISTANT_SALES_AGENT }).ToList();
            foreach (var contact in contacts)
            {
                ContactTypeEnum type = contact.ContactType;
                Assert.That(type.Key == ContactTypeEnum.ASSISTANT_SALES_AGENT.Key);
                Assert.That(contact.ContactTypeId == 2);
            }
        }


        [Test(Description = "Test TSE extensions WhereEnumIn/WhereEnumNotIn")]
        public void TestWhereEnumIn()
        {
            var db = new AdventureWorksDB();

            var orders1 = db.SalesOrderHeaders.WhereEnumNotIn<SalesOrderHeader, ShipMethodEnum, int>(x => x.ShipMethod, new ShipMethodEnum[] { ShipMethodEnum.OVERNIGHT_J_FAST }).ToList();
            orders1 = db.SalesOrderHeaders.WhereEnumIn<SalesOrderHeader, ShipMethodEnum, int>(x => x.ShipMethod, new ShipMethodEnum[] { ShipMethodEnum.OVERNIGHT_J_FAST, ShipMethodEnum.OVERSEAS_DELUXE }).ToList();
            var orders3 = db.Database.SqlQuery<SalesOrderHeader>("SELECT * FROM sales.SalesOrderHeader WHERE ShipMethodId=1").ToList();


            var allOrders = db.SalesOrderHeaders;
            var cancellableOrders = db.SalesOrderHeaders.WhereEnumIn<SalesOrderHeader, ShipMethodEnum, int>(o => o.ShipMethod, new ShipMethodEnum[] { ShipMethodEnum.CARGO_TRANSPORT_5, ShipMethodEnum.OVERNIGHT_J_FAST, ShipMethodEnum.OVERSEAS_DELUXE, ShipMethodEnum.ZY_EXPRESS });
            var nonCancellableOrders = db.SalesOrderHeaders.WhereEnumNotIn<SalesOrderHeader, ShipMethodEnum, int>(o => o.ShipMethod, new ShipMethodEnum[] { ShipMethodEnum.CARGO_TRANSPORT_5, ShipMethodEnum.OVERNIGHT_J_FAST, ShipMethodEnum.OVERSEAS_DELUXE, ShipMethodEnum.ZY_EXPRESS });

            Assert.That(allOrders.Count() == cancellableOrders.Count() + nonCancellableOrders.Count());
        }

    }
}
