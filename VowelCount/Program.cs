// Return the number (count) of vowels in the given string.
// We will consider a, e, i, o, u as vowels for this Kata (but not y).
// The input string will only consist of lower case letters and/or spaces.
using System.Collections.Generic;


Console.WriteLine(Kata.GetVowelCount("abracadabra"));

public static class Kata
{
    public static int GetVowelCount(string str)
    {
        int vowelCount = 0;
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        foreach (var item in str)
            if(vowels.Contains(item))
                vowelCount++;
        return vowelCount;
    }
}