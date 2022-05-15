// Write a function called sumIntervals/sum_intervals() that accepts an array of intervals, and returns the sum of all
// the interval lengths. Overlapping intervals should only be counted once.

// Intervals
// Intervals are represented by a pair of integers in the form of an array. The first value of the interval will always
// be less than the second value. Interval example: [1, 5] is an interval from 1 to 5. The length of this interval is 4.

// Overlapping Intervals
// List containing overlapping intervals:
// [
//    [1,4],
//    [7, 10],
//    [3, 5]
// ]
// The sum of the lengths of these intervals is 7. Since [1, 4] and [3, 5] overlap, we can treat the interval as [1, 5],
// which has a length of 4.
using System.Linq;

using Interval = System.ValueTuple<int, int>;

Console.WriteLine(Intervals.SumIntervals(new Interval[] { (1, 6), (10, 20), (1, 5), (16, 19), (5, 11) })); // 19
Console.WriteLine(Intervals.SumIntervals(new Interval[] { (2, 5), (-1, 2), (-40, -35), (6, 8) })); // 13
Console.WriteLine(Intervals.SumIntervals(new Interval[] { (-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26) })); // 158
Console.WriteLine(Intervals.SumIntervals(new Interval[] { (-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338) })); // 1234
Console.WriteLine(Intervals.SumIntervals(new Interval[] { })); // 0
Console.WriteLine(Intervals.SumIntervals(new Interval[] { (4, 4), (6, 6), (8, 8) })); // 0
Console.WriteLine(Intervals.SumIntervals(new Interval[] { (1, 2), (6, 10), (11, 15) })); // 9

public class Intervals
{
    public static int SumIntervals((int, int)[] intervals)
    {
        (int, int)[] cloneIntervals = ((int, int)[])intervals.Clone();
        Array.Sort(cloneIntervals);
        int sum = 0;
        int endPrev = int.MinValue;
        foreach ((int, int) interval in cloneIntervals)
        {
            if (interval.Item2 > endPrev)
            {
                sum += (interval.Item1 > endPrev)
                        ? (interval.Item2 - interval.Item1)
                        : (interval.Item2 - endPrev);
                endPrev = interval.Item2;
            }
        }
        return sum;
    }
}