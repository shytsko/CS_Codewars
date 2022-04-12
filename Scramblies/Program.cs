// https://www.codewars.com/kata/55c04b4cc56a697bb0000048
// Complete the function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false.
// Notes:
// Only lower case letters will be used (a-z). No punctuation or digits will be included.
// Performance needs to be considered.
// Examples
// scramble('rkqodlw', 'world') ==> True
// scramble('cedewaraaossoqqyt', 'codewars') ==> True
// scramble('katas', 'steak') ==> False

using System;
using System.Collections.Generic;


Console.WriteLine(Scramblies.Scramble("rkqodlw","world"));              //true
Console.WriteLine(Scramblies.Scramble("cedewaraaossoqqyt","codewars")); //true
Console.WriteLine(Scramblies.Scramble("katas","steak"));                //false
Console.WriteLine(Scramblies.Scramble("scriptjavx","javascript"));      //false
Console.WriteLine(Scramblies.Scramble("scriptingjava","javascript"));   //true
Console.WriteLine(Scramblies.Scramble("scriptsjava","javascripts"));    //true
Console.WriteLine(Scramblies.Scramble("javscripts","javascript"));      //false
Console.WriteLine(Scramblies.Scramble("aabbcamaomsccdd","commas"));     //true
Console.WriteLine(Scramblies.Scramble("commas","commas"));              //true
Console.WriteLine(Scramblies.Scramble("sammoc","commas"));              //true

public class Scramblies 
{ 
    public static bool Scramble(string str1, string str2) 
    {
        List<char> list1 = new List<char>(str1);
        List<char> list2 = new List<char>(str2);

        foreach (char c in list2)
            if(!list1.Remove(c))
                return false;

        return true;
    }

}
