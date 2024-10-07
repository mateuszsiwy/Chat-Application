using System.Security.Cryptography;
using System.Text;

public static class RSAKeyManager
{
    public static void GenerateAndSaveKeys(out string publicKey, out string privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
        {
            publicKey = rsa.ToXmlString(false);
            privateKey = rsa.ToXmlString(true);
        }
    }
}

public static class RSAEncryptionHelper
{
    public static byte[] EncryptData(string data, string publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKey);
            return rsa.Encrypt(Encoding.UTF8.GetBytes(data), false);
        }
    }

    public static string DecryptData(byte[] encryptedData, string privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKey);
            byte[] decryptedData = rsa.Decrypt(encryptedData, false);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
