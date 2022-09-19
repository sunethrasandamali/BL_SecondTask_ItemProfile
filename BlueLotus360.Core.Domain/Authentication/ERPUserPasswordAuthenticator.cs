using BlueLotus360.Core.Domain.Definitions.Authentication;
using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Authentication
{
    public class ERPUserPasswordAuthenticator : IUserPasswordAuthenticator
    {
        public bool Authenticate(User user, string rawPassword)
        {
            if(rawPassword==null || rawPassword.Length == 0)
            {
                return false;
            }
            if (user == null)
            {
                return false;
            }
            try
            {
                byte[] hash = null;
                hash = GetHashKy(user.UserID.ToLower());
                string CalculatedHash = EncryptData(hash, rawPassword);

                return user.HashedPassword.Equals(CalculatedHash);
            }
            catch (Exception exp)
            {
                return false;
            }
        }
        private byte[] GetHashKy(string hashKy)
        {
            //Initialise               
            UTF8Encoding encoder = new UTF8Encoding();

            //Get the salt 
            string salt = "Blue Lotus from HTN";

            byte[] saltBytes = encoder.GetBytes(salt);

            // Setup the hasher
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKy, saltBytes);

            //Return the Key
            return rfc.GetBytes(16);
        }

        public string EncryptData(byte[] key, string dataToEncrypt)
        {
            // Initialise
            AesManaged encryptor = new AesManaged();

            // Set the key
            encryptor.Key = key;
            encryptor.IV = key;
            // create a memory stream
            using (MemoryStream encryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(dataToEncrypt);
                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.FlushFinalBlock();
                    encrypt.Close();

                    // Return the encrypted data
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }


    }
}
