using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreData;

namespace GameStoreBusiness
{
    class CRUD_Methods
    {
        //public User customerUpdate { get; set; }

        //public void Create(string custId, string contactName, string city, string age)
        //{
        //    Customer newCust = new Customer() { CustomerId = custId, ContactName = contactName, City = city, Age = age };
        //    using (var db = new SouthwindContext())
        //    {
        //        db.Customers.Add(newCust);
        //        db.SaveChanges();
        //    }
        //}

        //public void Delete(string custId)
        //{
        //    using (var db = new SouthwindContext())
        //    {
        //        customerUpdate = db.Customers.Where(c => c.CustomerId == custId).FirstOrDefault();
        //        db.Customers.Remove(customerUpdate);
        //        db.SaveChanges();
        //    }
        //}

        //public void Update(string custId, string contactName, string city, string age, string country)
        //{
        //    using (var db = new SouthwindContext())
        //    {
        //        customerUpdate = db.Customers.Where(c => c.CustomerId == custId).FirstOrDefault();
        //        customerUpdate.ContactName = contactName;
        //        customerUpdate.City = city;
        //        customerUpdate.Age = age;
        //        customerUpdate.Country = country;
        //        db.SaveChanges();
        //    }
        //}

        //public void AddOrder(string custId, DateTime shipDate, string shipCountry)
        //{
        //    using (var db = new SouthwindContext())
        //    {
        //        var testCustomer = db.Customers.Find(custId);
        //        testCustomer.Orders.Add(new Order() { CustomerId = custId, ShippedDate = shipDate, ShipCountry = shipCountry }); // Create an order for the testCustomer entry on the Customer
        //        db.SaveChanges();
        //    }

        //}

        //public void AddOrderDetails(int orderID, decimal unitPrice, short quantity)
        //{
        //    using (var db = new SouthwindContext())
        //    {
        //        var newOrder = db.Orders.Where(o => o.CustomerId == "MAND").FirstOrDefault();
        //        var selectedOrderId = newOrder.OrderId;
        //        var testOrder = db.Orders.Find(selectedOrderId);
        //        testOrder.OrderDetails.Add(new OrderDetail() { UnitPrice = unitPrice, Quantity = quantity }); // Create an order for the testCustomer entry on the Customer
        //        db.SaveChanges();
        //    }
        //}
    }
}
