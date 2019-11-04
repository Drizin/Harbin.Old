using System;
using System.Linq;
using NUnit.Framework;
using AdventureWorksDB = AdventureWorks.Business.Entities.AdventureWorksDB;
using Harbin.Common.Queries;
using System.Collections.Generic;

namespace AdventureWorks.Business.Tests
{
    [TestFixture]
    public class GenericQueryExtensionsTests
    {
        [Test]
        public void Test1()
        {
            var db = new AdventureWorksDB();
            var contacts = db.BusinessEntityContacts;
            var filtered = contacts.WherePropertyIn(p => p.ContactTypeId, new List<int?>() { 1, 2 });
            var sql = filtered.ToString();
            var result = filtered.ToList();
            var result2 = new AdventureWorksDB().Query<Entities.BusinessEntityContact>(@"
                SELECT * FROM [Person].[BusinessEntityContact] WHERE [ContactTypeID] IN (1,2)").ToList();
            Assert.That(sql.Contains("[ContactTypeID] IN (1, 2)"));
            Assert.That(result.Count > 0);
            Assert.AreEqual(result.Count, result2.Count);
            System.Diagnostics.Debug.WriteLine(sql);
        }

        [Test]
        public void Test2()
        {
            var db = new AdventureWorksDB();
            var contacts = db.BusinessEntityContacts;
            var filtered = contacts.WherePropertyNotIn(p => p.ContactTypeId, new List<int?>() { 1, 2 });
            var sql = filtered.ToString();
            var result = filtered.ToList();
            var result2 = new AdventureWorksDB().Query<Entities.BusinessEntityContact>(@"
                SELECT * FROM [Person].[BusinessEntityContact] WHERE [ContactTypeID] NOT IN (1,2)").ToList();
            Assert.That(sql.Contains("NOT ([Extent1].[ContactTypeID] IN (1, 2))"));
            Assert.That(result.Count > 0);
            Assert.AreEqual(result.Count, result2.Count);
            System.Diagnostics.Debug.WriteLine(sql);
        }
    }
}
