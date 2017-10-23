using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    delegate void GetDate(string name);
    delegate double MathAction(double num);

    class Program
    {
        static double Double(double input)
        {
            return input * 2;
        }

        static void ShowDate(string name)
        {
            Console.WriteLine(name + DateTime.Now);
        }
        static void Main(string[] args)
        {
            MathAction ma = Double;
            double result = ma(4.5);

            Func<double, double> func = Double;
            double result2 = func(4.5);

            Func<double, double> resultFun = s => s * 2;
            double result3 = resultFun(4.5);

            Func<double, double> result4 = s => { return s * 2; };

            Func<string, string> StringTest = delegate (string s) { return s.ToString()+ "dddd"; };
            Console.WriteLine(StringTest("aa"));


            Func<string, string> convert = s => s.ToUpper();
            Console.WriteLine(convert("sdfsdf"));
            // Console.WriteLine(result + " " + result2 + " " + result3 + " " + result4(4.5));

            Func<double, double> result44 = s => s + 4;
            result44(32.3);

            Customer cust = new Customer();
            List<Customer> custs = new List<Customer>();
            custs.Add(new Customer() { Id = 1 });
            custs.Add(new Customer() { Id = 5 });
            custs.First(new Func<Customer, bool>(delegate (Customer x) { return x.Id == 5; }));
            custs.First(new Func<Customer, bool>((Customer x) => x.Id == 5));
            custs.First(delegate (Customer x) { return x.Id == 5; });
            cust = custs.First(x => x.Id == 5);
            custs.First(Customer.Test);

            // Console.WriteLine(cust.Id);
            //GetDate myDelegate = new GetDate(ShowDate);
            //myDelegate("Hello");

               new ShoppingCart().Process(new Func<bool, int>(Caculate.Calculate));

            new ShoppingCart().Process(new Func<bool, int>(delegate (bool x) { return x  ? 3 : 10; }));

            Console.ReadKey();
        }



    }
    class Customer
    {
        public int Id { get; set; }
        public static bool Test(Customer x)
        {

            return x.Id == 5;
        }
    }
    public class Caculate
    {
        public static int Calculate(bool special)
        {
            int discount = 0;
            if (DateTime.Now.Hour < 12)
            {
                discount = 5;
            }
            else if (DateTime.Now.Hour < 20)
            {
                discount = 10;
            }
            else if (special)
            {
                discount = 20;
            }
            else
                discount = 12;
            return discount;
        }

    }
    public class ShoppingCart
    {
        public void Process(Func<bool, int> discount)
        {
            int magicDiscount = discount(false);
            int magicDiscount2 = discount(true);
        }
    }
}
