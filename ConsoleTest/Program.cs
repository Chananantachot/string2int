using System;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        private const string numberString = "0123456789";
        private static int position = 0;
        private static string text;

        static void Main(string[] args)
        {
            text = "b4vi00q2m9";

            var s = ParseNumber();
            Console.WriteLine(s);

            Console.ReadLine();
        }

        private static char Peek(int offset)
        {
            var index = position + offset;
            if(index >= text.Length)
                return text[index -1];

            return text[index];
        }

        private static char MoveNext()
        {
            var current = Peek(0);
            position++;
            return current;
        }

        private static string Parse()
        {
            if(position > text.Length - 1)
              return null;

            var current = MoveNext(); 
            if (ParseIndex(current) > -1)                
                return current.ToString() + Parse();
            return Parse();    
        }

        private static string ParseNumber()
        {          
            var sb = new StringBuilder();
            sb.Append(Parse());

            return sb.ToString();
        }
       
        private static int ParseIndex(char x)
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
