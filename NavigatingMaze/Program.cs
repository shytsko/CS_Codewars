// Your task is to find the path between two points inside a square maze. The mazes are generated using Eller's algorithm, so there is only
// one possible path between any two points. Mazes look like this:

// #######
// # #   #
// # # ###      S - start point
// #    G#      G - goal point
// ### # #      # - walls of the maze
// #S  # #
// #######

// Implement the FindPath method, which returns an array of traversed indices to reach the goal point from the start point.

// Available input data:
// maze - flat 1D array where True shows a passable space and False means a wall
// size - length of one side of the maze including borders (maze is square)
// startIndex - the index of the cell in the maze array to start your path from
// goalIndex - the index of the cell in the maze array to reach
// In the maze above S has index 36 and G has index 26 in the maze array, so the correct path would be through these cells:

// { 36, 37, 38, 31, 24, 25, 26 }

// There are some static tests and some random tests with mazes of different sizes.

using System;
using System.Collections.Generic;

bool[] maze7 = {    false, false, false, false, false, false, false,
                    false, true,  false, true,  true,  true,  false,
                    false, true,  false, true,  false, false, false,
                    false, true,  true,  true,  true,  true,  false,
                    false, false, false, true,  false, true,  false,
                    false, true,  true,  true,  false, true,  false,
                    false, false, false, false, false, false, false };

int[] path7 = Kata.FindPath(maze7, 7, 36, 26); //  { 36, 37, 38, 31, 24, 25, 26 }
Console.WriteLine(string.Join(" ", path7));

bool[] maze11 = {   false, false, false, false, false, false, false, false, false, false, false,
                    false, true,  false, true,  false, true,  false, true,  false, true,  false,
                    false, true,  false, true,  false, true,  false, true,  false, true,  false,
                    false, true,  true,  true,  false, true,  false, true,  true,  true,  false,
                    false, false, false, true,  false, true,  false, true,  false, true,  false,
                    false, true,  true,  true,  false, true,  true,  true,  false, true,  false,
                    false, false, false, true,  false, true,  false, false, false, false, false,
                    false, true,  false, true,  true,  true,  false, true,  false, true,  false,
                    false, true,  false, false, false, true,  false, true,  false, true,  false,
                    false, true,  true,  true,  true,  true,  true,  true,  true,  true,  false,
                    false, false, false, false, false, false, false, false, false, false, false, };

int[] path11 = Kata.FindPath(maze11, 11, 78, 108); //  { 78, 89, 100, 101, 102, 103, 104, 105, 106, 107, 108 }
Console.WriteLine(string.Join(" ", path11));

bool[] maze15 = {   false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
                    false, true,  true,  true,  true,  true,  true,  true,  false, true,  false, true,  true,  true,  false,
                    false, true,  false, false, false, true,  false, false, false, true,  false, true,  false, true,  false,
                    false, true,  true,  true,  false, true,  false, true,  false, true,  false, true,  false, true,  false,
                    false, true,  false, false, false, false, false, true,  false, true,  false, false, false, true,  false,
                    false, true,  false, true,  true,  true,  true,  true,  true,  true,  false, true,  true,  true,  false,
                    false, true,  false, false, false, true,  false, false, false, false, false, false, false, true,  false,
                    false, true,  false, true,  false, true,  true,  true,  false, true,  false, true,  false, true,  false,
                    false, true,  false, true,  false, true,  false, false, false, true,  false, true,  false, true,  false,
                    false, true,  false, true,  true,  true,  false, true,  false, true,  true,  true,  true,  true,  false,
                    false, true,  false, false, false, true,  false, true,  false, false, false, true,  false, true,  false,
                    false, true,  true,  true,  false, true,  true,  true,  true,  true,  false, true,  false, true,  false,
                    false, true,  false, true,  false, false, false, true,  false, false, false, true,  false, false, false,
                    false, true,  false, true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  false,
                    false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

int[] path15 = Kata.FindPath(maze15, 15, 46, 28); //  { 46, 61, 76, 91, 106, 121, 136, 151, 166, 167, 168, 183, 198, 199, 200, 201, 202, 203, 204, 205, 206, 191, 176, 161, 146, 147, 148, 133, 118, 103, 88, 73, 58, 43, 28 }
Console.WriteLine(string.Join(" ", path15));

public class Kata
{
    public static int[] FindPath(bool[] maze, int size, int startIndex, int goalIndex)
    {
        int[] distance = new int[maze.Length];
        distance[startIndex] = 1;

        FillDistance(maze, distance, size, startIndex);

        if (distance[goalIndex] == 0)
            return new int[0];

        return FindPath(distance, size, startIndex, goalIndex);
    }

    private static void FillDistance(bool[] maze, int[] distance, int size, int currentIndex)
    {
        bool goRight = false;
        bool goLeft = false;
        bool goUp = false;
        bool goDown = false;

        if (maze[currentIndex + 1] && distance[currentIndex + 1] == 0)
        {
            distance[currentIndex + 1] = distance[currentIndex] + 1;
            goRight = true;
        }
        if (maze[currentIndex - 1] && distance[currentIndex - 1] == 0)
        {
            distance[currentIndex - 1] = distance[currentIndex] + 1;
            goLeft = true;
        }
        if (maze[currentIndex + size] && distance[currentIndex + size] == 0)
        {
            distance[currentIndex + size] = distance[currentIndex] + 1;
            goDown = true;
        }
        if (maze[currentIndex - size] && distance[currentIndex - size] == 0)
        {
            distance[currentIndex - size] = distance[currentIndex] + 1;
            goUp = true;
        }

        if (goRight)
            FillDistance(maze, distance, size, currentIndex + 1);
        if (goLeft)
            FillDistance(maze, distance, size, currentIndex - 1);
        if (goDown)
            FillDistance(maze, distance, size, currentIndex + size);
        if (goUp)
            FillDistance(maze, distance, size, currentIndex - size);
    }

    private static int[] FindPath(int[] distance, int size, int startIndex, int goalIndex)
    {
        int currentIndex = goalIndex;
        List<int> path = new List<int> { currentIndex };

        while (currentIndex != startIndex)
        {
            if (distance[currentIndex + 1] == distance[currentIndex] - 1)
                currentIndex += 1;
            else if (distance[currentIndex - 1] == distance[currentIndex] - 1)
                currentIndex -= 1;
            else if (distance[currentIndex + size] == distance[currentIndex] - 1)
                currentIndex += size;
            else if (distance[currentIndex - size] == distance[currentIndex] - 1)
                currentIndex -= size;
            path.Insert(0, currentIndex);
        }

        return path.ToArray();
    }
}
