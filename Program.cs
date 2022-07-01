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

            //Reference Topics 
            
            List<string> list = new List<string>();
            list.Add(@"\0");
            list.Add(@"\b");
            list.Add("43");
            list.Add("AAAaaa111000");
            list.Add("AAAaaaZZZzzz");
            list.Add("4.33.4");
            list.Add("4.3");
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

            /*
            ReferenceTopics.MSRegexExample();
            */
        }

        /// <summary>
        /// Method <c>KeyValidate</c> allows keystrokes based on a pre-set group/range.
        /// It does not limit number of keystroke entries and terminates with ENTER. 
        /// </summary>
        static string KeyValidate(string validateString)
        {            
            switch (validateString)
            {
                case "num":
                    //validateString = "0123456789";
                    validateString = @"^[0-9]*$";
                    break;
                case "num&decimal":
                    //validateString = "0123456789.";
                    //validateString = @"^[0-9]*(\d*\.?\d)$";
                    validateString = @"^[+-]?((\d+(\.\d*)?)|(\.\d+))$";
                    break;
                case "alphaOnlyLowerCase":
                    //validateString = "qwertyuiopasdfghjklzxcvbnm";
                    validateString = @"^[a-z]*$";
                    break;
                case "alphaOnlyUpperCase":
                    //validateString = "QWERTYUIOPASDFGHJKLZXCVBNM";
                    validateString = @"^[A-Z]*$";
                    break;
                case "alphaOnlyNoNum":
                    //validateString = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
                    validateString = @"^[a-zA-Z]*$";
                    break;
                case "alphaNum":
                    validateString = @"^[a-zA-Z0-9]*(\d*\.?\d)$";
                    //validateString = @"^[a-zA-Z0-9]*(\.?\)$";                    
                    break;
                default:
                    //don't do anything with validateString
                    break;
            }            
            
            string consoleInput = "";
            ConsoleKeyInfo cki;
            string? keyInput = "";
            var regexItem = new Regex(validateString);
            //bool findMatch = false;

            do
            {
                cki = Console.ReadKey(true);
                keyInput = cki.KeyChar.ToString();
                string keyInputLiteral = @cki.KeyChar.@ToString();

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
                    if (regexItem.IsMatch(keyInputLiteral)) 
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
    }
}