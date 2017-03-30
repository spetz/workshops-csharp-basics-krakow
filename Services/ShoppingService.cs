using System;
using System.Collections.Generic;
using System.Linq;
using Source.Models;
using Source.Persistence;

namespace Source.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly IDatabase _database;
        private IDictionary<string, Cart> _userCarts = new Dictionary<string, Cart>();

        public ShoppingService(IDatabase database)
        {
            _database = database;
        }

        public User SignIn(string email, string password)
        {
            Console.WriteLine($"Signing in user '{email}'...");
            User user = null;
            foreach(var dbUser in _database.Users)
            {
                if(dbUser.Email == email)
                {
                    user = dbUser;
                    break;
                }
            }
            if(user.Password != password)
            {
                //TODO: Add validation. 
            }
            _userCarts[user.Email] = new Cart(user);

            return user;
        }

        public Cart GetCart(string email) => _userCarts[email];

        public Product GetProduct(string name)
        {
            foreach(var product in _database.Products)
            {
                if(product.Name.ToLowerInvariant() == name.ToLowerInvariant())
                {
                    return product;
                }
            }

            return null;
        }
    }
}