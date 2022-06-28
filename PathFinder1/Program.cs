// Task
// You are at position [0, 0] in maze NxN and you can only move in one of the four cardinal directions (i.e. North, East, South, West).
// Return true if you can reach position [N-1, N-1] or false otherwise.

// Empty positions are marked ..
// Walls are marked W.
// Start and exit positions are empty in all test cases.
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

Console.WriteLine(Finder.PathFinder(a)); // true
Console.WriteLine(Finder.PathFinder(b)); // false
Console.WriteLine(Finder.PathFinder(c)); // true
Console.WriteLine(Finder.PathFinder(d)); // false
public class Finder
{
    public static bool PathFinder(string maze)
    {
        string[] newMaze = maze.Split('\n');
        Queue<(int, int)> nextSteps = new Queue<(int, int)>();
        HashSet<(int, int)> prevSteps = new HashSet<(int, int)>();

        nextSteps.Enqueue((0, 0));
        (int i, int j) step;
        while (nextSteps.TryDequeue(out step))
        {
            if (step == (newMaze.Length - 1, newMaze.Length - 1))
                return true;
            prevSteps.Add(step);
            if (step.j < newMaze.Length - 1 && !prevSteps.Contains((step.i, step.j + 1)) && !nextSteps.Contains((step.i, step.j + 1)))
                if (newMaze[step.i][step.j + 1] == '.')
                    nextSteps.Enqueue((step.i, step.j + 1));
            if (step.j > 0 && !prevSteps.Contains((step.i, step.j - 1)) && !nextSteps.Contains((step.i, step.j - 1)))
                if (newMaze[step.i][step.j - 1] == '.')
                    nextSteps.Enqueue((step.i, step.j - 1));
            if (step.i > 0 && !prevSteps.Contains((step.i - 1, step.j)) && !nextSteps.Contains((step.i - 1, step.j)))
                if (newMaze[step.i - 1][step.j] == '.')
                    nextSteps.Enqueue((step.i - 1, step.j));
            if (step.i < newMaze.Length - 1 && !prevSteps.Contains((step.i + 1, step.j)) && !nextSteps.Contains((step.i + 1, step.j)))
                if (newMaze[step.i + 1][step.j] == '.')
                    nextSteps.Enqueue((step.i + 1, step.j));
        }
        return false;
    }
}