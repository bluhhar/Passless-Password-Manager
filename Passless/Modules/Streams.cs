using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passless.Modules
{
    internal class Streams
    {
        private const int BufferSize = 512;

        public static void PipeAll(Stream inStr, Stream outStr)
        {
            byte[] bs = new byte[BufferSize];
            int numRead;
            while ((numRead = inStr.Read(bs, 0, bs.Length)) > 0)
            {
                outStr.Write(bs, 0, numRead);
            }
        }
    }
}
