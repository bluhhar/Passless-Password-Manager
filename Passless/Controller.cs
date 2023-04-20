using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Passless.Modules.GnuPGHelper;

namespace Passless
{
    public class Controller
    {
        public static void TestEnc()
        {
            PGPEncryptDecrypt.EncryptFile("123.txt",
                              "321.txt",
                              "bluhhar_0xF0B87C99_public.asc",
                              false,
                              false);
        }
        public static void TestDec()
        {
            PGPEncryptDecrypt.Decrypt("321.txt",
                          "bluhhar_0xF0B87C99_SECRET.asc",
                          "daf123456",
                          "test");
        }
    }
}
