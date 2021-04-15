using NUnit.Framework;
using StoreData;
using GameStoreBusiness;
using System.Linq;
using System;
using Moq;
using StoreData.Services;

namespace Test
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
                where c.GameId == 1
                select c;

                db.Purchases.RemoveRange(selectedPurchase);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewPurhcaseIsAdded_TheNumberOfPurchaseIncreasesBy1()
        {
            var mockPurchaseService = new Mock<IPurchaseServices>(); ;
            var newPurchase = new Purchase() { PurchaseId = 1, UserId = 1, GameId = 3 };
            mockPurchaseService.Setup(ps => ps.GetPurchaseById(newPurchase.PurchaseId)).Returns(newPurchase);
            _crudMethods = new CRUD_PurchaseMethods(mockPurchaseService.Object);

            _crudMethods.Create(newPurchase.UserId, newPurchase.GameId, 2021, 04, 06);

            mockPurchaseService.Verify(ps => ps.CreatePurchase(It.IsAny<Purchase>()), Times.Once);
        }

        [Test]
        public void WhenANewPurchaseIsDeleted_TheNumberOfPurchaseDecreasesBy1()
        {
            var mockPurchaseService = new Mock<IPurchaseServices>(); ;
            var newPurchase = new Purchase() { PurchaseId = 1, UserId = 1, GameId = 3, PurchaseDate = new DateTime(06 / 04 / 2021) };
            mockPurchaseService.Setup(ps => ps.GetPurchaseById(newPurchase.PurchaseId)).Returns(newPurchase);
            _crudMethods = new CRUD_PurchaseMethods(mockPurchaseService.Object);

            _crudMethods.Delete(newPurchase.PurchaseId);

            mockPurchaseService.Verify(ps => ps.RemovePurchase(It.IsAny<Purchase>()), Times.Once);

        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GameMarketContext())
            {
                var selectedPurchase =
                from c in db.Purchases
                where c.GameId == 1
                select c;

                db.Purchases.RemoveRange(selectedPurchase);
                db.SaveChanges();
            }
        }
    }
}