using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Phoenix.NET.Interop;

public static class User32
{
    public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int EnumWindows(EnumWindowProc callback, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowTextLength(IntPtr hWnd);
    
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
}