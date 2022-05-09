// Given a positive number n > 1 find the prime factor decomposition of n. The result will be a string with the following form :

//  "(p1**n1)(p2**n2)...(pk**nk)"
// with the p(i) in increasing order and n(i) empty if n(i) is 1.

// Example: n = 86240 should return "(2**5)(5)(7**2)(11)"
using System.Collections.Generic;

Console.WriteLine(PrimeDecomp.factors(86240));      // "(2**5)(5)(7**2)(11)"
Console.WriteLine(PrimeDecomp.factors(7775460));    // "(2**2)(3**3)(5)(7)(11**2)(17)"
Console.WriteLine(PrimeDecomp.factors(7919));    
Console.WriteLine(PrimeDecomp.factors(933555431));
Console.WriteLine(PrimeDecomp.factors(342217392));
Console.WriteLine(PrimeDecomp.factors(123456789));
Console.WriteLine(PrimeDecomp.factors(987654321));


public class PrimeDecomp
{
    public static String factors(int lst)
    {
        Dictionary<int, int> factorsDic = new Dictionary<int, int>();

        for (int i = 2; i <= Math.Sqrt(lst); i++)
        {
            while(lst % i == 0)
            {
                if (factorsDic.ContainsKey(i))
                    factorsDic[i]++;
                else
                    factorsDic.Add(i, 1);
                lst /= i;
            }
        }

        if(lst > 1)
            factorsDic.Add(lst, 1);

        string result = string.Empty;
        foreach (var item in factorsDic)
        {
            string pow =  item.Value > 1 ? $"**{item.Value}" : string.Empty;
            result += $"({item.Key}{pow})";
        }

        return result;
    }
}