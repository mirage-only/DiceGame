using System.Security.Cryptography;
using System.Text;
using SHA3.Net;

namespace DiceGame;

public class HashOperations
{
    public static string GenerateSecretKey()
    {
        var randomBytes = NumberGenerator.GenerateSecretKeyNumber();

        var secretKey = BitConverter.ToString(Sha3.Sha3256().ComputeHash(randomBytes)).Replace("-", "");
        
        return secretKey;
    }

    public static string GenerateHMAC(int randomNumber, string secretKey)
    {
        string stringHmac = secretKey + randomNumber;
        
        byte[] bytesForHmac = Encoding.UTF8.GetBytes(stringHmac);

        byte[] hmac = Sha3.Sha3256().ComputeHash(bytesForHmac);
        
        return BitConverter.ToString(hmac).Replace("-", "").ToLower();
    }
}