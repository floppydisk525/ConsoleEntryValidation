using System.Text.RegularExpressions;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEntryValidation
{
    public class ReferenceTopics
    {
        /// <summary>
        /// Method NOT used in code, but left for reference.
        /// Used to show a Microsoft example from docs.microsoft.com...  etc.
        /// </summary>
        public static void MSRegexExample()
        {
            Console.WriteLine("\nThe following EXAMPLE AAA regex string is from a microsoft example located here:");
            Console.WriteLine("https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-6.0\n");
            NumberFormatInfo nfi = NumberFormatInfo.CurrentInfo;

            //pattern = @""
            string pattern = @"^\s*[";
            // Get the positive and negative sign symbols.
            pattern += Regex.Escape(nfi.PositiveSign + nfi.NegativeSign) + @"]?\s?";
            // Get the currency symbol.
            pattern += Regex.Escape(nfi.CurrencySymbol) + @"?\s?";
            // Add integral digits to the pattern.
            pattern += @"(\d*";
            // Add the decimal separator.
            pattern += Regex.Escape(nfi.CurrencyDecimalSeparator) + "?";
            // Add the fractional digits.
            pattern += @"\d{";
            // Determine the number of fractional digits in currency values.
            pattern += nfi.CurrencyDecimalDigits.ToString() + "}?){1}$";
            Console.WriteLine(pattern);
            Console.WriteLine();
        }

        /// <summary>
        /// PrintChars Method prints out uxxxx value of characters of string passed in.
        /// Handy for string manipulation.
        /// </summary>
        /// <param name="s"></param>
        public static void PrintChars(string s)
        {
            Console.WriteLine($"\"{s}\".Length = {s.Length}");
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine($"s[{i}] = '{s[i]}' ('\\u{(int)s[i]:x4}')");
            }
            Console.WriteLine();
        }
    }
}
