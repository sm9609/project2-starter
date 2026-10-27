# Crypto Attack Lab - Analysis
## YOUR NAME HERE
## CSCI 251 - Project 2

---

## Challenge 1: Substitution Cipher

### Attack Method
<!-- Describe your frequency analysis approach (2-3 sentences) -->
The first thing I looked at was the most common letter in the chipertexts. The most common letter was most likely E.
From their I noticed E and H are 2 letters appart so i applied that rule to all the letters. 

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


### Why This Attack Works
<!-- Explain the math: why does XOR cancel the keystream? Show the equations. -->


### How Modern Encryption Prevents This
<!-- Explain proper IV/nonce handling in AES-CTR and AES-GCM (2-3 sentences) -->


---

## Challenge 3: ECB Mode

### What You Observed
<!-- Describe what patterns you could see in the encrypted image -->


### Why ECB Leaks Information
<!-- Explain why identical blocks are a problem (2-3 sentences) -->


### How Modern Encryption Prevents This
<!-- Explain how CBC/CTR/GCM modes avoid this issue (2-3 sentences) -->


---

## Reflection

<!-- Optional: What did you learn from this project? What surprised you? -->

