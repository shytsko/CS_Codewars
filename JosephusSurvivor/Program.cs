﻿// https://www.codewars.com/kata/555624b601231dc7a400017a
// Basically you have to assume that n people are put into a circle and that they are eliminated in steps of k elements, like this:
// josephus_survivor(7,3) => means 7 people in a circle;
// one every 3 is eliminated until one remains
// [1,2,3,4,5,6,7] - initial sequence
// [1,2,4,5,6,7] => 3 is counted out
// [1,2,4,5,7] => 6 is counted out
// [1,4,5,7] => 2 is counted out
// [1,4,5] => 7 is counted out
// [1,4] => 5 is counted out
// [4] => 1 counted out, 4 is the last element - the survivor!
// The above link about the "base" kata description will give you a more thorough insight about the origin of this kind of permutation,
// but basically that's all that there is to know to solve this kata.
// Notes and tips: using the solution to the other kata to check your function may be helpful, but as much larger numbers will be used,
// using an array/list to compute the number of the survivor may be too slow; you may assume that both n and k will always be >=1.

using System;


Console.WriteLine(JosephusSurvivor.JosSurvivor(7,3));     // 4
Console.WriteLine(JosephusSurvivor.JosSurvivor(11,19));  // 10
Console.WriteLine(JosephusSurvivor.JosSurvivor(40,3));   // 28
Console.WriteLine(JosephusSurvivor.JosSurvivor(14,2));   // 13
Console.WriteLine(JosephusSurvivor.JosSurvivor(100,1)); // 100
Console.WriteLine(JosephusSurvivor.JosSurvivor(1,300));   // 1
Console.WriteLine(JosephusSurvivor.JosSurvivor(2,300));   // 1
Console.WriteLine(JosephusSurvivor.JosSurvivor(5,300));   // 1
Console.WriteLine(JosephusSurvivor.JosSurvivor(7,300));   // 7
Console.WriteLine(JosephusSurvivor.JosSurvivor(300,300));   //265



public class JosephusSurvivor 
{
    public static int JosSurvivor(int n, int k) 
    {
        if (n == 1)
            return 1;
        else
            return (JosephusSurvivor.JosSurvivor(n-1, k) + k - 1) % n + 1;
    } 
}