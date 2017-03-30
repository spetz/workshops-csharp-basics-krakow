using System;
using System.Collections.Generic;
using System.Linq;

namespace Source.Models
{
    public class Order : Entity
    {
        private readonly ISet<OrderItem> _items = new HashSet<OrderItem>();
        public decimal TaxRate { get; } = 0.23M;
        public decimal TotalPrice
        {
            get
            {
                var sum = 0M;
                foreach(var item in Items)
                {
                    sum += item.TotalPrice;
                }

                return (1 + TaxRate) * sum;
            }
        }
        
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
            OrderItem existingItem = null;
            foreach(OrderItem item in Items)
            {
                if(item.ProductId == productId)
                {
                    existingItem = item;
                    break;
                }
            }
            if(existingItem == null)
            {
                //TODO: Add validation.   
            }
            _items.Remove(existingItem);
        }

        public void Purchase()
        {
            if(IsPurchased)
            {
                //TODO: Add validation. 
            }
            IsPurchased = true;
        }
    }
}