// A pangram is a sentence that contains every single letter of the alphabet at least once. For example, the sentence
// "The quick brown fox jumps over the lazy dog" is a pangram, because it uses the letters A-Z at least once (case is irrelevant).
// Given a string, detect whether or not it is a pangram. Return True if it is, False if not. Ignore numbers and punctuation.


Console.WriteLine(Kata.IsPangram("The quik brown fox jumps over the lazy dog."));
public static class Kata
{
    public static bool IsPangram(string str)
    {
        string letters = "abcdefghijklmnopqrstuvwxyz";

        foreach (char letter in letters)
        {
            if(!str.Contains(letter) && !str.Contains($"{letter}".ToUpper()))
            {
                return false;
            }
        }
        return true;
        throw new NotImplementedException();
    }
}
