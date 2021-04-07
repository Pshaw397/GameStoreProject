using NUnit.Framework;
using StoreData;
using GameStoreBusiness;
using System.Linq;
using System;

namespace Test
{
    public class UserTests
    {
        CRUD_UserMethods _crudMethods;// I need to create a new class which handles creation the methods for the tests, for the customer class
        [SetUp]
        public void Setup()
        {
            _crudMethods = new CRUD_UserMethods();
            // remove test entry in DB if present
            using (var db = new GameMarketContext())
            {
                var selectedUsers =
                from c in db.Users
                where c.Username == "Beausy"
                select c;

                var selectedUsers2 =
                from c in db.Users
                where c.Username == "Beausy2"
                select c;

                db.Users.RemoveRange(selectedUsers);
                db.Users.RemoveRange(selectedUsers2);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewUserIsAdded_TheNumberOfUsersIncreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                var numberOfUsersBefore = db.Users.Count();
                _crudMethods.Create("Sam Pickard", "Beausy", "Sap@gmail.com", "test123");
                var numberOfUsersAfter = db.Users.Count();

                Assert.AreEqual(numberOfUsersBefore + 1, numberOfUsersAfter);
            }
        }

        [Test]
        public void WhenANewUserIsDeleted_TheNumberOfUsersDecreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create("Sam Pickard", "Beausy", "Sap@gmail.com", "test123");
                var numberOfUsersBefore = db.Users.Count();
                _crudMethods.Delete("Beausy");
                var numberOfUsersAfter = db.Users.Count();

                Assert.AreEqual(numberOfUsersBefore - 1, numberOfUsersAfter);
            }
        }


        [Test]
        public void WhenAUsersDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create("Sam Pickard", "Beausy", "Sap@gmail.com", "test123");

                _crudMethods.Update("Beausy", "Beausy2", "UK", 11.99m, "Sap@gmail.com", "test123");

                var updatedCustomer = db.Users.Where(u => u.Username == "Beausy2").FirstOrDefault();
                Assert.AreEqual("Beausy2", updatedCustomer.Username);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GameMarketContext())
            {
                var selectedUsers =
                from c in db.Users
                where c.Username == "Beausy"
                select c;

                var selectedUsers2 =
                from c in db.Users
                where c.Username == "Beausy2"
                select c;

                db.Users.RemoveRange(selectedUsers);
                db.Users.RemoveRange(selectedUsers2);
                db.SaveChanges();
            }
        }
    }
}