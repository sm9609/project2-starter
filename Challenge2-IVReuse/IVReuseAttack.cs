// Samuel Mensah
// CSCI 251 - Project 2: Crypto Attack Lab
// Challenge 2: Exploit IV Reuse in AES-CTR

namespace CryptoAttackLab;

/// <summary>
/// Exploit IV reuse vulnerability in AES-CTR mode.
/// </summary>
public class IVReuseAttack
{
    /// <summary>
    /// XORs two byte arrays together.
    /// </summary>
    public byte[] Xor(byte[] a, byte[] b)
    {
        int length = Math.Min(a.Length, b.Length);
        byte[] result = new byte[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = (byte)(a[i] ^ b[i]);
        }

        return result;
    }

    /// <summary>
    /// Given ciphertexts encrypted with the same IV, and known plaintext
    /// for one message, recover the plaintext of another message.
    /// </summary>
    public byte[] RecoverPlaintext(byte[] ciphertext1, byte[] knownPlaintext1, byte[] targetCiphertext)
    {
        // TODO: Implement the IV reuse attack
        //
        // In AES-CTR mode with the same key and IV:
        //   C1 = P1 XOR KeyStream
        //   C2 = P2 XOR KeyStream
        //
        // If we know P1 (or part of it):
        //   KeyStream = C1 XOR P1
        //   P2 = C2 XOR KeyStream
        //
        // Steps:
        // 1. XOR ciphertext1 with knownPlaintext1 to get the keystream
        // 2. XOR the keystream with targetCiphertext to get the target plaintext
        //
        // Note: You can only recover bytes where you know the corresponding
        // plaintext in message 1.

        throw new NotImplementedException();
    }

    /// <summary>
    /// Loads ciphertexts and performs the attack.
    /// Returns the recovered plaintext of message 3.
    /// </summary>
    public string GetRecoveredPlaintext()
    {
        // Load the ciphertexts (hex-encoded, one per line)
        var lines = File.ReadAllLines("Challenge2-IVReuse/ciphertexts.txt");
        byte[] c1 = Convert.FromHexString(lines[0]);
        byte[] c2 = Convert.FromHexString(lines[1]);
        byte[] c3 = Convert.FromHexString(lines[2]);

        // Known: The full plaintext of Message 1
        string knownPlaintext1 = "From: Alice\nTo: Bob\nSubject: Meeting\n\nThe meeting is scheduled for Thursday at 3pm in the second floor conference room. Please bring all project documents and your laptop.";
        byte[] knownPlaintext = System.Text.Encoding.UTF8.GetBytes(knownPlaintext1);

        // Your task: Recover message 3
        byte[] recovered = RecoverPlaintext(c1, knownPlaintext, c3);

        return System.Text.Encoding.UTF8.GetString(recovered);
    }
}
