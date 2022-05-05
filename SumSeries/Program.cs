// https://www.codewars.com/kata/555eded1ad94b00403000071/train/csharp
// Task:
// Your task is to write a function which returns the sum of following series upto nth term(parameter).
// Series: 1 + 1/4 + 1/7 + 1/10 + 1/13 + 1/16 +...
// Rules:
// You need to round the answer to 2 decimal places and return it as String.
// If the given value is 0 then it should return 0.00
// You will only be given Natural Numbers as arguments.
// Examples:(Input --> Output)
// 1 --> 1 --> "1.00"
// 2 --> 1 + 1/4 --> "1.25"
// 5 --> 1 + 1/4 + 1/7 + 1/10 + 1/13 --> "1.57"

Console.WriteLine(NthSeries.seriesSum(0));
Console.WriteLine(NthSeries.seriesSum(1));
Console.WriteLine(NthSeries.seriesSum(2));
Console.WriteLine(NthSeries.seriesSum(5));
Console.WriteLine(NthSeries.seriesSum(9));
public class NthSeries
{

    public static string seriesSum(int n)
    {
        double result = 0;

        for (int i = 0; i < n; i++)
            result += 1.0 / (1 + 3 * i);

        return string.Format("{0:f2}", result);
    }
}
