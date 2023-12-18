using System;
using System.Security.Cryptography;
using System.Text;

namespace Assistant.Extensions
{ 
    public static class PasswordExtensions
    {
        public static string GeneratePasswordSalt(this int length)
        {
            try
            {
                const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
                var randNum = new Random();
                var chars = new char[length];
                var allowedCharCount = allowedChars.Length;
                for (var i = 0; i <= length - 1; i++)
                {
                    chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
                }
                return new string(chars);

            }
            catch (Exception e)
            {
                return Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, length);
            }

        }
        public static string EncodePassword(this string pass, string salt) //encrypt password    
        {
            var bytes = Encoding.Unicode.GetBytes(pass);
            var src = Encoding.Unicode.GetBytes(salt);
            var dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1")!;
            var inArray = algorithm.ComputeHash(dst);
            //return Convert.ToBase64String(inArray);    
            return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }
        private static string EncodePasswordMd5(string pass) //Encrypt using MD5    
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(pass);
            var encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string    
            return BitConverter.ToString(encodedBytes);
        }
    }
}
