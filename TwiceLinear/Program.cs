// Consider a sequence u where u is defined as follows:
// The number u(0) = 1 is the first one in u.
// For each x in u, then y = 2 * x + 1 and z = 3 * x + 1 must be in u too.
// There are no other numbers in u.
// Ex: u = [1, 3, 4, 7, 9, 10, 13, 15, 19, 21, 22, 27, ...]
// 1 gives 3 and 4, then 3 gives 7 and 10, 4 gives 9 and 13, then 7 gives 15 and 22 and so on...
// Task:
// Given parameter n the function dbl_linear (or dblLinear...) returns the element u(n) of the ordered (with <) sequence u (so, there are no duplicates).
// Example:
// dbl_linear(10) should return 22
// Note:
// Focus attention on efficiency
using System.Collections.Generic;
using System.Linq;

Console.WriteLine(DoubleLinear.DblLinear(10)); // 22
Console.WriteLine(DoubleLinear.DblLinear(20)); // 57
Console.WriteLine(DoubleLinear.DblLinear(30)); // 91
Console.WriteLine(DoubleLinear.DblLinear(50)); // 175
Console.WriteLine(DoubleLinear.DblLinear(0)); // 1
Console.WriteLine(DoubleLinear.DblLinear(100000)); // 1

public class DoubleLinear
{
    public static int DblLinear(int n)
    {
        SortedSet<int> dblLinearSequence = new SortedSet<int> { 1 };
        for (int i = 0; i < n; i++)
        {
            int nextItem = dblLinearSequence.First();
            dblLinearSequence.Remove(nextItem);
            int newItem = nextItem * 2 + 1;
            dblLinearSequence.Add(newItem);
            newItem += nextItem;
            dblLinearSequence.Add(newItem);
        }
        return dblLinearSequence.First();
    }
}
