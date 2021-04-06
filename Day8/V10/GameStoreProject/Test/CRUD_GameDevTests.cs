using NUnit.Framework;
using StoreData;
using GameStoreBusiness;
using System.Linq;
using System;

namespace NorthwindTests
{
    public class GameDevTests
    {
        CRUD_GameDeveloperMethods _crudMethods;
        [SetUp]
        public void Setup()
        {
            _crudMethods = new CRUD_GameDeveloperMethods();
            using (var db = new GameMarketContext())
            {
                var selectedDevs =
                from b in db.GameDevelopers
                where b.GameId == 1
                select b;

                db.GameDevelopers.RemoveRange(selectedDevs);
                db.SaveChanges();

            }
        }

        [Test]
        public void WhenANewRecordIsAdded_TheNumberOfRecordsIncreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                var numberOfGameDevsBefore = db.GameDevelopers.Count();
                _crudMethods.Create(1, 1);
                var numberOfGameDevsAfter = db.GameDevelopers.Count();

                Assert.AreEqual(numberOfGameDevsBefore + 1, numberOfGameDevsAfter);
            }
        }

        [Test]
        public void WhenTheDevIsChanged_TheDatabaseIsUpdated()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create(1, 1);
                _crudMethods.Update(1, 1, 2);

                var updatedGameDev = db.GameDevelopers.Where(bg => bg.GameId == 1 && bg.DeveloperId == 2).FirstOrDefault();
                Assert.AreEqual(2, updatedGameDev.DeveloperId);
            }
        }

        [Test]
        public void WhenTheGameIDIsPassedInTheGameRecordIsDeleted()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create(1, 1);
                var numberOfPurchasesBefore = db.GameDevelopers.Count();
                _crudMethods.Delete(1);
                var numberOfPurchasesAfter = db.GameDevelopers.Count();

                Assert.AreEqual(numberOfPurchasesBefore - 1, numberOfPurchasesAfter);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GameMarketContext())
            {
                var selectedDevs =
                from b in db.GameDevelopers
                where b.GameId == 1
                select b;

                db.GameDevelopers.RemoveRange(selectedDevs);
                db.SaveChanges();
            }
        }
    }
}