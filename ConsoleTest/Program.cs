using System;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {          
            Test();
            Console.ReadLine();
        }

        static void Test()
        {
            var arrs = new string[]{ "iy57g8u8","8b4jv0v1","253zi3b9","w60fjtg7","5pf4eci9",
                                     "u43g2g6g","5m69ax7h","3y46fa1w","0a5p3lv2","lwqb357p","0a" };
            foreach (var s in arrs)
            {                  
               using(var parser = new Parser(s))
               {
                    var n = parser.Parse();                    
                    Console.WriteLine($"{s} --> {n}");  
               }                                                         
            }
        }
    }
}
