using NUnit.Framework;
using StoreData;
using GameStoreBusiness;
using System.Linq;
using System;

namespace Test
{
    public class GameTests
    {
        CRUD_GameMethods _crudMethods;// I need to create a new class which handles creation the methods for the tests, for the customer class
        [SetUp]
        public void Setup()
        {
            _crudMethods = new CRUD_GameMethods();
            // remove test entry in DB if present
            using (var db = new GameMarketContext())
            {
                var selectedGames =
                from c in db.Games
                where c.Name == "Yakuza 0"
                select c;

                db.Games.RemoveRange(selectedGames);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewGameIsAdded_TheNumberOfGamesIncreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                var numberOfGamesBefore = db.Games.Count();
                _crudMethods.Create("Yakuza 0", "SEGA’s legendary Japanese series finally comes to PC. Fight like hell through Tokyo and Osaka as junior yakuza Kiryu and Majima. Take a front row seat to 1980s life in Japan in an experience unlike anything else in video gaming, with uncapped framerates and 4K resolutions. A legend is born.",
                    null, 14.99m, "SEGA", 2018, 08, 01);
                var numberOfGamesAfter = db.Games.Count();

                Assert.AreEqual(numberOfGamesBefore + 1, numberOfGamesAfter);
            }
        }

        [Test]
        public void WhenANewGameIsDeleted_TheNumberOfGamesDecreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create("Yakuza 0", "SEGA’s legendary Japanese series finally comes to PC. Fight like hell through Tokyo and Osaka as junior yakuza Kiryu and Majima. Take a front row seat to 1980s life in Japan in an experience unlike anything else in video gaming, with uncapped framerates and 4K resolutions. A legend is born.",
                  null, 14.99m, "SEGA", 2018, 08, 01);
                var numberOfGamesBefore = db.Games.Count();
                _crudMethods.Delete("Yakuza 0");
                var numberOfGamesAfter = db.Games.Count();

                Assert.AreEqual(numberOfGamesBefore - 1, numberOfGamesAfter);
            }
        }


        [Test]
        public void WhenAGamesDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create("Yakuza 0", "SEGA’s legendary Japanese series finally comes to PC. Fight like hell through Tokyo and Osaka as junior yakuza Kiryu and Majima. Take a front row seat to 1980s life in Japan in an experience unlike anything else in video gaming, with uncapped framerates and 4K resolutions. A legend is born.",
                  null, 19.99m, "SEGA", 2018, 08, 01);

                _crudMethods.Update("Yakuza 0", "Yakuza 0", "SEGA’s legendary Japanese series finally comes to PC. Fight like hell through Tokyo and Osaka as junior yakuza Kiryu and Majima. Take a front row seat to 1980s life in Japan in an experience unlike anything else in video gaming, with uncapped framerates and 4K resolutions. A legend is born.",
                  null, 14.99m, "SEGA", 2018, 08, 01);

                var updatedGames = db.Games.Where(u => u.Name == "Yakuza 0").FirstOrDefault();
                Assert.AreEqual(14.99m, updatedGames.Price);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GameMarketContext())
            {
                var selectedGames =
                from c in db.Games
                where c.Name == "Yakuza 0"
                select c;

                db.Games.RemoveRange(selectedGames);
                db.SaveChanges();
            }
        }
    }
}