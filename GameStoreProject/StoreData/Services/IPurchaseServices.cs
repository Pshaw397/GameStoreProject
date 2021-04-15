using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Services
{
    public interface IPurchaseServices
    {
        public void CreatePurchase(Purchase p);
        public void RemovePurchase(Purchase p);
        public Purchase GetPurchaseById(decimal purchaseId);
    }
}
