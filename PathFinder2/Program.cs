// You are at position [0, 0] in maze NxN and you can only move in one of the four cardinal directions (i.e. North, East, South, West).
// Return the minimal number of steps to exit position [N-1, N-1] if it is possible to reach the exit from the starting position. Otherwise, return -1.

// Empty positions are marked .. Walls are marked W. Start and exit positions are guaranteed to be empty in all test cases.
using System.Collections.Generic;

string a = ".W.\n" +
           ".W.\n" +
           "...",

       b = ".W.\n" +
           ".W.\n" +
           "W..",

       c = "......\n" +
           "......\n" +
           "......\n" +
           "......\n" +
           "......\n" +
           "......",

       d = "......\n" +
           "......\n" +
           "......\n" +
           "......\n" +
           ".....W\n" +
           "....W.";

Console.WriteLine(Finder.PathFinder(a)); // 4
Console.WriteLine(Finder.PathFinder(b)); // -1
Console.WriteLine(Finder.PathFinder(c)); // 10
Console.WriteLine(Finder.PathFinder(d)); // -1

public class Finder
{
    public static int PathFinder(string maze)
    {
        string[] newMaze = maze.Split('\n');
        int[,] distance = new int[newMaze.Length, newMaze.Length];
        Queue<(int, int)> nextSteps = new Queue<(int, int)>();
        HashSet<(int, int)> prevSteps = new HashSet<(int, int)>();

        nextSteps.Enqueue((0, 0));
        (int i, int j) step;
        while (nextSteps.TryDequeue(out step))
        {
            if (step == (newMaze.Length - 1, newMaze.Length - 1))
                return distance[step.i, step.j];
            prevSteps.Add(step);
            if (step.j < newMaze.Length - 1 && !prevSteps.Contains((step.i, step.j + 1)) && !nextSteps.Contains((step.i, step.j + 1)))
                if (newMaze[step.i][step.j + 1] == '.')
                {
                    distance[step.i, step.j + 1] = distance[step.i, step.j] + 1;
                    nextSteps.Enqueue((step.i, step.j + 1));
                }
            if (step.j > 0 && !prevSteps.Contains((step.i, step.j - 1)) && !nextSteps.Contains((step.i, step.j - 1)))
                if (newMaze[step.i][step.j - 1] == '.')
                {
                    distance[step.i, step.j - 1] = distance[step.i, step.j] + 1;
                    nextSteps.Enqueue((step.i, step.j - 1));
                }
            if (step.i > 0 && !prevSteps.Contains((step.i - 1, step.j)) && !nextSteps.Contains((step.i - 1, step.j)))
                if (newMaze[step.i - 1][step.j] == '.')
                {
                    distance[step.i - 1, step.j] = distance[step.i, step.j] + 1;
                    nextSteps.Enqueue((step.i - 1, step.j));
                }
            if (step.i < newMaze.Length - 1 && !prevSteps.Contains((step.i + 1, step.j)) && !nextSteps.Contains((step.i + 1, step.j)))
                if (newMaze[step.i + 1][step.j] == '.')
                {
                    distance[step.i + 1, step.j] = distance[step.i, step.j] + 1;
                    nextSteps.Enqueue((step.i + 1, step.j));
                }
        }
        return -1;
    }
}