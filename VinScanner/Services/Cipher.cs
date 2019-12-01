using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace VinScanner.Services
{
    public class Cipher
    {
        /// <summary>
        /// Used to encrypt plain text
        /// </summary>
        /// <param name="chiperText">The text to encrypt</param>
        /// <param name="passPhraseKey">A key used to tie it to the encrypted text</param>
        /// <returns></returns>
        public static string EncryptString(string chiperText, string passPhraseKey)
        {
            var key = Encoding.UTF8.GetBytes(passPhraseKey);

            using (var aesAlgorithm = Aes.Create())
            {
                using (var encryptor = aesAlgorithm.CreateEncryptor(key, aesAlgorithm.IV))
                {
                    using (var memoryStreamEncrypt = new MemoryStream())
                    {
                        using (var cryptoStreamEncrypt = new CryptoStream(memoryStreamEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var steamWriterEncrypt = new StreamWriter(cryptoStreamEncrypt))
                        {
                            steamWriterEncrypt.Write(chiperText);
                        }

                        var iv = aesAlgorithm.IV;

                        var decryptedContent = memoryStreamEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        /// <summary>
        /// Used to decrypt an encrypted text
        /// </summary>
        /// <param name="cipherText">The encrypted text</param>
        /// <param name="passPhraseKey">The key tied to the encrypted text</param>
        /// <returns></returns>
        public static string DecryptString(string cipherText, string passPhraseKey)
        {
            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(passPhraseKey);

            using (var aesAlgorithm = Aes.Create())
            {
                using (var decryptor = aesAlgorithm.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var memoryStreamDecrypt = new MemoryStream(cipher))
                    {
                        using (var cryptoStreamDecrypt = new CryptoStream(memoryStreamDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var streamWriterDecrypt = new StreamReader(cryptoStreamDecrypt))
                            {
                                result = streamWriterDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
    }
}
