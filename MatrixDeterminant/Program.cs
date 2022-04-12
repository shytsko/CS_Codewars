// https://www.codewars.com/kata/52a382ee44408cea2500074c
// The determinant of an n x n sized matrix is calculated by reducing the problem to the calculation of the determinants of n matrices ofn-1 x n-1 size.
// For the 3x3 case, [ [a, b, c], [d, e, f], [g, h, i] ] or
// |a b c|  
// |d e f|  
// |g h i|  
// the determinant is: a * det(a_minor) - b * det(b_minor) + c * det(c_minor) where det(a_minor) refers to taking
// the determinant of the 2x2 matrix created by crossing out the row and column in which the element a occurs:
// |- - -|
// |- e f|
// |- h i|  
// Note the alternation of signs.
// The determinant of larger matrices are calculated analogously, e.g. if M is a 4x4 matrix with first row [a, b, c, d], then:
// det(M) = a * det(a_minor) - b * det(b_minor) + c * det(c_minor) - d * det(d_minor)
using System;
using System.Collections.Generic;

int[][][] matrix =
{
    new int[][] { new [] { 1 } },
    new int[][] { new [] { 1, 3 }, new [] { 2, 5 } },
    new int[][] { new [] { 2, 5, 3 }, new [] { 1, -2, -1 }, new [] { 1, 3, 4 } }
};

int[] expected = { 1, -1, -20 };

Console.WriteLine(Matrix.Determinant(matrix[2]));

public class Matrix
{
    public static  int Determinant(int[][] matrix)
    {
        if(matrix.Length == 1)
            return matrix[0][0];

        int determinant = 0;
        int[][] minnor_matrix = new int[matrix.Length-1][];

        for(int i = 0; i<matrix.Length; i++)
        {
            for (int j = 1; j < matrix.Length; j++)
            {
                List<int> tmp = new List<int>(matrix[j]);
                tmp.RemoveAt(i);
                minnor_matrix[j-1] = tmp.ToArray();
            }
            determinant = (i%2 == 0) ? determinant + matrix[0][i] * Determinant(minnor_matrix) :  determinant - matrix[0][i] * Determinant(minnor_matrix);
        }

        return determinant;
     }
}