// Complete the solution so that it splits the string into pairs of two characters. If the string contains an odd number of characters
// then it should replace the missing second character of the final pair with an underscore ('_').
// Examples:
// * 'abc' =>  ['ab', 'c_']
// * 'abcdef' => ['ab', 'cd', 'ef']

using System.Collections.Generic;

Console.WriteLine(String.Join(" ", SplitString.Solution("abcdefk")));
public class SplitString
{
    public static string[] Solution(string str)
    {
        List<string> result = new List<string>();
        string temp = (str.Length % 2 == 0) ? str : str + '_';
        for (int i = 0; i < temp.Length; i += 2)
            result.Add(temp.Substring(i, 2));
        return result.ToArray();
    }
}
