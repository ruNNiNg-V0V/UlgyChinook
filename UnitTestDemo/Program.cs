using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    public class Program
    {
        static Dictionary<int, int> _dictinary = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(3));
            Console.WriteLine(Fib(3));

            // MS Unit Test
            // JUnit vs NUnit


            int sum = 0;

            for (int i = 1; i <= 10; i++)
            {
                sum += Factorial(i);
                sum += Fib(i);
            }

        }

        public static int Fib(int n)
        {
            if (n <= 2)
                return n;

            if (_dictinary.ContainsKey(n))
                return _dictinary[n];

            int result = Fib(n - 1) + Fib(n - 2);
            _dictinary.Add(n, result);
            return result;
        }

        public static int Factorial(int n)
        {
            return 0;
        }
    }
}
