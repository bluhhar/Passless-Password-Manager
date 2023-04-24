using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gpg.NET;
namespace Passless
{
    public static class Controller
    {
        public static void Activation()
        {
            GpgNet.Initialise(@"C:\Program Files (x86)\GnuPG\bin\libgpgme-11.dll");
        }
    }
}
