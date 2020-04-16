using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Customer
    {
        private int _customerId;
        private string _customerName;
        private double _walletBal;
        private List<Order> _orderhis;
        private Order _curOrder;

        public Customer(int customerId, string customerName, double walletBal, List<Order> orderhis)
        {
            _customerId = customerId;
            _customerName = customerName;
            _walletBal = walletBal;
            _orderhis = orderhis;
        }
        //afterorder
        public Customer(int customerId, string customerName, double walletBal, List<Order> orderhis, Order curOrder) : this(customerId, customerName, walletBal, orderhis)
        {
            _curOrder = curOrder;
        }

        public int CustomerId { get => _customerId; set => _customerId = value; }
        public string CustomerName { get => _customerName; set => _customerName = value; }
        public double WalletBal { get => _walletBal; set => _walletBal = value; }
        public List<Order> Orderhis { get => _orderhis; set => _orderhis = value; }
        public Order CurOrder { get => _curOrder; set => _curOrder = value; }


        //pay method

        public static bool Pay(double total, Customer cust)
        {
            bool isFlag = false;
            if (cust.WalletBal >= total)
            {
                isFlag = true;
            }
            return isFlag;
        }
        public string ToString(string format)
        {
            string result = null;
            switch (format)
            {
                case "X":
                    {
                        string arrayval = null;
                        foreach (var a in _orderhis)
                        {
                            arrayval = arrayval + a.ToString();
                        }
                        result = string.Format("\n" + CustomerId + "\t" + CustomerName + "\n" + arrayval);
                        break;
                    }

                case "Y":
                    {
                        result = string.Format("\n" + CustomerId + "\t" + CustomerName + "\t" + WalletBal);
                        break;
                    }
                    // ...
            }
            return result;
        }

        public override string ToString()
        {

            return string.Format("\n" + CustomerId + "\t" + CustomerName + "\t" + WalletBal + "\t");
        }


    }

}
