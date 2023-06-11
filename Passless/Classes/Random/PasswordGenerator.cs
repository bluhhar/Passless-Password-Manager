using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Passless.Classes.Random
{
    public static class PasswordGenerator
    {
        private static RNGCryptoServiceProvider _rand = new RNGCryptoServiceProvider();

        private const string _lower = "abcdefghijklmnopqrstuvwxyz";
        private const string _upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _numbers = "0123456789";
        private const string _special = @"~@#$%^&`";
        private const string _slashes = @"/_|-\";
        private const string _brackets = @"()[]{}";
        private const string _commadot = @".,:;";
        private const string _apostraph = @"'";
        private const string _operations = "<*+-!?=>";

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

        // Return a random character from a string.
        private static string RandomChar(string str)
        {
            return str.Substring(RandomInteger(0, str.Length), 1);
        }

        // Return a random permutation of a string.
        private static string RandomizeString(string str)
        {
            string result = "";
            while (str.Length > 0)
            {
                // Pick a random character.
                int i = RandomInteger(0, str.Length - 1);
                result += str.Substring(i, 1);
                str = str.Remove(i, 1);
            }
            return result;
        }

        public static string RandomPassword(int countChars, string otherChars,
            int[] rules)
        {
            int j = 0;
            for (int i = 0; i < rules.Length; i++)
            {
                if (rules[i] == 0)
                {
                    j++;
                }
            }

            if (j == rules.Length)
            {
                return "";
            }

            // Make a list of allowed characters.
            string allowed = "";

            // Satisfy requirements.
            string password = "";
            if (rules[0] == 1 &&
                password.IndexOfAny(_lower.ToCharArray()) == -1)
            {
                allowed += _lower;
                password += RandomChar(_lower);
            }
            if (rules[1] == 1 &&
                password.IndexOfAny(_upper.ToCharArray()) == -1)
            {
                allowed += _upper;
                password += RandomChar(_upper);
            }
            if (rules[2] == 1 &&
                password.IndexOfAny(_numbers.ToCharArray()) == -1)
            {
                allowed += _numbers;
                password += RandomChar(_numbers);
            }
            if (rules[3] == 1 &&
                password.IndexOfAny(_special.ToCharArray()) == -1)
            {
                allowed += _special;
                password += RandomChar(_special);
            }
            if (rules[4] == 1 &&
                password.IndexOfAny(_slashes.ToCharArray()) == -1)
            {
                allowed += _slashes;
                password += RandomChar(_slashes);
            }
            if (rules[5] == 1 &&
                password.IndexOfAny(_brackets.ToCharArray()) == -1)
            {
                allowed += _brackets;
                password += RandomChar(_brackets);
            }
            if (rules[6] == 1 &&
                password.IndexOfAny(_commadot.ToCharArray()) == -1)
            {
                allowed += _commadot;
                password += RandomChar(_commadot);
            }
            if (rules[7] == 1 &&
                password.IndexOfAny(_apostraph.ToCharArray()) == -1)
            {
                allowed += _apostraph;
                password += RandomChar(_apostraph);
            }
            if (rules[8] == 1 &&
                password.IndexOfAny(_operations.ToCharArray()) == -1)
            {
                allowed += _operations;
                password += RandomChar(_operations);
            }
            if (rules[9] == 1 &&
                (password.IndexOfAny(otherChars.ToCharArray()) == -1))
            {
                allowed += otherChars;
                password += RandomChar(otherChars);
            }

            // Add the remaining characters randomly.
            while (password.Length < countChars)
                password += allowed.Substring(
                    RandomInteger(0, allowed.Length - 1), 1);

            // Randomize (to mix up the required characters at the front).
            password = RandomizeString(password);

            return password;
        }
    }
}
