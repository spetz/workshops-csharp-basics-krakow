using System;
using System.Collections.Generic;
using System.Linq;

namespace Source.Models
{
    public class Order : Entity
    {
        private readonly ISet<OrderItem> _items = new HashSet<OrderItem>();
        public decimal TaxRate { get; } = 0.23M;
        public decimal TotalPrice => (1 + TaxRate) * Items.Sum(x => x.TotalPrice);
        public bool IsPurchased { get; private set; }
        public IEnumerable<OrderItem> Items => _items;

        public Order(int id) : base(id)
        {
        }

        public void AddProduct(Product product, int quantity)
        {
            _items.Add(new OrderItem(product.Id, quantity, product.Price));
        }

        public void RemoveProduct(int productId)
        {
            var existingItem = Items.SingleOrDefault(x => x.ProductId == productId);
            if(existingItem == null)
            {
                throw new ArgumentNullException(nameof(existingItem),
                    $"Product with id {productId} was not found.");   
            }
            _items.Remove(existingItem);
        }

        public void Purchase()
        {
            if(IsPurchased)
            {
                throw new InvalidOperationException("Order was already purchased."); 
            }
            IsPurchased = true;
        }
    }
}