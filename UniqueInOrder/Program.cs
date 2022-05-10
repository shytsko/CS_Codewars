// Implement the function unique_in_order which takes as argument a sequence and returns a list
// of items without any elements with the same value next to each other and preserving the original order of elements.

// For example:

// uniqueInOrder("AAAABBBCCDAABBB") == {'A', 'B', 'C', 'D', 'A', 'B'}
// uniqueInOrder("ABBCcAD")         == {'A', 'B', 'C', 'c', 'A', 'D'}
// uniqueInOrder([1,2,2,3,3])       == {1,2,3}


using System.Collections.Generic;

Console.WriteLine(string.Join(", ", Kata.UniqueInOrder("AAAABBBCCDAABBB")));
Console.WriteLine(string.Join(", ", Kata.UniqueInOrder(""))); 

public static class Kata
{
    public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
    {
        T[] array = iterable.ToArray();
        List<T> list = new List<T>();

        if (array.Length > 0)
        {
            list.Add(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                if (!array[i].Equals(array[i - 1]))
                    list.Add(array[i]);
            }
        }

        return list;
    }
}
