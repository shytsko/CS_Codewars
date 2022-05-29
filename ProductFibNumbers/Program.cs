// The Fibonacci numbers are the numbers in the following integer sequence (Fn):
// 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ...
// such as
// F(n) = F(n-1) + F(n-2) with F(0) = 0 and F(1) = 1.
// Given a number, say prod (for product), we search two Fibonacci numbers F(n) and F(n+1) verifying
// F(n) * F(n+1) = prod.
// Your function productFib takes an integer (prod) and returns an array:
// [F(n), F(n+1), true] or {F(n), F(n+1), 1} or (F(n), F(n+1), True)
// depending on the language if F(n) * F(n+1) = prod.
// If you don't find two consecutive F(n) verifying F(n) * F(n+1) = prodyou will return
// [F(n), F(n+1), false] or {F(n), F(n+1), 0} or (F(n), F(n+1), False)
// F(n) being the smallest one such as F(n) * F(n+1) > prod.


Console.WriteLine(String.Join(" ", ProdFib.productFib(714)));   // {21, 34, 1}
Console.WriteLine(String.Join(" ", ProdFib.productFib(800)));   // {34, 55, 0}
Console.WriteLine(String.Join(" ", ProdFib.productFib(4895)));  // {55, 89, 1}
public class ProdFib
{
    public static ulong[] productFib(ulong prod)
    {
        ulong fibN = 0, fibNp1 = 1, fibNp2 = fibN + fibNp1;

        while (fibN * fibNp1 < prod)
        {
            fibN = fibNp1;
            fibNp1 = fibNp2;
            fibNp2 = fibN + fibNp1;
        }

        return new ulong[] { fibN, fibNp1, (fibN * fibNp1 == prod) ? (ulong)1 : (ulong)0 };
    }
}