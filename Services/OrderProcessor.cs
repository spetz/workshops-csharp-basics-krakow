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

        public Result<Order> CompleteOrder(Cart cart)
        {
            Console.WriteLine("Processing an order...");
            User user = null;
            foreach(var dbUser in _database.Users)
            {
                if(dbUser.Id == cart.UserId)
                {
                    user = dbUser;
                    break;
                }
            }
            int orderId = _database.Orders.Count;
            Order order = new Order(orderId);
            foreach(CartItem item in cart.Items)
            {
                foreach(var product in _database.Products)
                {
                    if(product.Id == item.ProductId)
                    {
                        order.AddProduct(product, item.Quantity);
                    }
                }
            }
            user.PurchaseOrder(order);
            _database.SaveChanges();
            
            return Result<Order>.Ok(order);
        }
    }
}