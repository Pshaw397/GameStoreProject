using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Services
{
    public class PurchaseServices : IPurchaseServices
    {
        private readonly GameMarketContext _context;
        public PurchaseServices(GameMarketContext context)
        {
            _context = context;
        }
        public PurchaseServices()
        {
            _context = new GameMarketContext();
        }

        public void CreatePurchase(Purchase p)
        {
            _context.Purchases.Add(p);
            _context.SaveChanges();
        }
        public void RemovePurchase(Purchase p)
        {
            var purchaseUpdate = _context.Purchases.Where(c => c.PurchaseId == p.PurchaseId).FirstOrDefault();
            _context.Purchases.Remove(purchaseUpdate);
            _context.SaveChanges();
        }
        public Purchase GetPurchaseById(decimal purchaseId)
        {
            return _context.Purchases.Where(p => p.PurchaseId == purchaseId).FirstOrDefault();
        }
    }
}
