using System;
using System.Globalization;
using System.Linq;

namespace ConsoleAppRunner
{
    public class StringHelper
    {
        public static Int32 ConvertToInt32(String number)
        {
            return Int32.Parse(
                number,
                NumberStyles.Integer,
                CultureInfo.CurrentCulture.NumberFormat);
        }

        public static bool IsValidWord(string word)
        {            
            return word.All(char.IsLower) && !word.Any(char.IsNumber);
        }
    }
}
