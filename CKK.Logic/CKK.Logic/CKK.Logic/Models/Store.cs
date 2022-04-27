using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {
        private List<StoreItem> _Items;
        public List<StoreItem> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
        public Store(string name = "default", int id = 0) : base(name, id)
        {
            _Items = new List<StoreItem>();
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            var matchingProduct = FindStoreItemById(prod.GetId()); //find the correct product in the list using other method            

            if (quantity < 0)
            {
                throw new InventoryItemStockTooLowException();
            }

            if (matchingProduct != null)
            {
                var _index = _Items.FindIndex(a => a.GetProduct() == prod); //set index of matching prod
                _Items[_index].SetQuantity(_Items[_index].GetQuantity() + quantity);//sets that slot at (matching index) as correct quant
                return _Items[_index]; //returns changed product
            }
            else // (matchingProduct == null)
            {
                _Items.Add(new StoreItem(prod, quantity));
                return _Items.Last(); //if no matching item, make new one at end(Last) and return it
            }
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            var matchingProduct = FindStoreItemById(id); //find the correct product in the list using other method 
            var _index = _Items.FindIndex(a => a.GetProduct().GetId() == id); //set index of matching prod id

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (matchingProduct != null)
            {
                if (_Items[_index].GetQuantity() > quantity)
                {
                    _Items[_index].SetQuantity(_Items[_index].GetQuantity() - quantity);
                    return _Items[_index];
                }
                else //the [if(_Items[_index].GetQuantity() <= quantity)] is implied
                {
                    _Items[_index].SetQuantity(0);
                    return _Items[_index];
                } //keeps the 0 quantity item
            }
            else
            {
                throw new ProductDoesNotExistException(); //if none match, throw exc
            } //if the list doesnt have that id, throw exception (if the product is not there/does not exist)            
        }

        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0) //invalid id throw exc
            {
                throw new InvalidIdException();
            }

            var GetIDSelect =
                    from value in _Items
                    select value.GetProduct().GetId(); //makes a collections ennumerable list of the ids that match 

            if (GetIDSelect.Contains(id))
            {
                int _index = _Items.FindIndex(a => a.GetProduct().GetId() == id); //set index of matching id
                return _Items[_index];
            }
            else { return null; }
        }

        public List<StoreItem> GetStoreItems()
        {
            return _Items;
        }
    }
}