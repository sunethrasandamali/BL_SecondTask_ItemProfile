using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Utility
{
    public static class CryptoService
    {
        private static readonly string key = "BLXItemImgUpload";//length 16

        public static string ToEncryptedData(string input)
        {
            byte[] iv = new byte[16];//match key size
            byte[] array; using (Aes aes = Aes.Create())
            {
                try
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(key);
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                }
                catch (Exception ee)
                {
                    Console.Write(ee.Message.ToString());
                }
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV); using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(input);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        public static string ToDecryptedData(string input)
        {
            try
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(input); using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV); using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                return "";
            }

        }
    }
}
