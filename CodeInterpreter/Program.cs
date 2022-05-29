// https://www.codewars.com/kata/526156943dfe7ce06200063e
// We want to create an interpreter of that language which will support the following instructions:

// > increment the data pointer (to point to the next cell to the right).
// < decrement the data pointer (to point to the next cell to the left).
// + increment (increase by one, truncate overflow: 255 + 1 = 0) the byte at the data pointer.
// - decrement (decrease by one, treat as unsigned byte: 0 - 1 = 255 ) the byte at the data pointer.
// . output the byte at the data pointer.
// , accept one byte of input, storing its value in the byte at the data pointer.
// [ if the byte at the data pointer is zero, then instead of moving the instruction pointer forward to the next command,
//     jump it forward to the command after the matching ] command.
// ] if the byte at the data pointer is nonzero, then instead of moving the instruction pointer forward to the next command,
//     jump it back to the command after the matching [ command.

// The function will take in input...

// the program code, a string with the sequence of machine instructions,
// the program input, a string, possibly empty, that will be interpreted as an array of bytes using each character's
// ASCII code and will be consumed by the , instruction.

// ... and will return ...

// the output of the interpreted code (always as a string), produced by the . instruction.

// Implementation-specific details for this Kata:

// - Your memory tape should be large enough - the original implementation had 30,000 cells but a few thousand should suffice for this Kata
// - Each cell should hold an unsigned byte with wrapping behavior (i.e. 255 + 1 = 0, 0 - 1 = 255), initialized to 0
// - The memory pointer should initially point to a cell in the tape with a sufficient number (e.g. a few thousand or more) of cells to its right.
//   For convenience, you may want to have it point to the leftmost cell initially
// - You may assume that the , command will never be invoked when the input stream is exhausted
// - Error-handling, e.g. unmatched square brackets and/or memory pointer going past the leftmost cell is not required in this Kata.
//   If you see test cases that require you to perform error-handling then please open an Issue in the Discourse for this Kata
//   (don't forget to state which programming language you are attempting this Kata in).

using System.Text;
using System.Collections.Generic;

Console.WriteLine(Kata.BrainLuck(",+[-.,+]", "Codewars" + char.ConvertFromUtf32(255))); // Codewars
Console.WriteLine(Kata.BrainLuck(",[.[-],]", "Codewars" + char.ConvertFromUtf32(0)));   // Codewars
Console.WriteLine(Kata.BrainLuck(",>,<[>[->+>+<<]>>[-<<+>>]<<<-]>>.", char.ConvertFromUtf32(8) + char.ConvertFromUtf32(9))); // H

public static class Kata
{
    public static string BrainLuck(string code, string input)
    {
        byte[] data = new byte[2000];
        List<byte> output = new List<byte>();
        int pointerData = 0;
        int pointerCode = 0;
        int pointerInput = 0;
        while (pointerCode < code.Length)
        {
            switch (code[pointerCode])
            {
                case '>':
                    pointerData++;
                    break;
                case '<':
                    pointerData--;
                    break;
                case '+':
                    data[pointerData]++;
                    break;
                case '-':
                    data[pointerData]--;
                    break;
                case '.':
                    output.Add(data[pointerData]);
                    break;
                case ',':
                    data[pointerData] = (byte)input[pointerInput++];
                    break;
                case '[':
                    if (data[pointerData] == (byte)0)
                    {
                        int depth = 1;
                        do
                        {
                            pointerCode++;
                            if (code[pointerCode] == ']')
                                depth--;
                            else if (code[pointerCode] == '[')
                                depth++;
                        } while (depth > 0);
                    }
                    break;
                case ']':
                    if (data[pointerData] != (byte)0)
                    {
                        int depth = 1;
                        do
                        {
                            pointerCode--;
                            if (code[pointerCode] == '[')
                                depth--;
                            else if (code[pointerCode] == ']')
                                depth++;
                        } while (depth > 0);
                    }
                    break;
                default:
                    break;
            }
            pointerCode++;
        }
        return Encoding.ASCII.GetString(output.ToArray());
    }
}
