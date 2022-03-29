using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store
    {

        private int _id;
        private string _name;
        private List<StoreItem> Items;

        public Store()
        {
            Items = new List<StoreItem>();
        }

        public int GetId()
        {
            return _id;
        }
        public void SetId(int id)
        {
            _id = id;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity >= 0 && prod != null)
            {

                if (Items.Any())
                {
                    var GetProductSelect /*returns product*/= //enumerable type of a list of products
                            from value in Items
                            select value.GetProduct();

                    foreach (Product item in GetProductSelect) //for each item in that list
                    {

                        if (item == prod) //if your product matches prod
                        {

                            var _index = Items.FindIndex(a => a.GetProduct() == prod); //set index of matching prod

                            Items[_index].SetQuantity(Items[_index].GetQuantity() + quantity);
                            return Items[_index];
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Items.Add(new StoreItem(prod, quantity));
                    return Items.Last();
                }
                else
                {
                    Items.Add(new StoreItem(prod, quantity));
                    return Items[0];
                }
            }

            else { return null; }
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (Items.Any())
            {
                if (quantity > 0)
                {
                    var GetIDSelect /*ReturnsProductID*/ =
                        from value in Items
                        select value.GetProduct().GetId(); //ennumerable list of ids
                    foreach (var item in GetIDSelect) //for each item in that list
                    {

                        if (item == id) //if your id matches id
                        {
                            var _index = Items.FindIndex(a => a.GetProduct().GetId() == id); //set index of matching id


                            if (Items[_index].GetQuantity() > quantity)
                            {
                                Items[_index].SetQuantity(Items[_index].GetQuantity() - quantity);
                                return Items[_index];
                            }
                            if (Items[_index].GetQuantity() <= quantity)
                            {
                                Items[_index].SetQuantity(0);
                                return Items[_index];
                            }
                        }
                        else //if it doesnt match, go to next item
                        {
                            continue;
                        }
                    }
                    return null; //if nothing matches, return null
                }
                else { return null; } //if not removing any, nothing comes back
            }
            else { return null; } //if no items nothing comes back
        }

        public StoreItem FindStoreItemById(int id)
        {
            if (Items.Any())
            {
                var GetIDSelect =
                       from value in Items
                       select value.GetProduct().GetId(); //makes a collections ennumerable list of the ids
                foreach (var item in GetIDSelect)
                {
                    var _index = Items.FindIndex(a => a.GetProduct().GetId() == id); //set index of matching id

                    if (item == id)
                    {
                        return Items[_index];
                    }
                    else { continue; } //goes to next one

                }
                return null;  //no match no return                  
            }
            else { return null; } //no items no return
        }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }
    }
}
