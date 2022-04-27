using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private Customer _Customer;
        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        private List<ShoppingCartItem> _Products;
        public List<ShoppingCartItem> Products
        {
            get { return _Products; }
            set { _Products = value; }
        }
        public ShoppingCart(Customer cust = null)
        {
            _Customer = cust;
            _Products = new List<ShoppingCartItem>();
        }
        public int GetCustomerId()
        {
            return _Customer.GetId();
        }
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            var matchingProduct = GetProductById(prod.GetId()); //find the correct product in the list using other method             

            if (quantity < 0)
            {
                throw new InventoryItemStockTooLowException();
            }

            if (matchingProduct != null)
            {
                var _index = _Products.FindIndex(a => a.GetProduct() == prod); //set index of matching prod
                _Products[_index].SetQuantity(_Products[_index].GetQuantity() + quantity); //sets that slot at (matching index) as correct quant
                return _Products[_index]; //returns changed product
            }
            else
            {
                _Products.Add(new ShoppingCartItem(prod, quantity));
                return _Products.Last(); //if no matching item, make new one and return it
            }
        }

        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            var matchingProduct = GetProductById(id); //find the correct product in the list using other method
            var _index = _Products.FindIndex(a => a.GetProduct().GetId() == id); //set index of matching prod id

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (matchingProduct != null) //this asks if it matches or not
            {
                if (_Products[_index].GetQuantity() > quantity)
                {
                    _Products[_index].SetQuantity(_Products[_index].GetQuantity() - quantity);
                    return _Products[_index];
                }
                else // the [if(_Products[_index].GetQuantity() <= quantity)] is implied
                {
                    ShoppingCartItem zeroQuantSCI = _Products[_index];
                    zeroQuantSCI.SetQuantity(0);
                    _Products.RemoveAt(_index);
                    return zeroQuantSCI; //return empty list item
                } //deletes the index item at 0 quant
            }
            else
            {
                throw new ProductDoesNotExistException(); //if none match, throw exc
            } //if the list doesnt have that id, throw exception (if the product is not there/does not exist)

        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (id < 0) //invalid id throw exc
            {
                throw new InvalidIdException();
            }

            var GetIDSelect =
                    from value in _Products
                    select value.GetProduct().GetId(); //makes a collections ennumerable list of the ids that match

            if (GetIDSelect.Contains(id))
            {
                int _index = _Products.FindIndex(a => a.GetProduct().GetId() == id); //set index of matching id
                return _Products[_index];
            }
            else { return null; } //return the correct matching product or return null
        }

        public decimal GetTotal()
        {
            decimal Total = 0;
            for (int counter = 0; counter < _Products.Count(); ++counter) //for each item in list
            {
                Total = Total + _Products[counter].GetTotal(); //add its(SCI) price*quantity to total
            }
            return Total;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return _Products;
        }
    }
}