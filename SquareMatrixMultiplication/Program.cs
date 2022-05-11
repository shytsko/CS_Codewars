// Write a function that accepts two square (NxN) matrices (two dimensional arrays), and returns the product of
// the two. Only square matrices will be given.
// How to multiply two square matrices:
// We are given two matrices, A and B, of size 2x2 (note: tests are not limited to 2x2). Matrix C, the solution,
// will be equal to the product of A and B. To fill in cell [0][0] of matrix C, you need to compute:
// A[0][0] * B[0][0] + A[0][1] * B[1][0].
// More general: To fill in cell [n][m] of matrix C, you need to first multiply the elements in the nth row of
// matrix A by the elements in the mth column of matrix B, then take the sum of all those products. This will
// give you the value for cell [m][n] in matrix C.
// Example
//   A         B          C
// |1 2|  x  |3 2|  =  | 5 4|
// |3 2|     |1 1|     |11 8|
// Detailed calculation:
// C[0][0] = A[0][0] * B[0][0] + A[0][1] * B[1][0] = 1*3 + 2*1 =  5
// C[0][1] = A[0][0] * B[0][1] + A[0][1] * B[1][1] = 1*2 + 2*1 =  4
// C[1][0] = A[1][0] * B[0][0] + A[1][1] * B[1][0] = 3*3 + 2*1 = 11
// C[1][1] = A[1][0] * B[0][1] + A[1][1] * B[1][1] = 3*2 + 2*1 =  8


int[,] a = { { 1, 2 }, { 3, 2 } };
int[,] b = { { 3, 2 }, { 1, 1 } };

// int[,] expected = { { 5, 4 }, { 11, 8 } };
int[,] c = Kata.MatrixMultiplication(a, b);

for (int i = 0; i < c.GetLength(0); i++)
{
    for (int j = 0; j < c.GetLength(1); j++)

        Console.Write($"{c[i, j]} ");
    Console.WriteLine();
}

public class Kata
{
    public static int[,] MatrixMultiplication(int[,] a, int[,] b)
    {
        int size = a.GetLength(0);
        int[,] c = new int[size, size];

        for (int row = 0; row < size; row++)
            for (int col = 0; col < size; col++)
            {
                c[row, col] = 0;
                for (int i = 0; i < size; i++)
                    c[row, col] += a[row, i] * b[i, col];
            }

        return c;
    }
}
