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
            var user = _database.Users
                .SingleOrDefault(x => x.Email == email.ToLowerInvariant());
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user), "User was not found.");
            }
            if(user.Password != password)
            {
                throw new InvalidOperationException("Invalid password."); 
            }
            _userCarts[user.Email] = new Cart(user);

            return user;
        }

        public Cart GetCart(string email) => _userCarts[email];

        public Product GetProduct(string name)
            => _database.Products
            .SingleOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant());
    }
}