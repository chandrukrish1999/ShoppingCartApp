using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart

{
    class Order
    {
        private int _orderId;
        private string _orderStatus;
        private List<Item> _menuItem;
        private double _total;
        private Customer _cust;
        private List<Customer> _orderlist;
        private static int oid = 100;
        public int OrderId { get => _orderId; set => _orderId = value; }
        public string OrderStatus { get => _orderStatus; set => _orderStatus = value; }
        internal List<Item> MenuItem { get => _menuItem; set => _menuItem = value; }
        public double Total { get => _total; set => _total = value; }
        public double Total1 { get => _total; set => _total = value; }
        internal Customer Cust { get => _cust; set => _cust = value; }
        internal List<Customer> Orderlist { get => _orderlist; set => _orderlist = value; }

        public Order(string orderStatus, List<Item> menuItem, double total, Customer cust)
        {
            oid++;
            _orderId = _orderId + oid;
            _orderStatus = orderStatus;
            _menuItem = menuItem;
            _total = total;
            _cust = cust;
        }

        public Order()
        {

        }
        public static double CalculateTotal(List<Item> menulist)
        {
            double tot = 0;
            foreach (var a in menulist)
            {
                tot = tot + (a.ItemCost * a.Quantity);
            }
            return tot;
        }
        public static string PlaceOrder(List<Item> menulist, double total, Customer cust, Product r1)
        {
            string result = "insufficient balance";


            Order o = new Order();
            if (Customer.Pay(total, cust) == true)
            {
                Order order = new Order("List Of", menulist, total, cust);
                cust.CurOrder = order;
                cust.Orderhis.Add(order);
                r1.ListOfOrders.Add(cust, order);
                //display order
                result = "\n" + order.ToString();
            }
            return result;

        }

        public override string ToString()
        {
            string arrayval = null;
            foreach (var a in _menuItem)
            {
                arrayval = arrayval + a.ToString();
            }
            return string.Format("\n" + _orderId + "\t" + _orderStatus + "\t" + Total + "\n" + arrayval);
        }

    }
}