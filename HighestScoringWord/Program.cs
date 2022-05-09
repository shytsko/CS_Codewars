// Given a string of words, you need to find the highest scoring word.
// Each letter of a word scores points according to its position in the alphabet: a = 1, b = 2, c = 3 etc.
// You need to return the highest scoring word as a string.
// If two words score the same, return the word that appears earliest in the original string.
// All letters will be lowercase and all inputs will be valid.

Console.WriteLine(Kata.High("man i need a taxi up to ubud"));                   // "taxi"
Console.WriteLine(Kata.High("what time are we climbing up to the volcano"));    // "volcano"
Console.WriteLine(Kata.High("take me to semynak"));                             // "semynak"
Console.WriteLine(Kata.High("aa b"));                                           // "aa"
Console.WriteLine(Kata.High("b aa"));                                           // "b"
Console.WriteLine(Kata.High("bb d"));                                           // "bb"
Console.WriteLine(Kata.High("d bb"));                                           // "d"
Console.WriteLine(Kata.High("aaa b"));                                          // "aaa"

public class Kata
{
    public static string High(string s)
    {
        string[] words = s.Split(new char[] { ' ' });

        int maxScore = 0;
        string maxScoreWord = string.Empty;
        foreach (string word in words)
        {
            int score = 0;
            foreach (char c in word)
                score += c - 'a' + 1;

            if (score > maxScore)
            {
                maxScore = score;
                maxScoreWord = word;
            }
        }

        return maxScoreWord;
    }
}