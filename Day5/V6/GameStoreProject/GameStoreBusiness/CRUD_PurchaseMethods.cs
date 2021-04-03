using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreData;

namespace GameStoreBusiness
{
    public class CRUD_PurchaseMethods
    {
        public Purchase purchaseUpdate { get; set; }

        public void Create(int userId, int gameID, int year, int month, int day)
        {
            Purchase newPurchase = new Purchase() { UserId = userId, GameId = gameID, PurchaseDate = new DateTime(year, month, day) };
            using (var db = new GameMarketContext())
            {
                db.Purchases.Add(newPurchase);
                db.SaveChanges();
            }
        }

        public void Delete(int purchaseID)
        {
            using (var db = new GameMarketContext())
            {
                purchaseUpdate = db.Purchases.Where(c => c.PurchaseId == purchaseID).FirstOrDefault();
                db.Purchases.Remove(purchaseUpdate);
                db.SaveChanges();
            }
        }
    }
}
