// See https://aka.ms/new-console-template for more information

namespace ConsoleEntryValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Enter Only Digits followed by ENTER:");            
            Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("num"));

            Console.WriteLine("Enter Only Digits & a Decimal followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("num&dec"));

            Console.WriteLine("Enter Only Alpha Characters followed by ENTER:");

            Console.WriteLine("Enter Only integers 0 thru 4 followed by ENTER:");
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
                case "num&dec":
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

                if(keyInput != null)
                {
                    int position = validateString.IndexOf(keyInput);
                    if (position != -1) 
                    { 
                        consoleInput += keyInput;
                        Console.Write(keyInput);
                    }                    
                }
            } while (cki.Key != ConsoleKey.Enter);

            return consoleInput;
        }
    }
}

//look at consolekey for the keys!  