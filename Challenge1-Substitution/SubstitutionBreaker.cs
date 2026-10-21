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

        foreach (KeyValuePair<char, double> entry in frequencyChart)
        {
            if(Math.Round(entry.Value, 3) >= 0.06)
            Console.WriteLine(entry.Key + " " + Math.Round(entry.Value, 3));
        }

        // TODO: Count letter frequencies in the ciphertext
        // Return a dictionary mapping each letter to its frequency (0.0 to 1.0)

        return frequencyChart;
    }

    private Dictionary<char, char> MapLetters(string ciphertext)
    {
        Dictionary<char, double> cipherFrequencies = AnalyzeFrequencies(ciphertext);
        Dictionary<double, char> AlphabetFrequency = new Dictionary<double, char>
        {
            { 0.126, 'E' },
            { 0.091, 'T' },
            { 0.082, 'A' },
            { 0.076, 'O' },
            { 0.069, 'I' },
            { 0.067, 'N' },
            { 0.063, 'S' },
            { 0.061, 'H' },
            { 0.060, 'R' }
        };
        Dictionary<char, char> cipherMapping = new Dictionary<char, char>();

        foreach (KeyValuePair<char, double> frequency in cipherFrequencies)
        {
            double targetFrequency = Math.Round(frequency.Value, 3);
            //Console.WriteLine(targetFrequency+" ");
            if (AlphabetFrequency.ContainsKey(targetFrequency))
            {
                
                Console.WriteLine(frequency.Key + "=" + AlphabetFrequency[targetFrequency]);
                cipherMapping.Add(frequency.Key, AlphabetFrequency[targetFrequency]);
            }
        }
        return cipherMapping;
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
        //
        // The plaintext should be readable English text.
        Dictionary<char, char> mapping = MapLetters(ciphertext);
        //    <Replaced,new char>
        foreach (KeyValuePair<char, char> map in mapping)
        {
            ciphertext = ciphertext.Replace(map.Key, map.Value);
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
