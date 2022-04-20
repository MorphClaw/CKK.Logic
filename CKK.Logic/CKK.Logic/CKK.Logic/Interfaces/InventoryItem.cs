using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Interfaces
{
    public abstract class InventoryItem
    {
        private Product _product;
        private int _quantity;
        public InventoryItem(Product prod = null, int quantity = 0)
        {
            _product = prod;
            _quantity = quantity;
        }
   
        public Product GetProduct()
        {
            return _product;
        }
        public void SetProduct(Product prod)
        {
            _product = prod;
        }
        public int GetQuantity()
        {
            return _quantity;
        }
        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }
    }
}