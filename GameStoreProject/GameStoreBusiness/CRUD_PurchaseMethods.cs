using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreData;
using StoreData.Services;

namespace GameStoreBusiness
{
    public class CRUD_PurchaseMethods
    {
        public Purchase purchaseUpdate { get; set; }
        public IPurchaseServices _services;

        public CRUD_PurchaseMethods(IPurchaseServices service)
        {
            if (service == null)
            {
                throw new ArgumentException("PurchaseService cannot be null");
            }
            _services = service;
        }
        public CRUD_PurchaseMethods()
        {
            _services = new PurchaseServices();
        }

        public void Create(decimal userId, decimal gameID, int year, int month, int day)
        {
            Purchase newPurchase = new Purchase() { UserId = userId, GameId = gameID, PurchaseDate = new DateTime(year, month, day) };
            _services.CreatePurchase(newPurchase);
        }

        public void Delete(decimal purchaseID)
        {
            var purchaseUpdate = _services.GetPurchaseById(purchaseID);
            _services.RemovePurchase(purchaseUpdate);
        }
    }
}
