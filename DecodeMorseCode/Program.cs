// In this kata you have to write a Morse code decoder for wired electrical telegraph.
// Electric telegraph is operated on a 2-wire line with a key that, when pressed, connects the wires together,
// which can be detected on a remote station. The Morse code encodes every character being transmitted as a sequence of "dots"
// (short presses on the key) and "dashes" (long presses on the key).

// When transmitting the Morse code, the international standard specifies that:

// "Dot" – is 1 time unit long.
// "Dash" – is 3 time units long.
// Pause between dots and dashes in a character – is 1 time unit long.
// Pause between characters inside a word – is 3 time units long.
// Pause between words – is 7 time units long.
// However, the standard does not specify how long that "time unit" is. And in fact different operators would transmit at different speed.
// An amateur person may need a few seconds to transmit a single character, a skilled professional can transmit 60 words per minute,
// and robotic transmitters may go way faster.

// For this kata we assume the message receiving is performed automatically by the hardware that checks the line periodically,
// and if the line is connected (the key at the remote station is down), 1 is recorded, and if the line is not connected
// (remote key is up), 0 is recorded. After the message is fully received, it gets to you for decoding as a string containing only symbols 0 and 1.

// For example, the message HEY JUDE, that is ···· · −·−−   ·−−− ··− −·· · may be received as follows:

// 1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011

// As you may see, this transmission is perfectly accurate according to the standard, and the hardware sampled the line exactly two times per "dot".

// That said, your task is to implement two functions:

// 1. Function decodeBits(bits), that should find out the transmission rate of the message, correctly decode the message to dots .,
// dashes - and spaces (one between characters, three between words) and return those as a string. Note that some extra 0's may
// naturally occur at the beginning and the end of a message, make sure to ignore them. Also if you have trouble discerning
// if the particular sequence of 1's is a dot or a dash, assume it's a dot.
// 2. Function decodeMorse(morseCode), that would take the output of the previous function and return a human-readable string.

// NOTE: For coding purposes you have to use ASCII characters . and -, not Unicode characters.

// The Morse code table is preloaded for you (see the solution setup, to get its identifier in your language).


// Eg:
//   morseCodes(".--") //to access the morse translation of ".--"
// All the test strings would be valid to the point that they could be reliably decoded as described above, so you may skip checking
// for errors and exceptions, just do your best in figuring out what the message is!

using System.Text;

string morseString = MorseCodeDecoder.DecodeBits("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011");
Console.WriteLine(morseString);
Console.WriteLine(MorseCodeDecoder.DecodeMorse(morseString)); // HEY JUDE

morseString = MorseCodeDecoder.DecodeBits("1");
Console.WriteLine(morseString);
Console.WriteLine(MorseCodeDecoder.DecodeMorse(morseString));

morseString = MorseCodeDecoder.DecodeBits("01110");
Console.WriteLine(morseString);
Console.WriteLine(MorseCodeDecoder.DecodeMorse(morseString));

morseString = MorseCodeDecoder.DecodeBits("11111100111111");
Console.WriteLine(morseString);
Console.WriteLine(MorseCodeDecoder.DecodeMorse(morseString));

morseString = MorseCodeDecoder.DecodeBits("1110111");
Console.WriteLine(morseString);
Console.WriteLine(MorseCodeDecoder.DecodeMorse(morseString));

morseString = MorseCodeDecoder.DecodeBits("00011100010101010001000000011101110101110001010111000101000111010111010001110101110000000111010101000101110100011101110111000101110111000111010000000101011101000111011101110001110101011100000001011101110111000101011100011101110001011101110100010101000000011101110111000101010111000100010111010000000111000101010100010000000101110101000101110001110111010100011101011101110000000111010100011101110111000111011101000101110101110101110");
Console.WriteLine(morseString);
Console.WriteLine(MorseCodeDecoder.DecodeMorse(morseString));

