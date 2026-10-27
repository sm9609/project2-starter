// Samuel Mensah
// CSCI 251 - Project 2: Crypto Attack Lab
// Challenge 1: Break the Substitution Cipher

using System.Text.RegularExpressions;

namespace CryptoAttackLab;

/// <summary>
/// Break a substitution cipher using frequency analysis.
/// </summary>
public class SubstitutionBreaker
{
    /// <summary>
    /// Analyzes the ciphertext and returns letter frequencies.
    /// </summary>
    public Dictionary<char, double> AnalyzeFrequencies(string ciphertext)
    {
        string cleanCipherText = Regex.Replace(ciphertext, @"[^a-zA-Z]", "");
        char[] splitCipherText = cleanCipherText.Trim().ToCharArray();
        Dictionary<char, double> frequencyChart = new Dictionary<char, double>();
        int totalCount = splitCipherText.Length;

        for (int i = 0; i < splitCipherText.Length; i++)
        {
            char letter = splitCipherText[i];
            if (frequencyChart.ContainsKey(letter))
            {
                frequencyChart[letter] += 1.0 / totalCount;
            }
            else
            {
                frequencyChart.Add(letter, 1.0 / totalCount);
            }

        }
        
        // Print Frequency Chart
        // foreach (KeyValuePair<char, double> entry in frequencyChart)
        // {
        //     if(Math.Round(entry.Value, 3) >= 0.06)
        //     Console.WriteLine(entry.Key + " " + Math.Round(entry.Value, 3));
        // }

        // TODO: Count letter frequencies in the ciphertext
        // Return a dictionary mapping each letter to its frequency (0.0 to 1.0)

        return frequencyChart;
    }

    private int GetOffset(string ciphertext, Dictionary<char, double> cipherFrequencies)
    {
        int offset = -1;
        Dictionary<double, char> AlphabetFrequency = new Dictionary<double, char>
        {
            { 0.127, 'E' },
            { 0.091, 'T' },
            { 0.082, 'A' },
            { 0.075, 'O' },
            { 0.070, 'I' },
            { 0.067, 'N' },
            { 0.063, 'S' },
            { 0.061, 'H' },
            { 0.060, 'R' }
        };
        

        foreach (KeyValuePair<char, double> frequency in cipherFrequencies)
        {
            double targetFrequency = Math.Round(frequency.Value, 3);
            //Console.WriteLine(targetFrequency+" ");
            if (AlphabetFrequency.ContainsKey(targetFrequency))
            {
                // print Matching frequency
                //Console.WriteLine(frequency.Key + "=" + AlphabetFrequency[targetFrequency]);
                offset = Math.Abs(frequency.Key - AlphabetFrequency[targetFrequency]);
            }
        }
        return offset;
    }

    /// <summary>
    /// Attempts to decrypt the ciphertext using frequency analysis.
    /// </summary>
    public string Decrypt(string ciphertext)
    {
        // TODO: Implement your decryption algorithm
        //
        // Hints:
        // 1. Analyze letter frequencies in the ciphertext
        // 2. Compare to known English letter frequencies:
        //    E=12.6%, T=9.1%, A=8.2%, O=7.6%, I=6.9%, N=6.7%, S=6.3%, H=6.1%, R=6.0%
        // 3. Build a substitution mapping
        // 4. You may need to manually adjust some letters
        // 5. offset the numbers by that number
        //
        // The plaintext should be readable English text.
        Dictionary<char, double> cipherFrequencies = AnalyzeFrequencies(ciphertext);
        int offset = GetOffset(ciphertext,cipherFrequencies);
        int UpperRange = 90;
        int LowerRange = 65;
        System.Console.WriteLine(offset);
        foreach(char key in cipherFrequencies.Keys)
        {
            if((key + offset) > UpperRange)
                offset = ((key+offset - UpperRange) + LowerRange);
                Console.WriteLine(offset);
            ciphertext = ciphertext.Replace(key,(char)(key + offset));
        }
        Console.WriteLine(ciphertext);
        
        return ciphertext;
    }

    /// <summary>
    /// Returns the recovered plaintext for auto-grading.
    /// </summary>
    public string GetRecoveredPlaintext()
    {
        string ciphertext = File.ReadAllText("Challenge1-Substitution/cipher.txt");
        return Decrypt(ciphertext);
    }
}
