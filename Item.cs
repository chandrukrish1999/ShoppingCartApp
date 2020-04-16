using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart


{
    class Item
    {
        private int _itemId;
        private string _itemName;
        private double _itemCost;
        private int _quantity;


        public Item(int itemId, string itemName, double itemCost)
        {
            _itemId = itemId;
            _itemName = itemName;
            _itemCost = itemCost;
        }

        public Item(int itemId, string itemName, double itemCost, int quantity) : this(itemId, itemName, itemCost)
        {
            _quantity = quantity;
        }

        public int ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
            }
        }
        //public int ItemId { get => _itemId; set => _itemId = value; }
        public string ItemName { get => _itemName; set => _itemName = value; }

        internal int ItemIds()
        {
            throw new NotImplementedException();
        }

        public double ItemCost { get => _itemCost; set => _itemCost = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        //for ordering



        public override string ToString()
        {
            return string.Format("\n" + _itemId + "\t" + _itemName + "\t" + _itemCost + "\t" + _quantity);
        }


    }
}