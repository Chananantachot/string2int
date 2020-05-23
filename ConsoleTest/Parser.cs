using System;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class Parser : IDisposable
    {
         private readonly char[] numbers;
         private int position;
         private readonly string _text;
         private readonly int _length;
        public Parser(string text)
        {
            numbers = new char[] {'0','1','2','3','4','5','6','7','8','9' };
            position = 0;
            _text =  text;
            _length = _text.Length - 1;
        }

        public void Dispose() => GC.SuppressFinalize(this);

        internal async Task<int> ParseAsync(int value = 0)
        {           
            if (position > _length)
                return value;

            var current = MoveNext();
            if (await IsDigit(current))
                value = value * 10 + (current - '0');

            return await ParseAsync(value);
        }

        private async Task<bool> IsDigit(char c) => await Parse(numbers, c, 0, 9) > -1;              

        private async Task<int> Parse(char[] arr,char c, int lower, int upper)
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
                
            return await Parse(arr, c,lower, upper);                   
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
            if(index > _length)
                return _text[_length];

            return _text[index];
        }
    }
}