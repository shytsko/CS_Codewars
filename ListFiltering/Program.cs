// In this kata you will create a function that takes a list of non-negative integers and strings and returns a new list with the strings filtered out.

// Example
// ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b"}) => {1, 2}
// ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", 0, 15}) => {1, 2, 0, 15}
// ListFilterer.GetIntegersFromList(new List<object>(){1, 2, "a", "b", "aasf", "1", "123", 231}) => {1, 2, 231}

using System.Collections;
using System.Collections.Generic;

foreach (var item in ListFilterer.GetIntegersFromList(new List<object>() { 1, 2, "a", "b" }))
    Console.Write($"{item} ");
Console.WriteLine();
foreach (var item in ListFilterer.GetIntegersFromList(new List<object>() { 1, 2, "a", "b", 0, 15 }))
    Console.Write($"{item} ");
Console.WriteLine();
foreach (
    var item in ListFilterer.GetIntegersFromList(
        new List<object>() { 1, 2, "a", "b", "aasf", "1", "123", 231 }
    )
)
    Console.Write($"{item} ");

public class ListFilterer
{
    public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
    {
        foreach (var item in listOfItems)
        {
            if (item is int)
                yield return (int)item;
        }
    }
}
