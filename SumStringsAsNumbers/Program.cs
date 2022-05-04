// https://www.codewars.com/kata/5324945e2ece5e1f32000370/csharp
// Given the string representations of two integers, return the string representation of the sum of those integers.
// For example:
// sumStrings('1','2') // => '3'
// A string representation of an integer will contain no characters besides the ten numerals "0" to "9".

using System;

Console.WriteLine(Kata.sumStrings("0123","456"));

public static class Kata
{
    public static string sumStrings(string a, string b)
    {
        a = a.TrimStart('0');
        b = b.TrimStart('0');
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

        if (p == 0)
            return result;
        else
            return "1" + result;
    }
}