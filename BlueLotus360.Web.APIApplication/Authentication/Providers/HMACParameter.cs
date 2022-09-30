using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Authentication.Providers
{
    public class HMACParameter
    {
        public string HTTPVerb { get; set; }
        public string ContentStrng { get; set; }
        public string ContentType { get; set; }
        public string TimeStamp { get; set; }
        public string RequestURI { get; set; }
        public string SecretKey { get; set; }

        public bool isValidSignature(string responseSignature)
        {
            if (string.IsNullOrEmpty(responseSignature))
            {
                return false;
            }
            var calculatedSignature = getCalculatedSignature();
            if (string.IsNullOrEmpty(calculatedSignature))
            {
                return false;
            }

            return calculatedSignature.Equals(responseSignature,
                StringComparison.InvariantCultureIgnoreCase);


        }

        private string getCalculatedSignature()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(HTTPVerb);
            builder.Append(ContentStrng);
            builder.Append(ContentType);
            builder.Append(TimeStamp);
            builder.Append(RequestURI);
            string preCalculatedValue = builder.ToString();
            return null;
        }





        private static async Task<string> ComputeHash(HttpContent httpContent)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] hash = null;

                var content = await httpContent.ReadAsByteArrayAsync();
                string stringRep = Encoding.UTF8.GetString(content, 0, content.Length);
                if (content.Length != 0)
                {
                    hash = md5.ComputeHash(content);
                }
                return Convert.ToBase64String(hash);
            }
        }
        public async Task<string> CreateMD5(HttpContent httpContent)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = await httpContent.ReadAsByteArrayAsync();
                string val = Encoding.UTF8.GetString(inputBytes);
                byte[] transfer = Encoding.UTF8.GetBytes(val);
                byte[] hashBytes = md5.ComputeHash(transfer);
                return ConvertToHexString(hashBytes);
            }
        }

        private string ConvertToHexString(byte[] hashBytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
    }

}