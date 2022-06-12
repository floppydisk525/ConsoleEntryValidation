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
            Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("num&period"));

            Console.WriteLine("Enter Only Alpha Characters followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("alphaOnlyNoNum"));

            Console.WriteLine("Enter Only integers 0 thru 4 followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", KeyValidate("01234"));
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

                if(cki.Key == ConsoleKey.Backspace)
                {
                    //do stuff here
                    if (consoleInput != "")     
                    {
                        consoleInput = consoleInput.Remove(consoleInput.Length - 1, 1);
                        //clear console LINE
                        ClearLastLine();
                        //write new variable console.write(consoleInput);
                        Console.Write(keyInput);
                    }
                }              
                //need to keep backspace from reaching this as it add's \b to it, which is bunk.
                else if(keyInput != null)
                {
                    int position = validateString.IndexOf(keyInput);
                    int posBackSlash = keyInput.IndexOf("'\'");
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
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}