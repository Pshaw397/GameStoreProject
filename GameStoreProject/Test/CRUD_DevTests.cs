using NUnit.Framework;
using StoreData;
using GameStoreBusiness;
using System.Linq;
using System;

namespace Test
{
    public class DevTests
    {
        CRUD_DeveloperMethods _crudMethods;
        [SetUp]
        public void Setup()
        {
            _crudMethods = new CRUD_DeveloperMethods();
            using (var db = new GameMarketContext())
            {
                var selectedDevs =
                from c in db.Developers
                where c.DeveloperName == "Bioware"
                select c;

                var selectedDevs2 =
                from c in db.Developers
                where c.DeveloperName == "Bethesda Softworks"
                select c;

                var selectedDevs3 =
                from c in db.Developers
                where c.DeveloperName == "Treyarch"
                select c;

                db.Developers.RemoveRange(selectedDevs);
                db.Developers.RemoveRange(selectedDevs2);
                db.Developers.RemoveRange(selectedDevs3);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewDevIsAdded_TheNumberOfDevsIncreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                var numberOfDevsBefore = db.Developers.Count();
                _crudMethods.Create("Bioware");
                var numberOfDevsAfter = db.Developers.Count();

                Assert.AreEqual(numberOfDevsBefore + 1, numberOfDevsAfter);
            }
        }

        [Test]
        public void WhenANewDevIsDeleted_TheNumberOfGamesDecreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create("Treyarch");
                var numberOfUsersBefore = db.Developers.Count();
                _crudMethods.Delete("Treyarch");
                var numberOfUsersAfter = db.Developers.Count();

                Assert.AreEqual(numberOfUsersBefore - 1, numberOfUsersAfter);
            }
        }


        [Test]
        public void WhenADevsDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create("Bethesda");

                _crudMethods.Update("Bethesda", "Bethesda Softworks");

                var updatedCustomer = db.Developers.Where(d => d.DeveloperName == "Bethesda Softworks").FirstOrDefault();
                Assert.AreEqual("Bethesda Softworks", updatedCustomer.DeveloperName);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GameMarketContext())
            {
                var selectedDevs =
                from c in db.Developers
                where c.DeveloperName == "Bioware"
                select c;

                var selectedDevs2 =
                from c in db.Developers
                where c.DeveloperName == "Bethesda Softworks"
                select c;

                var selectedDevs3 =
                from c in db.Developers
                where c.DeveloperName == "Treyarch"
                select c;

                db.Developers.RemoveRange(selectedDevs);
                db.Developers.RemoveRange(selectedDevs2);
                db.Developers.RemoveRange(selectedDevs3);
                db.SaveChanges();
            }
        }
    }
}