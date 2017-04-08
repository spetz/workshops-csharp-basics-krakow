using System;
using System.Linq;
using Source.Models;
using Source.Persistence;

namespace Source.Services
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IDatabase _database;

        public OrderProcessor(IDatabase database)
        {
            _database = database;
        }

        public Order CompleteOrder(Cart cart)
        {
            Console.WriteLine("Processing an order...");
            var user = _database.Users.GetById(cart.UserId);
            var orderId = _database.Orders.Any() ? _database.Orders.Max(x => x.Id) + 1 : 1;
            var order = new Order(orderId);
            foreach(var item in cart.Items)
            {
                var product = _database.Products.Single(x => x.Id == item.ProductId);
                order.AddProduct(product, item.Quantity);
            }
            user.PurchaseOrder(order);
            _database.SaveChanges();

            return order;
        }
    }
}