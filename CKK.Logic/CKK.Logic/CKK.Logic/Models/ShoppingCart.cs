using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

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
            if (quantity > 0 && prod != null)
            {
                if (_Products.Any())
                {
                    var GetProductSelect =
                        from value in _Products
                        select value.GetProduct();
                    foreach (var item in GetProductSelect) //for each item in that list 
                    {
                        if (item == prod) //if your product matches prod
                        {
                            var _index = _Products.FindIndex(a => a.GetProduct() == prod); //set index of matching prod
                            _Products[_index].SetQuantity(_Products[_index].GetQuantity() + quantity);
                            return _Products[_index];
                        }
                        else
                        {
                            continue; //no match, next item
                        }
                    }
                    _Products.Add(new ShoppingCartItem(prod, quantity));
                    return _Products.Last(); //none match, make new one and return it
                }
                else
                {
                    _Products.Add(new ShoppingCartItem(prod, quantity));
                    return _Products[0]; //if no items, make new one and return it
                }
            }
            else { return null; } //incorrect paramaters, no add
        }
        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (_Products.Any()) //if theres items to remove
            {
                var GetIDSelect =
                    from value in _Products
                    where value.GetProduct().GetId() == id
                    select value.GetProduct().GetId(); //makes a list with only 1 item, the item that matches
                foreach (var item in GetIDSelect) //for each item in that list
                {
                    var _index = _Products.FindIndex(a => a.GetProduct().GetId() == id); //set index of matching id
                    if (quantity > 0) //valid quantity                                  
                    {
                        if (item == id) //if your id matches id
                        {
                            if (_Products[_index].GetQuantity() > quantity)
                            {
                                _Products[_index].SetQuantity(_Products[_index].GetQuantity() - quantity);
                                return _Products[_index];
                            }
                            if (_Products[_index].GetQuantity() <= quantity)
                            {
                                ShoppingCartItem zeroQuantSCI = _Products[_index];
                                zeroQuantSCI.SetQuantity(0);
                                _Products.RemoveAt(_index);
                                return zeroQuantSCI;
                            }
                        }
                        else { continue; } //if doesnt match, go to the next one
                    }
                    else //negative quantities will remove the item
                    {
                        ShoppingCartItem zeroQuantSCI = _Products[_index];
                        zeroQuantSCI.SetQuantity(0);
                        _Products.RemoveAt(_index);
                        return zeroQuantSCI;
                    }
                }
                return null; //if nothing matches, return null

            }
            else { return null; } //if no items nothing comes back
        }
        public ShoppingCartItem GetProductById(int id) //tests.. its findstoreitem but this is sci? and in the sctests...
        {
            if (_Products.Any())
            {
                var GetIDSelect =
                        from value in _Products
                        select value.GetProduct().GetId(); //makes a collections ennumerable list of the ids
                foreach (var item in GetIDSelect)
                {
                    var _index = _Products.FindIndex(a => a.GetProduct().GetId() == id); //set index of matching id
                    if (item == id)
                    {
                        return _Products[_index];
                    }
                    else { continue; } //goes to next one
                }
                return null; //if none match, return null
            }
            else { return null; } // no products no return
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
