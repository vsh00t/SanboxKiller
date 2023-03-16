using System;
using System.Runtime.InteropServices;

namespace SandboxKiller
{
    public static class DetectDebugger
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsDebuggerPresent();


    }
}


