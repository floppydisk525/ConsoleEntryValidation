// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using System.Globalization;

namespace ConsoleEntryValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Enter Only Digits followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("num"));

            Console.WriteLine("Enter Only Digits & a Decimal followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("num&decimal"));

            Console.WriteLine("Enter Only Alpha Characters followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("alphaOnlyNoNum"));

            Console.WriteLine("Enter Only integers 0 thru 4 followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate(@"^[01234]*$"));
        }

        /// <summary>
        /// Method <c>KeyValidate</c> allows keystrokes based on a pre-set group/range.
        /// It does not limit number of keystroke entries and terminates with ENTER. 
        /// </summary>
        static string KeyValidate(string validateString)
        {
            string pattern;
            switch (validateString)
            {
                case "num":
                    pattern = @"^[0-9]*$";
                    break;
                case "num&decimal":
                    //this one is more strict.   Will not allow only '.', or ".#".  Go w/ more
                    //lose def of pattern below.  
                    //pattern = @"^[0-9]*(\d*\.?\d)$";   
                    pattern = @"^\d*\.?\d*$";
                    break;
                case "alphaOnlyLowerCase":
                    pattern = @"^[a-z]*$";
                    break;
                case "alphaOnlyUpperCase":
                    pattern = @"^[A-Z]*$";
                    break;
                case "alphaOnlyNoNum":
                    pattern = @"^[a-zA-Z]*$";
                    break;
                case "alphaNum":
                    pattern = @"^[a-zA-Z0-9]*(\d*\.?\d)$";                 
                    break;
                default:
                    //assign custom pattern
                    pattern = validateString;
                    break;
            }            
            
            string consoleInput = "";
            string inputDecimalCheck = "";
            ConsoleKeyInfo cki;
            string? keyInput = "";
            var regexItem = new Regex(pattern);

            do
            {
                cki = Console.ReadKey(true);
                keyInput = cki.KeyChar.ToString();
                string keyInputLiteral = @cki.KeyChar.@ToString();                

                if (cki.Key == ConsoleKey.Backspace)    //check if backspace entered & delete last char
                {
                    if (consoleInput != "")     
                    {
                        consoleInput = consoleInput.Remove(consoleInput.Length - 1, 1);
                        //clear console LINE
                        ClearLastLine();
                        //write new variable console.write(consoleInput);
                        Console.Write(consoleInput);
                    }
                }
                else if(keyInput != null)
                {
                    //The following check could be 'a problem' based on the regex pattern used
                    //  to check the string against.  For exmpale, it will FAIL if you 
                    // want a decimal using @"^[0-9]*(\d*\.?\d)$" because that pattern will
                    //  always be false for a '.' only and never enter this loop.  
                    //  for this program, I don't care, but it might matter for different needs.
                    if (regexItem.IsMatch(keyInputLiteral)) 
                    {
                        inputDecimalCheck = consoleInput + keyInput;
                        if (regexItem.IsMatch(inputDecimalCheck))
                        {
                            consoleInput += keyInput;
                            Console.Write(keyInput);
                        }
                    }
                }
            } while (cki.Key != ConsoleKey.Enter);

            return consoleInput;
        }

        /// <summary>
        /// Small method to clear the existing console line when using 
        /// backspace.  Then, the program above will 're-write' the line
        /// </summary>
        internal static void ClearLastLine()
        {
            int cursorTopPos = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}