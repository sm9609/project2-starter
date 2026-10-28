// DO NOT MODIFY THIS FILE
// CSCI 251 - Project 2: Crypto Attack Lab
// Verification runner

namespace CryptoAttackLab;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Crypto Attack Lab Verification ===\n");

        int totalPoints = 0;
        int maxPoints = 24; // Code portion only (analysis is 6 more)

        totalPoints += TestChallenge1();
        totalPoints += TestChallenge2();
        totalPoints += TestChallenge3();

        Console.WriteLine("========================================");
        Console.WriteLine($"  Code Score: {totalPoints}/{maxPoints} points\n");
        Console.WriteLine("  Note: Written analysis (ANALYSIS.md) worth 6 additional points.");
        Console.WriteLine("        Total possible: 30 points");
    }

    static int TestChallenge1()
    {
        Console.WriteLine("Challenge 1: Substitution Cipher");

        try
        {
            var breaker = new SubstitutionBreaker();
            string recovered = breaker.GetRecoveredPlaintext().ToUpper();

            // Check for expected phrases in the recovered text
            bool hasThankYou = recovered.Contains("THANK YOU");
            bool hasFrequency = recovered.Contains("FREQUENCY ANALYSIS");
            bool hasSecretCode = recovered.Contains("SECRET CODE");

            // The secret code phrase
            string expectedSecret = "FREQUENCY ANALYSIS DEFEATS SIMPLE CIPHERS";
            bool hasExactSecret = recovered.Contains(expectedSecret);

            int points = 0;
            if (hasThankYou) points += 2;
            if (hasFrequency) points += 2;
            if (hasSecretCode) points += 2;
            if (hasExactSecret) points += 2;

            if (points == 8)
            {
                Console.WriteLine("  Checking recovered plaintext... CORRECT!");
            }
            else if (points > 0)
            {
                Console.WriteLine($"  Checking recovered plaintext... PARTIAL ({points}/8 checks passed)");
            }
            else
            {
                Console.WriteLine("  Checking recovered plaintext... INCORRECT");
            }

            Console.WriteLine($"  Points: {points}/8\n");
            return points;
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("  Not implemented");
            Console.WriteLine("  Points: 0/8\n");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error: {ex.Message}");
            Console.WriteLine("  Points: 0/8\n");
            return 0;
        }
    }

    static int TestChallenge2()
    {
        Console.WriteLine("Challenge 2: IV Reuse Attack");

        try
        {
            var attack = new IVReuseAttack();
            string recovered = attack.GetRecoveredPlaintext();

            // Check for expected content
            string expectedSecret = "IV-REUSE-AT";
            bool hasSecret = recovered.Contains(expectedSecret);

            // Check first part matches
            bool startsCorrectly = recovered.StartsWith("The secret code");

            int points = 0;
            if (startsCorrectly) points += 4;
            if (hasSecret) points += 6;

            if (points == 10)
            {
                Console.WriteLine("  Checking recovered plaintext... CORRECT!");
            }
            else if (points > 0)
            {
                Console.WriteLine($"  Checking recovered plaintext... PARTIAL");
            }
            else
            {
                Console.WriteLine("  Checking recovered plaintext... INCORRECT");
            }

            Console.WriteLine($"  Points: {points}/10\n");
            return points;
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("  Not implemented");
            Console.WriteLine("  Points: 0/10\n");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error: {ex.Message}");
            Console.WriteLine("  Points: 0/10\n");
            return 0;
        }
    }

    static int TestChallenge3()
    {
        Console.WriteLine("Challenge 3: ECB Analysis");

        try
        {
            var analysis = new ECBAnalysis();
            string summary = analysis.GetAnalysisSummary();

            // Check that analysis mentions key concepts
            bool mentionsPattern = summary.ToLower().Contains("pattern");
            bool mentionsBlock = summary.ToLower().Contains("block");
            bool mentionsIdentical = summary.ToLower().Contains("identical") ||
                                     summary.ToLower().Contains("same") ||
                                     summary.ToLower().Contains("repeat");

            int points = 0;
            if (!string.IsNullOrWhiteSpace(summary)) points += 2;
            if (mentionsPattern) points += 2;
            if (mentionsBlock || mentionsIdentical) points += 2;

            if (points == 6)
            {
                Console.WriteLine("  Checking analysis output... COMPLETE!");
            }
            else if (points > 0)
            {
                Console.WriteLine($"  Checking analysis output... PARTIAL");
            }
            else
            {
                Console.WriteLine("  Checking analysis output... MISSING");
            }

            Console.WriteLine($"  Points: {points}/6\n");
            return points;
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("  Not implemented");
            Console.WriteLine("  Points: 0/6\n");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error: {ex.Message}");
            Console.WriteLine("  Points: 0/6\n");
            return 0;
        }
    }
}
