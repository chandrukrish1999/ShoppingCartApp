
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart

{
    class Product
    {
        private int _pId;
        private string _pName;
        private double _pBal;
        private List<Item> i;

        private Dictionary<Customer, Order> _listOfOrders;


        public Product(int PId, string PName, double PBal, List<Item> i)
        {
            _pId = PId;
            _pName = PName;
            _pBal = PBal;
            this.i = i;
        }

        public Product(int PId, string PName, double PBal, List<Item> i, Dictionary<Customer, Order> listOfOrders) : this(PId, PName, PBal, i)
        {
            _listOfOrders = listOfOrders;
        }

        public int RestId { get => _pId; set => _pId = value; }
        public string RestName { get => _pName; set => _pName = value; }
        public double RestBal { get => _pBal; set => _pBal = value; }
        internal List<Item> I { get => i; set => i = value; }
        internal Dictionary<Customer, Order> ListOfOrders { get => _listOfOrders; set => _listOfOrders = value; }
        //add cur order to list
        public static string AddOrderToRest(Customer cust, Product r1)
        {
            string arrayval = null;
            string result = null;
            foreach (var a in r1.ListOfOrders[cust].MenuItem)
            {
                arrayval = arrayval + a.ToString();
            }
            result = "Your details" + cust.ToString() + "\n" + "Cart details" + "\n" + r1.ListOfOrders[cust].OrderId + "\t" + r1.ListOfOrders[cust].OrderStatus + "\t items in cart" + "\n" + arrayval;

            return result;
        }
        public override string ToString()
        {
            string arrayval = null;
            foreach (var a in i)
            {
                arrayval = arrayval + a.ToString();
            }
            return string.Format("\n" + _pName + "\t" + _pId + "\n" + arrayval);
        }

    }
}