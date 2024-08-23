using MVCCC.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCCC.Models
{
    public class DBmanager
    {
        private readonly TestMVCCC_Context db;

        public DBmanager(TestMVCCC_Context _db)
        {
            db = _db ?? throw new ArgumentNullException(nameof(_db));
        }

        public List<OrderDTO> GetOrders()
        {
            List<OrderDTO> getOrders = db.Orders.Select(x => new OrderDTO
            {
                OrderId = x.OrderId,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Price = x.Price,
                Customer = x.Customer,
                Quantity = x.Quantity,
                OrderDT = x.OrderDT
            }).ToList();

            return getOrders;
        }

        public void CreateOrder(OrderDTO order)
        {
            Order newOrder = new Order
            {
                OrderId = order.OrderId,
                CategoryId = order.CategoryId,
                Name = order.Name,
                Price = order.Price,
                Customer = order.Customer,
                Quantity = order.Quantity
            };

            db.Orders.Add(newOrder);
            db.SaveChanges();
        }

        public OrderDTO GetOrderById(int orderId)
        {
            OrderDTO order = db.Orders
                .Where(x => x.OrderId == orderId)
                .Select(x => new OrderDTO
                {
                    OrderId = x.OrderId,
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Price = x.Price,
                    Customer = x.Customer,
                    Quantity = x.Quantity
                }).FirstOrDefault();

            return order;
        }

        public void UpdateOrder(OrderDTO order)
        {
            Order updOrder = db.Orders.Find(order.OrderId);

            updOrder.CategoryId = order.CategoryId;
            updOrder.Name = order.Name;
            updOrder.Price = order.Price;
            updOrder.Customer = order.Customer;
            updOrder.Quantity = order.Quantity;
            updOrder.OrderDT = order.OrderDT;

            db.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            Order delOrder = db.Orders.Find(orderId);
            db.Orders.Remove(delOrder);
            db.SaveChanges();
        }
    }
}