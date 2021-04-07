using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStoreBusiness;
using StoreData;

namespace Test
{
    public class LoginTests
    {
        CRUD_UserMethods userMethods = new CRUD_UserMethods();
        LoginMethods login = new LoginMethods();
        [SetUp]
        public void Setup()
        {
            // remove test entry in DB if present
            using (var db = new GameMarketContext())
            {
                var selectedUsers =
                from c in db.Users
                where c.Username == "unitTestUsername"
                select c;

                db.Users.RemoveRange(selectedUsers);

                foreach (var item in db.Users)
                {
                    item.Selected = false;
                }
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenCorrectLoginDetailsAreEntered_SelectedIsSetToTrue()
        {
            using (var db = new GameMarketContext())
            {
                userMethods.Create("unitTest", "unitTestUsername", "unitTest@test.com", "unitTest");
                decimal loginUserID = login.emailCheck("unitTest@test.com", "unitTest");
                var selectedUser = db.Users.Where(u => u.Selected == true).FirstOrDefault();
                Assert.AreNotEqual(loginUserID, 0);
                Assert.AreEqual("unitTestUsername", selectedUser.Username);
            }
        }

        [Test]
        public void WhenIncorrectEmailIsEntered_IsNotSetToTrue()
        {
            using (var db = new GameMarketContext())
            {
                userMethods.Create("unitTest", "unitTestUsername", "unitTest@test.com", "unitTest");
                decimal loginUserID = login.emailCheck("unitTest@test2.com", "unitTest");
                Assert.AreEqual(loginUserID, 0m);
            }
        }

        [Test]
        public void WhenIncorrectPasswordIsEntered_IsNotSetToTrue()
        {
            using (var db = new GameMarketContext())
            {
                userMethods.Create("unitTest", "unitTestUsername", "unitTest@test.com", "unitTest");
                decimal loginUserID = login.emailCheck("unitTest@test.com", "unitTestFail");
                Assert.AreEqual(loginUserID, 0m);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GameMarketContext())
            {
                var selectedUsers =
                from c in db.Users
                where c.Username == "unitTestUsername"
                select c;

                db.Users.RemoveRange(selectedUsers);

                foreach (var item in db.Users)
                {
                    item.Selected = false;
                }
                db.SaveChanges();
            }

        }
    }
}
