using System;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        private const string numberString = "0123456789";
        static void Main(string[] args)
        {
            var str = "4vi00q2m9";

            var s = ParseNumber(str);
            Console.WriteLine(s);

            Console.ReadLine();
        }
  
        private static StringBuilder sb = new StringBuilder();
        private static string ParseNumber(string text, int position = 0)
        { 
            if (position <= text.Length - 1)
            {
                var current = text[position];
                position++;

                if (GetIndex(current) > -1)                    
                    sb.Append(current);

                ParseNumber(text, position);
            }
             return sb.ToString();        
        }

        private static int GetIndex(char x)
        {
            var arr = numberString.ToCharArray();
            var lower = 0;
            var upper = arr.Length - 1;
            while (lower <= upper)
            {
                var mid = lower + (upper - lower) / 2;
                var res = x.CompareTo(arr[mid]);

                // Check if x is present at mid  
                if (res == 0)
                    return mid;

                // If x greater, ignore left half  
                if (res > 0)
                    lower = mid + 1;

                // If x is smaller, ignore right half  
                else
                    upper = mid - 1;
            }
            return -1;
        }
    }
}
