using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class Product : Entity
    {
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _price = value;
                }
            }
        }
        public Product(string name = "default", int id = 0, decimal price = 0m) : base(name, id)
        {
            _price = price;
        }
      
    }
}