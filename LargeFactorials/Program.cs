// In mathematics, the factorial of integer n is written as n!. It is equal to the product of n and every integer preceding it.
// For example: 5! = 1 x 2 x 3 x 4 x 5 = 120

// Your mission is simple: write a function that takes an integer n and returns the value of n!.

// You are guaranteed an integer argument. For any values outside the non-negative range, return null, nil or None
// (return an empty string "" in C and C++). For non-negative numbers a full length number is expected for example,
// return 25! = "15511210043330985984000000" as a string.

// For more on factorials, see http://en.wikipedia.org/wiki/Factorial

// NOTES:
// The use of BigInteger or BigNumber functions has been disabled, this requires a complex solution
// I have r
using System;

Console.WriteLine(Kata.Factorial(15)); // 1307674368000
Console.WriteLine(Kata.Factorial(25)); // 15511210043330985984000000
Console.WriteLine(Kata.Factorial(0)); // 1
Console.WriteLine(Kata.Factorial(100));


public class Kata
{
    public static string Factorial(int n)
    {
        if (n >= 0)
        {
            string factorial = "1";
            while (n > 1)
            {
                factorial = MultStringInt(factorial, n);
                n--;
            }
            return factorial;
        }
        else
        {
            return String.Empty;
        }
    }

    private static string MultStringInt(string stringArgument, int intArgument)
    {
        string result = stringArgument;
        while (intArgument > 1)
        {
            result = SumStrings(result, stringArgument);
            intArgument--;
        }
        return result;
    }

    private static string SumStrings(string argument1, string argument2)
    {
        int length = Math.Max(argument1.Length, argument2.Length);
        argument1 = argument1.PadLeft(length, '0');
        argument2 = argument2.PadLeft(length, '0');
        int carry = 0;
        string result = String.Empty;
        for (int i = length - 1; i >= 0; i--)
        {
            int nextNumber = argument1[i] + argument2[i] - 2 * '0' + carry;
            carry = nextNumber / 10;
            nextNumber %= 10;
            result = nextNumber.ToString() + result;
        }

        return (carry == 0) ? result : "1" + result;
    }
}
