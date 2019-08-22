using System;
using System.Runtime.InteropServices;

namespace EliteAPI.Configuration
{
    internal static class DefaultPaths
    {
        [DllImport("Shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr ppszPath);

        internal static string JournalDirectory
        {
            get
            {
                int result = SHGetKnownFolderPath(new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4"), 0, new IntPtr(0), out IntPtr path);
                if ( result >= 0 )
                {
                    try
                    {
                        return Marshal.PtrToStringUni(path) + @"\Frontier Developments\Elite Dangerous";
                    }
                    catch
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
