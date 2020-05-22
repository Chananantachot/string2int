using System;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        async static Task Main()
        {
            await Test();
            Console.ReadLine();
        }

        async static Task Test()
        {
            var arrs = new string[]{ "iy57g8u8","8b4jv0v1","253zi3b9","w60fjtg7","5pf4eci9",
                                     "u43g2g6g","5m69ax7h","3y46fa1w","0a5p3lv2","lwqb357p","0a" };
            foreach (var s in arrs)
            {                  
               using(var parser = new Parser(s))
               {
                    var n = await parser.ParseAsync();                    
                    Console.WriteLine($"{s} --> {n}");  
               }                                                         
            }
        }
    }
}
