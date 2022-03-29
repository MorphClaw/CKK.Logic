using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _Customer;
        private List<ShoppingCartItem> Products;

        public ShoppingCart(Customer cust)
        {
            _Customer = cust;
            Products = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return _Customer.GetId();
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity > 0 && prod != null)
            {
                if (Products.Any())
                {
                    var GetProductSelect =
                        from value in Products
                        select value.GetProduct();

                    foreach (var item in GetProductSelect) //for each item in that list 
                    {
                        if (item == prod) //if your product matches prod
                        {

                            var _index = Products.FindIndex(a => a.GetProduct() == prod); //set index of matching prod

                            Products[_index].SetQuantity(Products[_index].GetQuantity() + quantity);
                            return Products[_index];
                        }
                        else
                        {
                            continue; //no match, next item
                        }
                    }
                    Products.Add(new ShoppingCartItem(prod, quantity));
                    return Products.Last(); //none match, make new one and return it
                }
                else
                {
                    Products.Add(new ShoppingCartItem(prod, quantity));
                    return Products[0]; //if no items, make new one and return it
                }
            }
            else { return null; } //incorrect paramaters, no add
        }

        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (Products.Any()) //if theres items to remove
            {

                var GetIDSelect =
                    from value in Products
                    where value.GetProduct().GetId() == id
                    select value.GetProduct().GetId(); //makes a list with only 1 item, the item that matches

                foreach (var item in GetIDSelect) //for each item in that list
                {
                    var _index = Products.FindIndex(a => a.GetProduct().GetId() == id); //set index of matching id

                    if (quantity > 0) //valid quantity                                  
                    {
                        if (item == id) //if your id matches id
                        {
                            if (Products[_index].GetQuantity() > quantity)
                            {
                                Products[_index].SetQuantity(Products[_index].GetQuantity() - quantity);
                                return Products[_index];
                            }
                            if (Products[_index].GetQuantity() <= quantity)
                            {
                                ShoppingCartItem zeroQuantSCI = Products[_index];
                                zeroQuantSCI.SetQuantity(0);
                                Products.RemoveAt(_index);
                                return zeroQuantSCI;
                            }
                        }
                        else { continue; } //if doesnt match, go to the next one
                    }
                    else //negative quantities will remove the item
                    {
                        ShoppingCartItem zeroQuantSCI = Products[_index];
                        zeroQuantSCI.SetQuantity(0);
                        Products.RemoveAt(_index);
                        return zeroQuantSCI;
                    }
                }
                return null; //if nothing matches, return null
               
            }
            else { return null; } //if no items nothing comes back
        }      

        public ShoppingCartItem GetProductById(int id) //tests.. its findstoreitem but this is sci? and in the sctests...
        {
            if (Products.Any())
            {
                var GetIDSelect =
                        from value in Products
                        select value.GetProduct().GetId(); //makes a collections ennumerable list of the ids
                foreach (var item in GetIDSelect)
                {
                    var _index = Products.FindIndex(a => a.GetProduct().GetId() == id); //set index of matching id

                    if (item == id)
                    {

                        return Products[_index];
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
            for (int counter = 0; counter < Products.Count(); ++counter) //for each item in list
            {
                Total = Total + Products[counter].GetTotal(); //add its(SCI) price*quantity to total
            }

            return Total;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }
    }
}
