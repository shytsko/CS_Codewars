// https://www.codewars.com/kata/525f4206b73515bffb000b21/train/csharp
// We need to sum big numbers and we require your help.
// Write a function that returns the sum of two numbers. The input numbers are strings and the function must return a string.
// Example
// add("123", "321"); -> "444"
// add("11", "99");   -> "110"
// Notes
// The input numbers are big.
// The input is a string of only digits
// The numbers are positives
using System;

    Console.WriteLine(Kata.Add("91", "19"));                // "110"
    Console.WriteLine(Kata.Add("123456789", "987654322"));  // "1111111111"
    Console.WriteLine(Kata.Add("999999999", "1"));          // "1000000000"
    Console.WriteLine(Kata.Add("24", "1"));                 // "25"

public class Kata
{
    public static string Add(string a, string b)
    {
        int len = Math.Max(a.Length, b.Length);
        a = a.PadLeft(len, '0');
        b = b.PadLeft(len, '0');
        int p = 0;
        string result = "";
        for (int i = len - 1; i >= 0; i--)
        {
            int dr = a[i] + b[i] - 2 * '0' + p;
            p = dr / 10;
            dr %= 10;
            result = dr.ToString() + result;
        }

        if(p == 0)
            return result;
        else
            return "1" + result;
    }
}
