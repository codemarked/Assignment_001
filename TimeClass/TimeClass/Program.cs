using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Time time1 = new Time(Console.ReadLine());
            Time time2 = new Time(Console.ReadLine());
            Console.WriteLine(time1 <= time2);
            Console.WriteLine(time1 >= time2);
            Console.WriteLine(time1 < time2);
            Console.WriteLine(time1 > time2);
            Console.WriteLine(time1 == time2);
            Console.WriteLine(time1 != time2);
            Console.WriteLine(time1 + time2);
            Console.WriteLine(time1 - time2);
            Console.WriteLine(time1.toString() + " " + time2.toString());
        }
    }
}
