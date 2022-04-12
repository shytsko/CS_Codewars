// https://www.codewars.com/kata/54d4c8b08776e4ad92000835
// A perfect power is a classification of positive integers:

// In mathematics, a perfect power is a positive integer that can be expressed as an integer power of another positive integer.
// More formally, n is a perfect power if there exist natural numbers m > 1, and k > 1 such that m^k = n.

// Your task is to check wheter a given integer is a perfect power. If it is a perfect power, return a pair m and k with m^k = n as a proof.
// Otherwise return Nothing, Nil, null, NULL, None or your language's equivalent.

// Note: For a perfect power, there might be several pairs. For example 81 = 3^4 = 9^2, so (3,4) and (9,2) are valid solutions.
// However, the tests take care of this, so if a number is a perfect power, return any pair that proves it.

// Examples
// IsPerfectPower(4) => (2,2)
// IsPerfectPower(5) => null
// IsPerfectPower(8) => (2,3)
// IsPerfectPower(9) => (3,2)


using System;

Console.WriteLine(PerfectPower.IsPerfectPower(8));
public class PerfectPower
{
    public static (int, int)? IsPerfectPower(int n)
    {

        for (int m = 2; Math.Pow(m, 2) <= n; m++)
            for(int k = 2; Math.Pow(m,k) <= n; k++)
                if(Math.Pow(m, k) == n)
                    return (m, k);

        return null;
    }
}