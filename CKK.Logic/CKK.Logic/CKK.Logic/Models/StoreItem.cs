using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class StoreItem : InventoryItem
    {
        //var?

        public StoreItem(Product prod = null, int quantity = 0) : base(prod, quantity)
        {
        }
    }   
}
