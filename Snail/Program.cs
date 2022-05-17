// Snail Sort
// Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

// array = [[1,2,3],
//          [4,5,6],
//          [7,8,9]]
// snail(array) #=> [1,2,3,6,9,8,7,4,5]
// For better understanding, please follow the numbers of the next array consecutively:

// array = [[1,2,3],
//          [8,9,4],
//          [7,6,5]]
// snail(array) #=> [1,2,3,4,5,6,7,8,9]

int[][] array =
{
    new[] { 117, 18,  419, 898, 511, 248 },
    new[] { 716, 817, 850, 107, 803, 375 },
    new[] { 754, 745, 968, 410, 301, 56 },
    new[] { 816, 107, 482, 916, 894, 662 },
    new[] { 277, 923, 532, 371, 371, 242 },
    new[] { 32,  190, 973, 97,  781, 4 }
};
int[] array2 = SnailSolution.Snail(array);
Console.WriteLine(String.Join(" ", array2)); //[1,2,3,6,9,8,7,4,5]

public class SnailSolution
{
    enum Direction
    {
        Right = 0,
        Down = 1,
        Left = 2,
        Up = 3
    }

    public static int[] Snail(int[][] array)
    {
        int[] resultArray = new int[array.Length * array[0].Length];
        int resultIndex = 0;
        int[,] directionStep = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        Direction direction = Direction.Right;
        int row = 0,
            col = 0,
            rowMin = 1,
            rowMax = array.Length - 1,
            colMin = 0,
            colMax = array[0].Length - 1;

        for (resultIndex = 0; resultIndex < resultArray.Length; resultIndex++)
        {
            resultArray[resultIndex] = array[row][col];
            if (direction == Direction.Right && col == colMax)
            {
                direction = Direction.Down;
                colMax--;
            }
            if (direction == Direction.Down && row == rowMax)
            {
                direction = Direction.Left;
                rowMax--;
            }
            if (direction == Direction.Left && col == colMin)
            {
                direction = Direction.Up;
                colMin++;
            }
            if (direction == Direction.Up && row == rowMin)
            {
                direction = Direction.Right;
                rowMin++;
            }
            row += directionStep[(int)direction, 0];
            col += directionStep[(int)direction, 1];
        }

        return resultArray;
    }
}
