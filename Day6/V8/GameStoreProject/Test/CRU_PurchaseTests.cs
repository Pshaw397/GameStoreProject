using NUnit.Framework;
using StoreData;
using GameStoreBusiness;
using System.Linq;
using System;

namespace NorthwindTests
{
    public class PurchaseTests
    {
        CRUD_PurchaseMethods _crudMethods;
        // THIS USES PURCHASE ID TO DELETE, MEANING THAT THE TEST MIGHT FAIL IF NOT UPADTED WITH THE MOST CURRENT PURCHASE ID
        [SetUp]
        public void Setup()
        {
            _crudMethods = new CRUD_PurchaseMethods();
            // remove test entry in DB if present
            using (var db = new GameMarketContext())
            {
                var selectedPurchase =
                from c in db.Purchases
                where c.PurchaseId == 1
                select c;

                db.Purchases.RemoveRange(selectedPurchase);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewPurhcaseIsAdded_TheNumberOfPurchaseIncreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                var numberOfPurchasesBefore = db.Purchases.Count();
                _crudMethods.Create(1, 1, 2021, 03, 31);
                var numberOfPurchasesAfter = db.Purchases.Count();

                Assert.AreEqual(numberOfPurchasesBefore + 1, numberOfPurchasesAfter);
            }
        }

        [Test]
        public void WhenANewPurchaseIsDeleted_TheNumberOfPurchaseDecreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create(1, 1, 2021, 03, 31);
                var numberOfPurchasesBefore = db.Purchases.Count();
                _crudMethods.Delete(1);
                var numberOfPurchasesAfter = db.Purchases.Count();

                Assert.AreEqual(numberOfPurchasesBefore - 1, numberOfPurchasesAfter);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GameMarketContext())
            {
                var selectedPurchase =
                from c in db.Purchases
                where c.PurchaseId == 1
                select c;

                db.Purchases.RemoveRange(selectedPurchase);
                db.SaveChanges();
            }
        }
    }
}