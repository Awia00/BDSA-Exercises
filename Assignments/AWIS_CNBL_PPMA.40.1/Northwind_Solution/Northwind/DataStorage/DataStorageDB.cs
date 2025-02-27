﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataStorage
{
    class DataStorageDB : IDataStorage
    {
        public IList<Product> Products()
        {
            using (var db = new NORTHWNDEntities())
            {
                var products = (from product in db.Products
                                select product).Include("Order_Details").Include("Order_Details.Order");
                return products.ToList();
            }
        }

        public IList<Product> Categories(int ID)
        {
            using (var db = new NORTHWNDEntities())
            {
                var orders = from products in db.Products
                             where products.CategoryID == ID
                             select products;
                return orders.ToList();
            }
        }

        public IList<Order> Orders()
        {
            using (var db = new NORTHWNDEntities())
            {
                var orders = (from order in db.Orders
                    select order).Include("Customer").Include("Order_Details");
                return orders.ToList();
            }
        }

        public IList<Employee> Employees()
        {
            using (var db = new NORTHWNDEntities())
            {
                var employees = (from employee in db.Employees
                                 select employee).Include("Orders").Include("Orders.Order_Details").Include("Orders.Order_Details.Product");
                return employees.ToList();
            }
        }

        public void CreateOrder(Order order)
        {
            using (var db = new NORTHWNDEntities())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public int maxOrderID()
        {
            using (var db = new NORTHWNDEntities())
            {
                var maxID = db.Orders.Max(order => order.OrderID);
                return maxID;
            }
        }
    }
}
