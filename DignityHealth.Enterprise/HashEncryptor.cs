using System;
using System.Text;
using System.Security.Cryptography;

namespace Enterprise
{
    /// <summary>
    /// Salted password hashing with PBKDF2-SHA1.        
    /// </summary>
    public class HashEncryptor
    {
        // The following constants may be changed without breaking existing hashes.
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 100;     
   
        public const int SALT_INDEX = 0;
        public const int ITERATION_INDEX = 1;
        public const int PBKDF2_INDEX = 2;
              
        /// <summary>
        /// Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        public static string CreateHashPassword(string password,out string saltHash)
        {
            byte[] salt = GetSaltHash();
            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            saltHash =Convert.ToBase64String(salt);
            return Convert.ToBase64String(hash);
        }


        /// <summary>
        /// returns salt hash value
        /// </summary>
        /// <returns></returns>
        public static byte[] GetSaltHash()
        {
           // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);
            return salt;
        
        }

        /// <summary>
        /// Validates a password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidatePassword(string password, string passwordHash,string saltHash)
        {

            // Extract the parameters from the hash
            //char[] delimiter = { ':' };
            //string[] split = saltHash.Split(delimiter);
            int iterations = PBKDF2_ITERATIONS;
            byte[] salt = Convert.FromBase64String(saltHash);
            byte[] hash = Convert.FromBase64String(passwordHash);
            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Compares two byte arrays in length-constant time. This comparison
        /// method is used so that password hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        /// <summary>
        /// Computes the PBKDF2-SHA1 hash of a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        /// <returns>A hash of the password.</returns>
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        /// <summary>
        /// Encrypts the AD username
        /// </summary>
        /// <param name="userName">AD username</param>
        /// <returns>Encrypted string</returns>
        public static string EncryptADUsername(string userName)
        {
            SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider();
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] userNameHash = provider.ComputeHash(encoding.GetBytes(userName));
            return Convert.ToBase64String(userNameHash);
        }

        //--------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Decrypts base 64 string
        /// </summary>
        /// <param name="stringToDecrypt">stringToDecrypt</param>       
        /// <returns></returns>
        //--------------------------------------------------------------------------------------------------------
        public static string Base64Decrypt(string stringToDecrypt)
        {
            byte[] data = Convert.FromBase64String(stringToDecrypt);
            string decodedString = Encoding.UTF8.GetString(data);
            return decodedString;
        }
    }
} 
