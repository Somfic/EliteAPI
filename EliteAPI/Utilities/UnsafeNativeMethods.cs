using System;
using System.Runtime.InteropServices;

namespace EliteAPI
{
    internal static class UnsafeNativeMethods
    {
        [DllImport("Shell32.dll")]
        public static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);
    }
}