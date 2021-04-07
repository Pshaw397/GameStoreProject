using NUnit.Framework;
using StoreData;
using GameStoreBusiness;
using System.Linq;
using System;

namespace Test
{
    public class GameGenreTests
    {
        CRUD_GameGenreMethods _crudMethods;
        [SetUp]
        public void Setup()
        {
            _crudMethods = new CRUD_GameGenreMethods();
            using (var db = new GameMarketContext())
            {
                var selectedGames =
                from b in db.GameGenres
                where b.GameId == 1
                select b;

                db.GameGenres.RemoveRange(selectedGames);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewRecordIsAdded_TheNumberOfRecordsIncreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                var numberOfGameGenresBefore = db.GameGenres.Count();
                _crudMethods.Create(1, 1);
                var numberOfGameGenresAfter = db.GameGenres.Count();

                Assert.AreEqual(numberOfGameGenresBefore + 1, numberOfGameGenresAfter);
            }
        }

        [Test]
        public void WhenTheGenreIsChanged_TheDatabaseIsUpdated()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create(1, 1);
                _crudMethods.Update(1, 1, 2);

                var updatedGameGenre = db.GameGenres.Where(bg => bg.GameId == 1 && bg.GenreId == 2).FirstOrDefault();
                Assert.AreEqual(2, updatedGameGenre.GenreId);
            }
        }

        [Test]
        public void WhenTheGameIDIsPassedInTheGameRecordIsDeleted()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create(1, 1);
                var numberOfRecordsBefore = db.GameGenres.Count();
                _crudMethods.Delete(1);
                var numberOfRecordAfter = db.GameGenres.Count();

                Assert.AreEqual(numberOfRecordsBefore - 1, numberOfRecordAfter);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GameMarketContext())
            {
                var selectedGames =
                from b in db.GameGenres
                where b.GameId == 1
                select b;

                db.GameGenres.RemoveRange(selectedGames);
                db.SaveChanges();
            }
        }
    }
}