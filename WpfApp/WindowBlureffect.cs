using System;
using System.Runtime.InteropServices;
using System.Windows;

public class WindowBlureffect
{
    // https://github.com/jdscodelab/LoginUIBlurredAcrylicBackground
    [DllImport("user32.dll")]
    static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
    public enum AccentState
    {
        ACCENT_DISABLED = 0,
        ACCENT_ENABLE_GRADIENT = 1,
        ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
        ACCENT_ENABLE_BLURBEHIND = 3,
        ACCENT_ENABLE_ACRYLICBLURBEHIND = 4,
        ACCENT_INVALID_STATE = 5
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct AccentPolicy
    {
        public AccentState AccentState;
        public uint AccentFlags;
        public uint GradientColor;
        public uint AnimationId;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowCompositionAttributeData
    {
        public WindowCompositionAttribute Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }
    public enum WindowCompositionAttribute
    {
        WCA_ACCENT_POLICY = 19
    }
    public WindowBlureffect(Window window, AccentState accentState)
    {
        this.window = window;
        this.accentState = accentState;
        EnableBlur();
    }

    #region region
    private uint _blurOpacity;

    private Window window { get; set; }
    private AccentState accentState { get; set; }
    public double BlurOpacity
    {
        get { return _blurOpacity; }
        set { _blurOpacity = (uint)value; EnableBlur(); }
    }
    #endregion
    private void EnableBlur()
    {
        var windowHelper = new System.Windows.Interop.WindowInteropHelper(window);
        var accent = new AccentPolicy();
        accent.AccentState = accentState;
        accent.GradientColor = 0xFFFFFF;
        var accentStructSize = Marshal.SizeOf(accent);
        var accentPtr = Marshal.AllocHGlobal(accentStructSize);
        Marshal.StructureToPtr(accent, accentPtr, false);
        var data = new WindowCompositionAttributeData();
        data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
        data.SizeOfData = accentStructSize;
        data.Data = accentPtr;
        SetWindowCompositionAttribute(windowHelper.Handle, ref data);
        Marshal.FreeHGlobal(accentPtr);
    }
}
