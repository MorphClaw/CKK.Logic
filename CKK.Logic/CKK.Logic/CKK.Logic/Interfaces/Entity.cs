using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {
        private int _id;
        private string _name;

        public Entity(string name = "default", int id = 0)
        {
            _id = id;
            _name = name;
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidIdException();
                }
                else
                {
                    _id = value;
                }
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;                
            }
        }

        public int GetId()
        {
            return _id;
        }
        public void SetId(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }
            else
            {
                _id = id;
            }
        }
        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }
    }
}