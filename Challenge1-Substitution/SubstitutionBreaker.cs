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
        char[] splitCipherText = cleanCipherText.ToCharArray();
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
        return frequencyChart;
    }

    /// <summary>
    /// Attempts to decrypt the ciphertext using frequency analysis.
    /// </summary>
    public string Decrypt(string ciphertext)
    {
        string plaintext = "";
        int aUnicode = 65;
        int zUnicode = 90;
        int offset = 3;
        List<char> textarray = ciphertext.ToList();
        for(int i = 0; i < textarray.Count; i++)
        {
            char letter = textarray[i];
            if (char.IsLetter(letter))
            {
                if(letter - offset < aUnicode)
                {
                    letter = (char)(letter - offset - aUnicode + zUnicode + 1); // 1 accounts for 65(a)
                }
                else
                {
                    letter = (char)(letter - offset);  
                }
            }
            plaintext+=letter;
        }     
            Console.WriteLine(plaintext);
        return plaintext;
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
