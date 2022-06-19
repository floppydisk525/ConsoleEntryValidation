# ConsoleEntryValidation
Small Console Application to Parse and Validate Key Strokes for the Console.  
  
## OVERVIEW  
Console appliction that uses REGEX to read string input and determine if it meets a desired pattern such as only alpha characters (A-Z or a-z) or meets a number with or without a decimal.  
  
The program orginially tried to use IndexOf or string.compare, but ran into issues with escape characters "\\".  
  
## HELPFUL LINKS  
This is a good one with a nice example:  
https://stackoverflow.com/questions/12117024/decimal-number-regular-expression-where-digit-after-decimal-is-optional  
  
https://regex101.com/  
  
https://stackoverflow.com/questions/4503542/check-for-special-characters-in-a-string  
This example has the screen shot in RefMat folder.  
var regexItem = new Regex("^[a-zA-Z0-9 ]*$");  
if(regexItem.IsMatch(YOUR_STRING)){..}  