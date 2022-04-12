// https://www.codewars.com/kata/587731fda577b3d1b0001196
// Write simple .camelCase method (camel_case function in PHP, CamelCase in C# or camelCase in Java) for strings.
// All words must have their first letter capitalized without spaces.

// For instance:

// camelCase("hello case"); // => "HelloCase"
// camelCase("camel case word"); // => "CamelCaseWord"
// Don't forget to rate this kata! Thanks :)

using System;
using System.Text;

Console.WriteLine(CamelCase("hello case"));
Console.WriteLine(CamelCase("camel case word"));


string CamelCase(string str)  
{  
    // if(str == "")
    //     return str;
    string[] subs = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    for(int i = 0; i<subs.Length; i++)
    {
        StringBuilder sb = new StringBuilder(subs[i]);
        sb[0] = Char.ToUpper(sb[0]);
        subs[i] = sb.ToString();
    }
    
    return String.Join("", subs);       
}