morseString = MorseCodeDecoder.DecodeBits("11111111111111100000000000000011111000001111100000111110000011111000000000000000111110000000000000000000000000000000000011111111111111100000111111111111111000001111100000111111111111111000000000000000111110000011111000001111111111111110000000000000001111100000111110000000000000001111111111111110000011111000001111111111111110000011111000000000000000111111111111111000001111100000111111111111111000000000000000000000000000000000001111111111111110000011111000001111100000111110000000000000001111100000111111111111111000001111100000000000000011111111111111100000111111111111111000001111111111111110000000000000001111100000111111111111111000001111111111111110000000000000001111111111111110000011111000000000000000000000000000000000001111100000111110000011111111111111100000111110000000000000001111111111111110000011111111111111100000111111111111111000000000000000111111111111111000001111100000111110000011111111111111100000000000000000000000000000000000111110000011111111111111100000111111111111111000001111111111111110000000000000001111100000111110000011111111111111100000000000000011111111111111100000111111111111111000000000000000111110000011111111111111100000111111111111111000001111100000000000000011111000001111100000111110000000000000000000000000000000000011111111111111100000111111111111111000001111111111111110000000000000001111100000111110000011111000001111111111111110000000000000001111100000000000000011111000001111111111111110000011111000000000000000000000000000000000001111111111111110000000000000001111100000111110000011111000001111100000000000000011111000000000000000000000000000000000001111100000111111111111111000001111100000111110000000000000001111100000111111111111111000000000000000111111111111111000001111111111111110000011111000001111100000000000000011111111111111100000111110000011111111111111100000111111111111111000000000000000000000000000000000001111111111111110000011111000001111100000000000000011111111111111100000111111111111111000001111111111111110000000000000001111111111111110000011111111111111100000111110000000000000001111100000111111111111111000001111100000111111111111111000001111100000111111111111111");
Console.WriteLine(morseString);
Console.WriteLine(MorseCodeDecoder.DecodeMorse(morseString));


class MorseCodeDecoder
{
    public static string DecodeBits(string bits)
    {
        string tempBits = bits.Trim('0');
        int timeUnit = int.MaxValue;
        int duration = 0;
        StringBuilder result = new StringBuilder(string.Empty);
        for (int i = 0; i < tempBits.Length; i++)
        {
            if (tempBits[i] == '1')
                duration++;
            else if (duration > 0)
            {
                if (duration < timeUnit)
                    timeUnit = duration;
                duration = 0;
            }
        }

        if (duration > 0 && duration < timeUnit)
            timeUnit = duration;

        for (int i = 0; i < tempBits.Length; i++)
        {
            if (tempBits[i] == '0')
                duration++;
            else if (duration > 0)
            {
                if (duration < timeUnit)
                    timeUnit = duration;
                duration = 0;
            }
        }

        string[] bitsWords = tempBits.Split(new string('0', timeUnit * 7));

        foreach (string bitsWord in bitsWords)
        {
            string[] bitsSymbols = bitsWord.Split(new string('0', timeUnit * 3));
            foreach (string bitSymbol in bitsSymbols)
            {
                string[] bitsSignals = bitSymbol.Split(new string('0', timeUnit));
                foreach (string bitsSignal in bitsSignals)
                {

                    if (bitsSignal.Length < timeUnit * 3)
                        result.Append('.');
                    else
                        result.Append('-');
                }
                result.Append(' ');
            }
            result.Append("  ");
        }

        return result.ToString().Trim();
    }
    public static string DecodeMorse(string morseCode)
    {
        string[] inputWords = morseCode.Trim().Split("   ");
        string[] outputWords = new string[inputWords.Length];

        for (int i = 0; i < inputWords.Length; i++)
        {
            string[] chars = inputWords[i].Split(' ');
            for (int j = 0; j < chars.Length; j++)
            {
                outputWords[i] += MorseCode.Get(chars[j]);
            }
        }
        return String.Join(" ", outputWords);
    }
}

class MorseCode
{
    public static string Get(string morseCode)
    {
        Dictionary<string, string> code = new Dictionary<string, string>()
        {
            {".-", "A"},
            {"-...", "B"},
            {"-.-.", "C"},
            {"-..", "D"},
            {".", "E"},
            {"..-.", "F"},
            {"--.", "G"},
            {"....", "H"},
            {"..", "I"},
            {".---", "J"},
            {"-.-", "K"},
            {".-..", "L"},
            {"--", "M"},
            {"-.", "N"},
            {"---", "O"},
            {".--.", "P"},
            {"--.-", "Q"},
            {".-.", "R"},
            {"...", "S"},
            {"-", "T"},
            {"..-", "U"},
            {"...-", "V"},
            {".--", "W"},
            {"-..-", "X"},
            {"-.--", "Y"},
            {"--..", "Z"},
            {".----", "1"},
            {"..---", "2"},
            {"...--", "3"},
            {"....-", "4"},
            {".....", "5"},
            {"-....", "6"},
            {"--...", "7"},
            {"---..", "8"},
            {"----.", "9"},
            {"-----", "0"},
            {".-.-.-", "."}
        };
        return code[morseCode];
    }
}