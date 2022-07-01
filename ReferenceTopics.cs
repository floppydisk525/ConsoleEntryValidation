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

        //delete dowhileloopcode once regex is implemented and working.  it's stricktly backup 7/1/22
        //   at 1:45pm.
        static void dowhileloopcode()
        {
            //do
            //{
            //    cki = Console.ReadKey(true);
            //    keyInput = cki.KeyChar.ToString();
            //    string keyInputLiteral = @cki.KeyChar.@ToString();

            //    //try regex stuff here.
            //    string pattern = @"^[a-zA-Z0-9\.?]*$";
            //    //pattern += @"\.?";
            //    var regexItem = new Regex(pattern);
            //    bool findMatch = false;
            //    if (regexItem.IsMatch(keyInputLiteral))
            //    {
            //        findMatch = true;
            //    }
            //    Console.WriteLine("findMatch character is: {0}", findMatch);

            //    if (cki.Key == ConsoleKey.Backspace)
            //    {
            //        //do stuff here
            //        if (consoleInput != "")
            //        {
            //            consoleInput = consoleInput.Remove(consoleInput.Length - 1, 1);
            //            //clear console LINE
            //            ClearLastLine();
            //            //write new variable console.write(consoleInput);
            //            Console.Write(consoleInput);
            //        }
            //    }
            //    //need to keep backspace from reaching this as it add's \b to it, which is bunk.
            //    else if (keyInput != null)
            //    {
            //        int lengthKeyInput = @keyInput.Length;
            //        int lengthKeyInputLiteral = @keyInputLiteral.Length;
            //        string cleaned = keyInput.Trim();
            //        int position = validateString.IndexOf(@keyInput);
            //        int positiontest = keyInput.IndexOf(validateString);
            //        string backslash = @"\";
            //        int posBackSlash = @backslash.IndexOf(@keyInput);
            //        int stringcompare = string.Compare(keyInput, backslash);
            //        //int posBackSlash = @keyInput.IndexOf(@backslash);

            //        bool findMatchConsoleInput = false;
            //        if (regexItem.IsMatch(keyInputLiteral))
            //        {
            //            findMatchConsoleInput = true;
            //        }
            //        Console.WriteLine("findMatch character is: {0}", findMatchConsoleInput);


            //        if (position != -1 && posBackSlash == -1)
            //        {
            //            consoleInput += keyInput;
            //            Console.Write(keyInput);
            //        }
            //    }
            //} while (cki.Key != ConsoleKey.Enter);
        }
    }
}
