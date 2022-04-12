// https://www.codewars.com/kata/523a86aa4230ebb5420001e1
// What is an anagram? Well, two words are anagrams of each other if they both contain the same letters. For example:
// 'abba' & 'baab' == true
// 'abba' & 'bbaa' == true
// 'abba' & 'abbba' == false
// 'abba' & 'abca' == false
// Write a function that will find all the anagrams of a word from a list. You will be given two inputs a word and an array with words. You should return an array of all the anagrams or an empty array if there are none. For example:
// anagrams('abba', ['aabb', 'abcd', 'bbaa', 'dada']) => ['aabb', 'bbaa']
// anagrams('racer', ['crazer', 'carer', 'racar', 'caers', 'racer']) => ['carer', 'racer']
// anagrams('laser', ['lazing', 'lazy',  'lacer']) => []


using System;
using System.Collections.Generic;

static void PrintList(List<string> list)
{
    foreach (var item in list)
        Console.Write(item + ", ");
    Console.WriteLine();
}

PrintList(Kata.Anagrams("a", new List<string> { "a", "b", "c", "d" }));
PrintList(Kata.Anagrams(
    "racer",
    new List<string>
    {
        "carer",
        "arcre",
        "carre",
        "racrs",
        "racers",
        "arceer",
        "raccer",
        "carrer",
        "cerarr"
    }
));

public static class Kata
{
    public static List<string> Anagrams(string word, List<string> words)
    {
        char[] chars = word.ToCharArray();
        Array.Sort(chars);
        string word_s = new string(chars);
        List<string> anagrams = new List<string>();

        foreach (string str in words)
        {
            chars = str.ToCharArray();
            Array.Sort(chars);
            if (word_s == new string(chars))
                anagrams.Add(str);
        }

        return anagrams;

        throw new NotImplementedException();
    }
}
