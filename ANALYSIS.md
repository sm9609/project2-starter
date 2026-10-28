# Crypto Attack Lab - Analysis
## YOUR NAME HERE
## CSCI 251 - Project 2

---

## Challenge 1: Substitution Cipher

### Attack Method
<!-- Describe your frequency analysis approach (2-3 sentences) -->
The first thing I looked at was the most common letter in the chipertexts. The most common letter was most likely E. From their I noticed E and H are 2 letters appart so i applied that rule to all the letters. 

### Why This Attack Works
<!-- Explain why substitution ciphers are vulnerable to frequency analysis (2-3 sentences) -->
Substitution ciphers dont change the frequancy of letters, so common letters can easily be deciphered.
Once a single letter is deciphered in a substitution cipher it is possiable to find the rule and decrypt the whole ciphertext.

### How Modern Encryption Prevents This
<!-- Explain how AES differs fundamentally from substitution ciphers (2-3 sentences) -->
AES enrypts one partition of the Data at a time. Moreover, AES uses complex math operations that distroy any strace of the plaintext ferquencies.

---

## Challenge 2: IV Reuse

### Attack Method
<!-- Describe the XOR attack step by step -->
The Xor attacks uses known parts of the ciphertext and plaintext to recover the keystream.
Once the keystream is known, any part of the message can by dycrpted.

### Why This Attack Works
<!-- Explain the math: why does XOR cancel the keystream? Show the equations. -->
Anything XOR'ed against itsel is 0 so if the ciphertext is just C1 XOR K than XORing two cipher text would eliminate the Key.
C1 XOR C2 = P1 XOR P2
C1 XOR C2 XOR P1 = P2

### How Modern Encryption Prevents This
<!-- Explain proper IV/nonce handling in AES-CTR and AES-GCM (2-3 sentences) -->
To prevent from Xor attacks the keystream should be pair with a IV/nonce to 
make it different everytime its used. You must also ensure that the same keystream isn't used twice; otherwise the key can be founds.

---

## Challenge 3: ECB Mode

### What You Observed
<!-- Describe what patterns you could see in the encrypted image -->
Based on the shape of the image i think its the linux pinguin. The same pattern that appears on the belly of the pinguin appears on the background so the background must also be white.

### Why ECB Leaks Information
<!-- Explain why identical blocks are a problem (2-3 sentences) --> ECB blocks that are identical have identical plaintext, meaning its posable to decipher a pattern. In the case of an image you can see the outline of any patterns/similar pixels.


### How Modern Encryption Prevents This
<!-- Explain how CBC/CTR/GCM modes avoid this issue (2-3 sentences) -->
ECB is the only one that uses the same key with no IV for the entire encription. CBC, CTR, and GCM each have their own method for making each encryption unique even though they use the same key.


---

## Reflection

<!-- Optional: What did you learn from this project? What surprised you? -->
Challange 1 gave me insight on how I should be thinking then trying to decrypt something. 
Challange 2 awnsered any questions about how keystreams works in practice
Challange 3 visualized what it looks like when ECB leaks information.

