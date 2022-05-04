// https://www.codewars.com/kata/54b42f9314d9229fd6000d9c/train/csharp
// The goal of this exercise is to convert a string to a new string where each character in the new string is "("
// if that character appears only once in the original string, or ")" if that character appears more than once in
// the original string. Ignore capitalization when determining if a character is a duplicate.
// Examples
// "din"      =>  "((("
// "recede"   =>  "()()()"
// "Success"  =>  ")())())"
// "(( @"     =>  "))((" 
// Notes
// Assertion messages may be unclear about what they display in some languages. If you read 
// "...It Should encode XXX", the "XXX" is the expected result, not the input!

using System.Text;
using System.Collections.Generic;


Console.WriteLine(Kata.DuplicateEncode("din"));     // "((("
Console.WriteLine(Kata.DuplicateEncode("recede"));  // "()()()"
Console.WriteLine(Kata.DuplicateEncode("Success")); // ")())())"
Console.WriteLine(Kata.DuplicateEncode("(( @"));    // "))(("

public class Kata
{
    public static string DuplicateEncode(string word)
    {
        StringBuilder tempString = new StringBuilder(word.ToLower());
        Dictionary<char, int> countChar = new Dictionary<char, int>();

        for (int i = 0; i < tempString.Length; i++)
            if (countChar.ContainsKey(tempString[i]))
                countChar[tempString[i]]++;
            else
                countChar.Add(tempString[i], 1);

        for (int i = 0; i < tempString.Length; i++)
            tempString[i] = (countChar[tempString[i]] > 1) ? ')' : '(';

        return tempString.ToString();
    }
}