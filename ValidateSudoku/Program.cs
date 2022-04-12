// https://www.codewars.com/kata/540afbe2dc9f615d5e000425
// Given a Sudoku data structure with size NxN, N > 0 and √N == integer, write a method to validate if it has been filled out correctly.
// The data structure is a multi-dimensional Array, i.e:

// [
//   [7,8,4,  1,5,9,  3,2,6],
//   [5,3,9,  6,7,2,  8,4,1],
//   [6,1,2,  4,3,8,  7,5,9],
  
//   [9,2,8,  7,1,5,  4,6,3],
//   [3,5,7,  8,4,6,  1,9,2],
//   [4,6,1,  9,2,3,  5,8,7],
  
//   [8,7,6,  3,9,4,  2,1,5],
//   [2,4,3,  5,6,1,  9,7,8],
//   [1,9,5,  2,8,7,  6,3,4]
// ]
// Rules for validation
// Data structure dimension: NxN where N > 0 and √N == integer
// Rows may only contain integers: 1..N (N included)
// Columns may only contain integers: 1..N (N included)
// 'Little squares' (3x3 in example above) may also only contain integers: 1..N (N included)

using System;
using System.Collections.Generic;

var goodSudoku1 = new Sudoku(
    new int[][] {
    new int[] {7,8,4, 1,5,9, 3,2,6},
    new int[] {5,3,9, 6,7,2, 8,4,1},
    new int[] {6,1,2, 4,3,8, 7,5,9},

    new int[] {9,2,8, 7,1,5, 4,6,3},
    new int[] {3,5,7, 8,4,6, 1,9,2},
    new int[] {4,6,1, 9,2,3, 5,8,7},
    
    new int[] {8,7,6, 3,9,4, 2,1,5},
    new int[] {2,4,3, 5,6,1, 9,7,8},
    new int[] {1,9,5, 2,8,7, 6,3,4}
    });
Console.WriteLine(goodSudoku1.IsValid());
  
var goodSudoku2 = new Sudoku(
    new int[][] {
    new int[] {1,4, 2,3},
    new int[] {3,2, 4,1},

    new int[] {4,1, 3,2},
    new int[] {2,3, 1,4}
});    
Console.WriteLine(goodSudoku2.IsValid());

  
var badSudoku1 = new Sudoku(
    new int[][] {
    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9},

    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9},
    
    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9},
    new int[] {1,2,3, 4,5,6, 7,8,9}
    });
Console.WriteLine(badSudoku1.IsValid());


var badSudoku2 = new Sudoku(
    new int[][] {
    new int[] {1,2,3,4,5},
    new int[] {1,2,3,4},

    new int[] {1,2,3,4},
    new int[] {1}
});   
Console.WriteLine(badSudoku2.IsValid());

class Sudoku
{
    private int[][] sudoku;
    private int N;
    private int n;

    public Sudoku(int[][] sudokuData)
    {
        //Constructor here
        sudoku = sudokuData;
        N = sudoku.Length;
        n = System.Convert.ToUInt16(Math.Sqrt(N));
    }

    public bool IsValid()
    {   
        if(n*n != N)
            return false;

        for (int i = 0; i < N; i++)
            if(sudoku[i].Length != N || !CheckRow(i) || !CheckColumn(i))
                return false;

        for (int i = 0; i < N; i+=n)
            for (int j = 0; j < N; j+=n)
                if(!CheckSqr(i, j))
                    return false;

        return true;
        throw new NotImplementedException();
    }

    private bool CheckRow(int row)
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < N; i++)
            if (!set.Add(sudoku[row][i]) || sudoku[row][i] < 1 || sudoku[row][i] > N)
                return false;
        return true;
    }

    private bool CheckColumn(int column)
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < N; i++)
            if (!set.Add(sudoku[i][column]) || sudoku[i][column] < 1 || sudoku[i][column] > N)
                return false;
        return true;
    }

    private bool CheckSqr(int row, int column)
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = row; i <row + n; i++)
            for (int j = column; j < column + n; j++)
                if(!set.Add(sudoku[i][j]) || sudoku[i][j] < 1 || sudoku[i][j] > N)
                    return false;
        return true;
    }
}