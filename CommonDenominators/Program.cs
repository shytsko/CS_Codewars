// Common denominators
// You will have a list of rationals in the form
// { {numer_1, denom_1} , ... {numer_n, denom_n} }
// or
// [ [numer_1, denom_1] , ... [numer_n, denom_n] ]
// or
// [ (numer_1, denom_1) , ... (numer_n, denom_n) ]
// where all numbers are positive ints. You have to produce a result in the form:
// (N_1, D) ... (N_n, D)
// or
// [ [N_1, D] ... [N_n, D] ]
// or
// [ (N_1', D) , ... (N_n, D) ]
// or
// {{N_1, D} ... {N_n, D}}
// or
// "(N_1, D) ... (N_n, D)"
// depending on the language (See Example tests) in which D is as small as possible and
// N_1/D == numer_1/denom_1 ... N_n/D == numer_n,/denom_n.
// Example:
// convertFracs [(1, 2), (1, 3), (1, 4)] `shouldBe` [(6, 12), (4, 12), (3, 12)]
// Note:
// Due to the fact that the first translations were written long ago - more than 6 years - these first translations have only irreducible fractions.
// Newer translations have some reducible fractions. To be on the safe side it is better to do a bit more work by simplifying fractions even if they don't have to be.

long[,] lst = new long[,] { {1, 2}, {1, 3}, {1, 4} };
Console.WriteLine(Fracts.convertFrac(lst));

public class Fracts
{
    public static string convertFrac(long[,] lst)
    {
        long D = 1;
        for (int i = 0; i < lst.GetLength(0); i++)
            D = lcm(D, lst[i, 1] / gcd(lst[i, 0], lst[i, 1]));

        string result = string.Empty;

        for (int i = 0; i < lst.GetLength(0); i++)
            result += $"({D / lst[i, 1] * lst[i, 0]},{D})";
        
        return result;
    }

    private static long gcd(long a, long b)
    {
        if (a < b)
            (a, b) = (b, a);

        return (b != 0) ? gcd(b, a % b) : a;
    }

    private static long lcm(long a, long b)
    {
        return a / gcd(a, b) * b;
    }
}
