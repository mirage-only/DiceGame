using System.Security.Cryptography;

namespace DiceGame;

public class NumberGenerator
{
    public static int GenerateNumber(int min, int max)
    {
        return RandomNumberGenerator.GetInt32(min, max);
    }

    public static byte[] GenerateSecretKeyNumber()
    {
        byte[] secretKey = new byte[256];
        
        RandomNumberGenerator.Fill(secretKey);

        return secretKey;
    }
}