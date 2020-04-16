using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Program
    {
        string name = "";
        string pass = "";
        string fname = "";
        string lname = "";
        string phno = "";
        string email = "";
        string pword = "";
        Boolean PasswordCheckup(String password)
        {
            char[] array = password.ToCharArray();
            int f = 0, f1 = 0, f2 = 0;
            foreach (char i in array)
            {
                if (char.IsDigit(i) == true)
                {
                    f++;
                }
                else if (char.IsLetter(i) == true)
                {
                    f1++;
                }
                else
                {
                    f2++;
                }
            }
            if (f == 0 || f1 == 0 || f2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        string SignUp()
        {
            Console.WriteLine("Yet to do");
            Console.WriteLine("Enter your first name");
            fname = Console.ReadLine();
            Console.WriteLine("Enter the last name");
            lname = Console.ReadLine();
            Console.WriteLine("Enter your phone number");
            phno = Console.ReadLine();
            Console.WriteLine("Enter your email Id");
            email = Console.ReadLine();
            Console.WriteLine("Enter the password(MUST REQUIRED--LETTER,NUMBER,SPEIAL CHARACTER--)");
            pword = Console.ReadLine();
            Boolean c = PasswordCheckup(pword);
            if (c == true)
            {
                return "success";
            }
            else
            {
                Console.WriteLine("INVALID FORMAT");
                SignUp();
                return "not success";
            }

        }
        void MainMenu()
        {

            Console.WriteLine("1..LOG IN\n2..SIGN UP");
            int ch = 0;
            try
            {
                ch = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("INVALID---OPTION");
                MainMenu();
            }
            if (ch == 1)
            {
                Console.WriteLine("Enter Username");
                name = Console.ReadLine();
                Console.WriteLine("Enter Password");
                pass = Console.ReadLine();
                if (name != "ram20" && pass != "password123")
                {
                    Console.WriteLine("Invalid credentials");
                    MainMenu();
                }
            }
            else if (ch == 2)
            {
                string val = SignUp();
                if (val.Equals("success"))
                {
                    Console.WriteLine("You have successfully registered as a new customer");
                    Console.WriteLine("Welcome " + fname);
                }
                else
                {
                    MainMenu();
                }
            }
            else
            {
                Console.WriteLine("INVALID---OPTION");
                MainMenu();
            }
            if (ch == 1 && (name == "ram20" && pass == "Password123") || ch == 2)
            {
                //Itemlist
                Item m1 = new Item(1, "IPhone XR", 150);
                Item m2 = new Item(2, "Oneplus 6T", 250);
                Item m3 = new Item(3, "Samsung M30", 350);
                List<Item> mlst = new List<Item>();
                mlst.Add(m1);
                mlst.Add(m2);
                mlst.Add(m3);
                Item m11 = new Item(1, "Macpro", 150);
                Item m21 = new Item(2, "Lenovo", 250);
                Item m31 = new Item(3, "Toshiba", 350);
                List<Item> mlst1 = new List<Item>();
                mlst1.Add(m11);
                mlst1.Add(m21);
                mlst1.Add(m31);
                Dictionary<Customer, Order> odlist = new Dictionary<Customer, Order>();
                //Productlist
                Product r1 = new Product(3, "Mobiles", 10000, mlst, odlist);
                Product r2 = new Product(3, "Laptops", 10000, mlst1, odlist);
                //orderhistory
                Order o1 = new Order();
                List<Order> olist = new List<Order>();
                olist.Add(o1);
                //customer
                var ap = true;
                while (ap)
                {
                    Customer c1 = new Customer(1, "Ragul", 500, olist);
                    List<Customer> custlist = new List<Customer>();
                    custlist.Add(c1);
                    int id = 1;
                    Customer c = custlist.Find(x => x.CustomerId == id);
                    Console.WriteLine("Categorise Of Products");
                    Console.WriteLine("1.Mobiles\n2.Laptops");
                    int q = 0;
                    q = int.Parse(Console.ReadLine());
                    if (q == 1)
                    {
                        Console.WriteLine(r1.ToString());
                    }
                    else if (q == 2)
                    {
                        Console.WriteLine(r2.ToString());
                    }
                    else
                    {
                        Console.WriteLine("INVALID OPTION");
                    }
                    int res = 0;
                    int quantity = 0;
                    List<Item> menuitem = new List<Item>();
                    do
                    {
                        Console.WriteLine("Enter the item id");
                        int x1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the quantity.");
                        quantity = int.Parse(Console.ReadLine());
                        if (q == 1)
                        {
                            Item me = r1.I.Find(x => x.ItemId == x1);
                            me.Quantity = quantity;
                            menuitem.Add(me);
                        }
                        else
                        {
                            Item me = r2.I.Find(x => x.ItemId == x1);
                            me.Quantity = quantity;
                            menuitem.Add(me);
                        }
                        Console.WriteLine("Press 1 to add more items......2.to continue");
                        res = int.Parse(Console.ReadLine());

                    } while (res == 1);
                    double total = Order.CalculateTotal(menuitem);
                    Console.WriteLine("Total amountis " + total);
                    Order.PlaceOrder(menuitem, total, c, r1);
                    Console.WriteLine(Product.AddOrderToRest(c, r1));
                    Console.WriteLine("Press 1 to placeorder or 2 to Exit");
                    int a = int.Parse(Console.ReadLine());
                    if (a == 1)
                    {
                        Console.WriteLine("Order Placed");
                    }
                    else
                    {
                        Console.WriteLine("Order not placed");
                    }
                    Console.WriteLine("Press 1 To Continue Shopping");
                    int cp = Convert.ToInt32(Console.ReadLine());
                    if (cp == 2)
                    {
                        ap = false;
                    }
                    else
                    {
                        ap = true;
                    }
                }
            }
            else if (ch == 3)
            {
                Environment.Exit(1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("---------------WELCOME TO SHOPPING CART-----------------");
            Console.WriteLine("--------------------------------------------------------");
            Program program = new Program();
            program.MainMenu();
            Console.ReadLine();
        }
    }
}
