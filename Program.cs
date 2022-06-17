﻿// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using System.Globalization;

namespace ConsoleEntryValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^[a-zA-Z0-9]*(\d*\.?\d)$";
            Console.WriteLine("The Regex Pattern is: {0}\n", pattern);
            
            //pattern += @"\.?";
            var regexItem = new Regex(pattern);
            bool findMatch = false;
            string teststring = @"\0";
            if (regexItem.IsMatch(teststring))
            {
                findMatch = true;
            }
            Console.WriteLine("1. The string {0} isMatch is: {1}", teststring, findMatch);

            findMatch = false;
            teststring = "43";
            if (regexItem.IsMatch(teststring))
            {
                findMatch = true;
            }
            Console.WriteLine("2. The string {0} isMatch is: {1}", teststring, findMatch);

            findMatch = false;
            teststring = "AAAaaa111000";
            if (regexItem.IsMatch(teststring))
            {
                findMatch = true;
            }
            Console.WriteLine("3. The string {0} isMatch is: {1}", teststring, findMatch);

            //string pattern2 = @"^[a-zA-Z0-9]*\.?$"; // @"^\.?$";
            findMatch = false;
            //var regexItem = new Regex(pattern2);
            teststring = "4.33.4";
            if (regexItem.IsMatch(teststring))
            {
                findMatch = true;
            }
            Console.WriteLine("4. The string {0} isMatch is: {1}", teststring, findMatch);
                        
            findMatch = false;
            teststring = "4.3";
            if (regexItem.IsMatch(teststring))
            {
                findMatch = true;
            }
            Console.WriteLine("5. The string {0} isMatch is: {1}", teststring, findMatch);

            findMatch = false;
            teststring = "AAaa4.3";
            if (regexItem.IsMatch(teststring))
            {
                findMatch = true;
            }
            Console.WriteLine("6. The string {0} isMatch is: {1}", teststring, findMatch);

            findMatch = false;
            teststring = "AA.aa4.3";
            if (regexItem.IsMatch(teststring))
            {
                findMatch = true;
            }
            Console.WriteLine("7. The string {0} isMatch is: {1}", teststring, findMatch);

            Console.WriteLine("\nThe following EXAMPLE regex string is from a microsoft example located here:");
            Console.WriteLine("https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-6.0\n");
            NumberFormatInfo nfi = NumberFormatInfo.CurrentInfo;
            //pattern = @""
            pattern = @"^\s*[";
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

            //PrintChars("Hello");
            //Console.WriteLine();
            //PrintChars(@"\0");
            //Console.WriteLine();
            //PrintChars(@"\t");
            //Console.WriteLine();
            //PrintChars(@"\");

            //Console.WriteLine("Enter Only Digits followed by ENTER:");            
            //Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("num"));

            //Console.WriteLine("Enter Only Digits & a Decimal followed by ENTER:");
            //Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("num&period"));

            //Console.WriteLine("Enter Only Alpha Characters followed by ENTER:");
            //Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("alphaOnlyNoNum"));

            //Console.WriteLine("Enter Only integers 0 thru 4 followed by ENTER:");
            //Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("01234"));
        }

        /// <summary>
        /// Method <c>KeyValidate</c> allows keystrokes based on a pre-set group/range.
        /// It does not limit number of keystroke entries and terminates with ENTER. 
        /// </summary>
        static string KeyValidate(string validateString )
        {            
            switch (validateString)
            {
                case "num":
                    validateString = "0123456789";
                    break;
                case "num&period":
                    validateString = "0123456789.";
                    break;
                case "alphaOnlyLowerCase":
                    validateString = "qwertyuiopasdfghjklzxcvbnm";
                    break;
                case "alphaOnlyUpperCase":
                    validateString = "QWERTYUIOPASDFGHJKLZXCVBNM";
                    break;
                case "alphaOnlyNoNum":
                    validateString = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
                    break;
                default:
                    //don't do anything with validateString
                    break;
            }            
            
            string consoleInput = "";
            ConsoleKeyInfo cki;
            string? keyInput = "";

            do
            {
                cki = Console.ReadKey(true);
                keyInput = cki.KeyChar.ToString();
                string keyInputLiteral = @cki.KeyChar.@ToString();

                //try regex stuff here.
                string pattern = @"^[a-zA-Z0-9\.?]*$";
                //pattern += @"\.?";
                var regexItem = new Regex(pattern);
                bool findMatch = false;
                if (regexItem.IsMatch(keyInputLiteral)) 
                { 
                    findMatch = true;                     
                }
                Console.WriteLine("findMatch character is: {0}", findMatch);

                if (cki.Key == ConsoleKey.Backspace)
                {
                    //do stuff here
                    if (consoleInput != "")     
                    {
                        consoleInput = consoleInput.Remove(consoleInput.Length - 1, 1);
                        //clear console LINE
                        ClearLastLine();
                        //write new variable console.write(consoleInput);
                        Console.Write(consoleInput);
                    }
                }              
                //need to keep backspace from reaching this as it add's \b to it, which is bunk.
                else if(keyInput != null)
                {
                    int lengthKeyInput = @keyInput.Length;
                    int lengthKeyInputLiteral = @keyInputLiteral.Length;
                    string cleaned = keyInput.Trim();
                    int position = validateString.IndexOf(@keyInput);
                    int positiontest = keyInput.IndexOf(validateString);
                    string backslash = @"\";                    
                    int posBackSlash = @backslash.IndexOf(@keyInput);
                    int stringcompare = string.Compare(keyInput, backslash);
                    //int posBackSlash = @keyInput.IndexOf(@backslash);

                    bool findMatchConsoleInput = false;
                    if (regexItem.IsMatch(keyInputLiteral))
                    {
                        findMatchConsoleInput = true;
                    }
                    Console.WriteLine("findMatch character is: {0}", findMatchConsoleInput);


                    if (position != -1 && posBackSlash == -1) 
                    { 
                        consoleInput += keyInput;
                        Console.Write(keyInput);
                    }
                }
            } while (cki.Key != ConsoleKey.Enter);

            return consoleInput;
        }

        internal static void ClearLastLine()
        {
            int cursorTopPos = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }

        static void PrintChars(string s)
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