// https://www.codewars.com/kata/523f5d21c841566fde000009
// Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.

// It should remove all values from list a, which are present in list b keeping their order.

// Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}
// If a value is present in b, all of its occurrences must be removed from the other:

// Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}


using System;
using System.Collections.Generic;

void PrintArray(int[] a)
{
    Console.Write("{");
    foreach (var item in a)
        Console.Write($"{item}, ");

    Console.WriteLine("\b\b}");
}

PrintArray(Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}));
PrintArray(Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}));

public class Kata
{
    public static int[] ArrayDiff(int[] a, int[] b)
    {
        List<int> res = new List<int>();

        foreach (int item in a)
            if (Array.IndexOf(b, item) < b.GetLowerBound(0))
                res.Add(item);

        return res.ToArray();
    }
}


