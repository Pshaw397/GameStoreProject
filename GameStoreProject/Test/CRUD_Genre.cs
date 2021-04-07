using NUnit.Framework;
using StoreData;
using GameStoreBusiness;
using System.Linq;
using System;

namespace Test
{
    public class GenreTests
    {
        CRUD_GenreMethods _crudMethods;
        [SetUp]
        public void Setup()
        {
            _crudMethods = new CRUD_GenreMethods();
            using (var db = new GameMarketContext())
            {
                var selectedGenres =
                from c in db.Genres
                where c.GenreName == "VR"
                select c;

                var selectedGenres2 =
                from c in db.Genres
                where c.GenreName == "Adventure"
                select c;

                var selectedGenres3 =
                from c in db.Genres
                where c.GenreName == "Maze"
                select c;

                var selectedGenres4 =
                from c in db.Genres
                where c.GenreName == "FPS"
                select c;

                db.Genres.RemoveRange(selectedGenres);
                db.Genres.RemoveRange(selectedGenres2);
                db.Genres.RemoveRange(selectedGenres3);
                db.Genres.RemoveRange(selectedGenres4);
            }
        }

        [Test]
        public void WhenANewGenreIsAdded_TheNumberOfGamesIncreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                var numberOfGenresBefore = db.Genres.Count();
                _crudMethods.Create("Maze");
                var numberOfGenresAfter = db.Genres.Count();

                Assert.AreEqual(numberOfGenresBefore + 1, numberOfGenresAfter);
            }
        }

        [Test]
        public void WhenANewGenreIsDeleted_TheNumberOfGenresDecreasesBy1()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create("VR");
                var numberOfGenresBefore = db.Genres.Count();
                _crudMethods.Delete("VR");
                var numberOfGenresAfter = db.Genres.Count();

                Assert.AreEqual(numberOfGenresBefore - 1, numberOfGenresAfter);
            }
        }


        [Test]
        public void WhenAGenresIsChanged_TheDatabaseIsUpdated()
        {
            using (var db = new GameMarketContext())
            {
                _crudMethods.Create("FPS");

                _crudMethods.Update("FPS", "Adventure");

                var updatedGenre = db.Genres.Where(g => g.GenreName == "Adventure").FirstOrDefault();
                Assert.AreEqual("Adventure", updatedGenre.GenreName);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new GameMarketContext())
            {
                var selectedGenres =
                from c in db.Genres
                where c.GenreName == "VR"
                select c;

                var selectedGenres2 =
                from c in db.Genres
                where c.GenreName == "Adventure"
                select c;

                var selectedGenres3 =
                from c in db.Genres
                where c.GenreName == "Maze"
                select c;

                var selectedGenres4 =
                from c in db.Genres
                where c.GenreName == "FPS"
                select c;

                db.Genres.RemoveRange(selectedGenres);
                db.Genres.RemoveRange(selectedGenres2);
                db.Genres.RemoveRange(selectedGenres3);
                db.Genres.RemoveRange(selectedGenres4);

                db.SaveChanges();
            }
        }
    }
}