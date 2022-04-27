using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class ShoppingCartItem : InventoryItem
    {
        //var?
        public ShoppingCartItem(Product prod = null, int quantity = 0) : base(prod, quantity)
        {
        }
        
        public decimal GetTotal()
        {
            return GetQuantity() * GetProduct().Price;
        }
    }
}