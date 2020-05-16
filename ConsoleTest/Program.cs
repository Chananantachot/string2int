﻿using System;
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
            Test();
            Console.ReadLine();
        }

        static void Test()
        {
            var arrs = new string[]{ "iy57g8u8","8b4jv0v1","253zi3b9","w60fjtg7","5pf4eci9",
                                     "u43g2g6g","5m69ax7h","3y46fa1w","0a5p3lv2","lwqb357p"};
            foreach (var arr in arrs)
            {                  
                text = arr;
                var s = ParseNumber();
                Console.WriteLine($"{text} --> {s}");
                text = string.Empty;                         
            }
        }
        
        private static string ParseNumber() => new StringBuilder().Append(Parse()).ToString();

        private static string Parse()
        {
            if(position > text.Length - 1)
            {
                position = 0;
                return null;
            }
             
            var current = MoveNext(); 
            if (ParseIndex(current) > -1)                
                return current.ToString() + Parse();

            return Parse();    
        }

        private static int ParseIndex(char x)
        {           
            var arr = numberString.ToCharArray();
            return GetIndex(arr, x,0, arr.Length - 1);
        }

        private static int GetIndex(char[] arr,char c, int lower, int upper)
        {
            if(lower > upper)
                return -1;

            var mid = lower + (upper - lower) / 2;
            var index = c.CompareTo(arr[mid]);   

            if (index == 0)
                return mid;


            if (index > 0)            
                lower = mid + 1;                            
            else         
                upper = mid - 1;
                

            return GetIndex(arr, c,lower, upper);                   
        }

        private static char MoveNext()
        {
            var current = Peek(0);
            position++;
            return current;
        }

        private static char Peek(int offset)
        {
            var index = position + offset;
            if(index >= text.Length)
                return text[index -1];

            return text[index];
        }
    }
}
