// https://www.codewars.com/kata/52597aa56021e91c93000cb0
// Write an algorithm that takes an array and moves all of the zeros to the end, preserving the order of the other elements.

// Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}) => new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}

using System.Collections.Generic;

void PrintArray(int[] a)
{
    Console.Write("{");
    foreach (var item in a)
        Console.Write($"{item}, ");

    Console.WriteLine("\b\b}");
}

PrintArray(MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}));

static int[] MoveZeroes(int[] arr)
{
    List<int> list = new List<int>(arr);

    int count_zeros = list.RemoveAll(x => x==0);
    list.AddRange(new int[count_zeros]);

    return list.ToArray();
}
