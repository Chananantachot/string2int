using System;
using System.Text;

namespace ConsoleTest
{
    internal class Parser : IDisposable
    {
         private readonly char[] numbers;
         private int position;
         private readonly string _text;
       
        public Parser(string text)
        {
            numbers = "0123456789".ToCharArray();
            position = 0;
            _text =  text;
        }

        public void Dispose()
        {
           GC.SuppressFinalize(this); 
        }

        internal int Parse(int value = 0)
        {
            if(position > _text.Length - 1)
                return value;            
             
            var current = MoveNext(); 
            if (IsDigit(current))            
                value = value * 10 + (current - '0');                
            
            return Parse(value);    
        }      
        
        private bool IsDigit(char c) => Parse(numbers, c, 0, numbers.Length - 1) > -1;              

        private int Parse(char[] arr,char c, int lower, int upper)
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
                
            return Parse(arr, c,lower, upper);                   
        }

        private char MoveNext()
        {
            var current = Peek(0);
            position++;
            return current;
        }

        private char Peek(int offset)
        {
            var index = position + offset;
            if(index >= _text.Length)
                return _text[index -1];

            return _text[index];
        }
    }
}