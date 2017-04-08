using System;
using System.Collections.Generic;

namespace Source.Models
{
    public class User : Entity
    {
        private readonly ISet<Order> _orders = new HashSet<Order>();
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string FullName { get; set; }
        public Address Address { get; set; }
        public int Age { get; protected set; }
        public bool IsActive { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public decimal Funds { get; private set; }
        public IEnumerable<Order> Order =>_orders;

        public User(int id, string email, string password) : base(id)
        {
            SetEmail(email);
            SetPassword(password);
            Activate();
        }

        public void SetEmail(string email)
        {
            email.FailIfEmpty(nameof(email));
            if(Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            MarkAsUpdated();
        }

        public void SetPassword(string password)
        {
            password.FailIfEmpty(nameof(password));
            if(Password == password)
            {
                return;
            }

            Password = password;
            MarkAsUpdated();
        }

        public void SetAge(int age)
        {
            age.FailIfLessThan(13, nameof(age));
            if(Age == age)
            {
                return;
            }
            
            Age = age;
            MarkAsUpdated();
        }

        public void Activate()
        {
            if(IsActive)
            {
                return;
            }

            IsActive = true;
            MarkAsUpdated();
        }

        public void Deactivate()
        {
            if(!IsActive)
            {
                return;
            }

            IsActive = false;
            MarkAsUpdated();
        }

        public void IncreaseFunds(decimal funds)
        {
            funds.FailIfLessThanZero(nameof(funds));
            Funds += funds;
            MarkAsUpdated();
        }

        public void PurchaseOrder(Order order)
        {
            if(!IsActive)
            {
                throw new InvalidOperationException("User is not active.");
            }

            var orderPrice = order.TotalPrice;
            var remainingFunds = Funds - orderPrice;
            if(remainingFunds < 0)
            {
                throw new InvalidOperationException("You don't have enough money.");
            }
            order.Purchase();
            Funds -= orderPrice;
            _orders.Add(order);
            MarkAsUpdated();
        }

        private void MarkAsUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}