using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Passless;

namespace Passless.Konsole
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Passless.Controller.TestEnc();
            Passless.Controller.TestDec();
        }
    }
}
