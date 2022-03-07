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
        private ShoppingCartItem _product1;
        private ShoppingCartItem _product2;
        private ShoppingCartItem _product3;             

        public ShoppingCart(Customer cust)
        {
            _Customer = cust;           
        }
       
        public int GetCustomerId()
        {
            return _Customer.GetId();
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (id == _product1.GetProduct().GetId())
            {
                return _product1;
            }
            else if (id == _product2.GetProduct().GetId())
            {
                return _product2;
            }
            else if (id == _product3.GetProduct().GetId())
            {
                return _product3;
            }
            else
            {
                return null;
            }
        }

        public ShoppingCartItem AddStoreItem(Product prod)
        {
            return AddStoreItem(prod, 1);           
        }
        public ShoppingCartItem AddStoreItem(Product prod, int _quantity) 
        {
           
            if ( (prod != null) && (_quantity >= 1) )
            {               
                
                if (_product1 == null)
                {
                    _product1 = new ShoppingCartItem(prod, _quantity);
                    return _product1;                      
                }
                else if (_product2 == null)
                {
                    _product2 = new ShoppingCartItem(prod, _quantity);                    
                    return _product2;
                }
                else if (_product3 == null)
                {
                    _product3 = new ShoppingCartItem(prod, _quantity);                   
                    return _product3;
                }

               
                if (prod == _product1.GetProduct())
                {
                    _product1.SetQuantity(_product1.GetQuantity() + _quantity);
                    return _product1;
                }
                if (prod == _product2.GetProduct())
                {
                    _product2.SetQuantity(_product2.GetQuantity() + _quantity);
                    return _product2;
                }
                if (prod == _product3.GetProduct())
                {
                    _product3.SetQuantity(_product3.GetQuantity() + _quantity);
                    return _product3;
                }

                else
                {
                    return null;
                }
            }           
            else
            {
                return null;
            }
        }
        public ShoppingCartItem RemoveStoreItem(Product prod, int _quantity)
        {
            //(_quantity < _product1.GetQuantity()
            if ((_product1 != null || _product2 != null || _product3 != null) && (_quantity >= 1)) 
            {                
                if ((prod == _product1.GetProduct()) && (_quantity <= _product1.GetQuantity()) )
                {
                    _product1.SetQuantity(_product1.GetQuantity() - _quantity);
                    if (_product1.GetQuantity() <= 0)
                    {
                        _product1 = null;
                    }                   
                    return _product1;                                        
                }
                else if (prod == _product2.GetProduct() && (_quantity <= _product2.GetQuantity()))
                {
                    _product2.SetQuantity(_product2.GetQuantity() - _quantity);
                    if (_product2.GetQuantity() <= 0)
                    {
                        _product2 = null;
                    }
                    return _product2;
                }
                else if (prod == _product3.GetProduct() && (_quantity <= _product3.GetQuantity()))
                {
                    _product3.SetQuantity(_product3.GetQuantity() - _quantity);
                    if (_product3.GetQuantity() <= 0)
                    {
                        _product3 = null;
                    }
                    return _product3;
                }
                else
                {
                    return null;
                }
            }          
            else
            {
                return null;
            }
        }
        public decimal GetTotal()
        {
            decimal Total = (_product1.GetQuantity() * _product1.GetProduct().GetPrice()) + (_product2.GetQuantity() * _product2.GetProduct().GetPrice()) + (_product3.GetQuantity() * _product3.GetProduct().GetPrice());
            return Total;
        }
        public ShoppingCartItem GetProduct(int prodNum)
        {
            if (prodNum == 1)
            {
                return _product1;
            }
            else if (prodNum == 2)
            {
                return _product2;
            }
            else if (prodNum == 3)
            {
                return _product3;
            }
            //else
           // {
            //    return null;
            //}
            return null;
        }
    }
}
