using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

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

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                {
                    throw new InventoryItemStockTooLowException();
                }
                else
                {
                    _quantity = value;
                }
            }
        }
        public Product Product
        {
            get { return _product; }
            set
            {               
               _product = value;                
            }
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
            if (quantity < 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            else
            {
                _quantity = quantity;
            }
        }
    }
}