// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using System.Globalization;
using ConsoleValidationLibrary;

namespace ConsoleEntryValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Enter Only Digits followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", RegexKeyValidate.KeyValidate("num"));

            Console.WriteLine("Enter Only Digits & a Decimal followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", RegexKeyValidate.KeyValidate("num&decimal"));

            Console.WriteLine("Enter Only Alpha Characters followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", RegexKeyValidate.KeyValidate("alphaOnlyNoNum"));

            Console.WriteLine("Enter Only integers 0 thru 4 followed by ENTER:");
            Console.WriteLine("\nThe Digits entered are: {0}\n", RegexKeyValidate.KeyValidate(@"^[01234]*$"));
        }
    }
}