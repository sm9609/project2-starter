// Samuel Mensah
// CSCI 251 - Project 2: Crypto Attack Lab
// Challenge 3: Analyze ECB Mode Weakness

namespace CryptoAttackLab;

/// <summary>
/// Analyze why ECB mode is insecure for encrypting structured data.
/// </summary>
public class ECBAnalysis
{
    /// <summary>
    /// Analyzes an ECB-encrypted BMP image to identify patterns.
    /// </summary>
    public void AnalyzeImage(string imagePath)
    {
        // TODO: Load and analyze the encrypted image
        //
        // BMP files have a header (first 54 bytes typically) that describes
        // the image format. When we "encrypt" with ECB, we often leave the
        // header intact so the file can still be opened as an image.
        //
        // The body of the image is encrypted, but because ECB encrypts each
        // 16-byte block independently:
        // - Identical plaintext blocks produce identical ciphertext blocks
        // - Patterns in the original image (solid colors, repeated elements)
        //   show through in the encrypted version
        //
        // Your analysis should:
        // 1. Open the encrypted BMP in an image viewer
        // 2. Describe what patterns you can see
        // 3. Try to identify what the original image might have been

        Console.WriteLine("ECB Analysis Results:");
        Console.WriteLine("====================");

        // TODO: Add your analysis output here
        // Example:
        Console.WriteLine("Observed patterns: The background is all the same color and their is a silhouette of pixel noise in the middle which is also probably all the same color");
        Console.WriteLine("Likely original content: the linux pinguin on a white background ");
        Console.WriteLine("Why this happens: Each block of the image is encrypted with the same key meaning that a color will look the same across the whole image and allow you to outline the contents of the image");
    }

    /// <summary>
    /// Counts unique 16-byte blocks in the file (excluding header).
    /// Fewer unique blocks = more patterns = more information leakage.
    /// </summary>
    public (int totalBlocks, int uniqueBlocks) CountUniqueBlocks(string imagePath)
    {
        byte[] data = File.ReadAllBytes(imagePath);

        // Skip BMP header (typically 54 bytes, but can vary)
        int headerSize = 54;
        int blockSize = 16;

        var blocks = new HashSet<string>();
        int totalBlocks = 0;

        for (int i = headerSize; i + blockSize <= data.Length; i += blockSize)
        {
            byte[] block = new byte[blockSize];
            Array.Copy(data, i, block, 0, blockSize);
            blocks.Add(Convert.ToHexString(block));
            totalBlocks++;
        }

        return (totalBlocks, blocks.Count);
    }

    /// <summary>
    /// Returns analysis summary for grading.
    /// </summary>
    public string GetAnalysisSummary()
    {
        // TODO: Return a summary of your analysis
        // This should include:
        // 1. What patterns you observed in the encrypted image
        // 2. What you think the original image contained
        // 3. Why ECB mode leaks this information
        return """
                    1. Observed patterns: The background is all the same color and their is a silhouette of pixel noise in the middle which is also probably all the same color
                    2. Likely original content: the linux pinguin on a white background
                    3. Why this happens: Each block of the image is encrypted with the same key meaning that a color will look the same across the whole image and allow you to outline the contents of the image
               """;
    }
}
