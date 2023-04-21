using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

using Passless;
using Yubico.YubiKey.Piv;
using Yubico.YubiKey;

namespace Passless.Konsole
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Controller.Activation();
        }
    }
}