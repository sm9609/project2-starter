// Samuel Mensah
// CSCI 251 - Project 2: Crypto Attack Lab
// Challenge 1: Break the Substitution Cipher

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
        List<string> splitCipherText = ciphertext.Trim()
            .Split()
            .ToList();
        Dictionary<char, double> frequencyChart = new Dictionary<char, double>();
        int totalCount = splitCipherText.Count;
        for (int i = 0; i < splitCipherText.Count; i++)
        {
            char letter = splitCipherText[i].First();
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
            Console.WriteLine($"{entry.Key}: {entry.Value:P2}");
        }

        // TODO: Count letter frequencies in the ciphertext
        // Return a dictionary mapping each letter to its frequency (0.0 to 1.0)

        return frequencyChart;
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
        //    E=12.7%, T=9.1%, A=8.2%, O=7.5%, I=7.0%, N=6.7%, S=6.3%, H=6.1%, R=6.0%
        // 3. Build a substitution mapping
        // 4. You may need to manually adjust some letters
        //
        // The plaintext should be readable English text.
        AnalyzeFrequencies(ciphertext);
        throw new NotImplementedException();
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
