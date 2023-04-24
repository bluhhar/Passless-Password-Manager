using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Passless.Classes.Random
{
    public static class PassphraseGenerator
    {
        private static RNGCryptoServiceProvider _rand = new RNGCryptoServiceProvider();

        private static int RandomInteger(int min, int max)
        {
            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                byte[] four_bytes = new byte[4];
                _rand.GetBytes(four_bytes);

                // Convert that into an uint.
                scale = BitConverter.ToUInt32(four_bytes, 0);
            }

            // Add min to the scaled difference between max and min.
            return (int)(min + (max - min) *
                (scale / (double)uint.MaxValue));
        }

        public static string RandomPassphrase(int countWords, string[] words, string separator)
        {
            string password = "";
            int rnd;
            for (int i = 0; i < countWords; i++)
            {
                rnd = RandomInteger(0, words.Length);
                //passphrase[i] += words[rnd];
                password += words[rnd] + separator;
            }
            return password;
        }
    }
}
