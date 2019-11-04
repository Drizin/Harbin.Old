using System;
using System.Linq;
using NUnit.Framework;
using AdventureWorksDB = AdventureWorks.Business.Entities.AdventureWorksDB;

namespace AdventureWorks.Business.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var db = new AdventureWorksDB();
            var person = db.People.First();
            Assert.IsNotNull(person);
            Assert.IsNotNull(person.FirstName);
            var person2 = new AdventureWorksDB().Query<Entities.Person>("SELECT * FROM [Person].[Person] WHERE [BusinessEntityID]=@BusinessEntityID",
                new { person.BusinessEntityId }).Single();
            Assert.IsNotNull(person2);
            Assert.AreEqual(person.FirstName, person2.FirstName);
            Assert.AreEqual(person.BusinessEntityId, person2.BusinessEntityId);
        }

        [Test]
        public void TestInsert1()
        {
            var db = new AdventureWorksDB();
            var person = db.People.First();
            Assert.IsNotNull(person);
            Assert.IsNotNull(person.BusinessEntityId);
            person = new Entities.Person();
            Assert.IsNull(person.BusinessEntityId);
            person.PersonType = "GC";
            person.NameStyle = false;
            person.FirstName = "Rick";
            person.LastName = "Drizin";
            person.EmailPromotion = 0;
            db.People.Add(person);
            int savedRecords = db.SaveChanges();
            Assert.AreEqual(savedRecords, 1);
            Assert.IsNotNull(person.BusinessEntityId);

            var person2 = new AdventureWorksDB().Query<Entities.Person>("SELECT * FROM [Person].[Person] WHERE [BusinessEntityID]=@BusinessEntityID",
                new { person.BusinessEntityId }).Single();
            Assert.IsNotNull(person2);
            Assert.AreEqual(person.FirstName, person2.FirstName);
            Assert.AreEqual(person.BusinessEntityId, person2.BusinessEntityId);
        }
    }
}
