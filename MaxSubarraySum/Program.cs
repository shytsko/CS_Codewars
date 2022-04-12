// https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c
// The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:

// maxSequence [-2, 1, -3, 4, -1, 2, 1, -5, 4]
// -- should be 6: [4, -1, 2, 1]
// Easy case is when the list is made up of only positive numbers and the maximum sum is the sum of the whole array.
// If the list is made up of only negative numbers, return 0 instead.
// Empty list is considered to have zero greatest sum. Note that the empty list or array is also a valid sublist/subarray.

using System;
using System.Linq;

Console.WriteLine(MaxSequence(new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4}));

static int MaxSequence(int[] arr) 
{ 
    //TODO : create code
    int max_sum = 0;

    if(arr.Length == 0 || !Array.Exists(arr, x => x>=0))
        return 0;

    for(int len = 1; len<=arr.Length; len++)
    {
        for(int i = 0; i <= arr.Length-len; i++)
        {   
            int sum = 0;
            for(int j = i; j<i+len; j++)
                sum+=arr[j];
            if(sum >max_sum)
                max_sum = sum;
        }

    }

    return max_sum;
}