using System.Text.RegularExpressions;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEntryValidation
{
    /// <summary>
    /// ReferenceTopics is Code that was used to make this program and is a repository 
    /// of that code.  Rather than deleting code that helped write it and that is no
    /// longer needed, copied it to this class to keep it for reference if needed
    /// in the future.
    /// </summary>
    public class ReferenceTopics
    {
        //regexMatch method is an excellent TESTER of regex patterns. To RUN it use this
        //(expand section below if necessary):
        /*
        //Reference Topics             
        List<string> list = new List<string>();
        list.Add(@"\0");
        list.Add(@"\b");
        list.Add("43");
        list.Add("AAAaaa111000");
        list.Add("AAAaaaZZZzzz");
        list.Add("4.33.4");
        list.Add("4.3");
        list.Add(".43");
        list.Add("AAaa4.3");
        list.Add("AA.aa4.3");
        list.Add(".");

        string pattern = @"^[a-zA-Z0-9]*(\d*\.?\d)$";
        ReferenceTopics.regexMatch(list, pattern);
        pattern = @"^[a-zA-Z0-9]*$";
        ReferenceTopics.regexMatch(list, pattern);
        pattern = @"^[a-zA-Z]*$";
        ReferenceTopics.regexMatch(list, pattern);
        pattern = @"^[0-9]*$";
        ReferenceTopics.regexMatch(list, pattern);
        pattern = @"^[0-9]*(\d*\.?\d)$";
        ReferenceTopics.regexMatch(list, pattern);
        pattern = @"[\b]";  //not sure how to find this w/ regex, use console.key instead.
        ReferenceTopics.regexMatch(list, pattern);
        pattern = @"^[0-9.]*$";
        ReferenceTopics.regexMatch(list, pattern);
        pattern = @"^\d*\.?\d*$";
        ReferenceTopics.regexMatch(list, pattern);
        */

        /// <summary>
        /// regexMatch takes a list of strings and a string test pattern and uses
        /// Regex to check if the strings in listOfStrings match the pattern.  
        /// 
        /// Also, it prints out the strings and true/false if a match.
        /// </summary>
        /// <param name="listOfStrings"></param>
        /// <param name="patternToTest"></param>
        public static void regexMatch(List<string> listOfStrings, string patternToTest)
        {
            var regexItem = new Regex(patternToTest);
            Console.WriteLine("\n\nThe Regex Pattern is: {0}\n", patternToTest);

            bool findMatch = false;
            int index = 0;

            foreach (string item in listOfStrings)
            {
                index++;
                findMatch = false;
                if (regexItem.IsMatch(item))
                {
                    findMatch = true;
                }
                Console.WriteLine("{0}. The string {1} isMatch is: {2}", index, item, findMatch);
            }
        }

        /// <summary>
        /// Method NOT used in code, but left for reference.
        /// Used to show a Microsoft example from docs.microsoft.com...  etc.
        /// 
        /// To run this method in the MAIN method:  ReferenceTopics.MSRegexExample();
        /// 
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
        /// 
        /// To run this method in the MAIN method:  ReferenceTopics.PrintChars("Hello");
        /// Insert string to pass.  
        /// 
        /// </summary>
        /// <param name="s"></param>
        // here are some exmaples to run for PrintChars method:
        //ReferenceTopics.PrintChars("Hello");
        //Console.WriteLine();
        //ReferenceTopics.PrintChars(@"\0");
        //Console.WriteLine();
        //ReferenceTopics.PrintChars(@"\t");
        //Console.WriteLine();
        //ReferenceTopics.PrintChars(@"\");
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
