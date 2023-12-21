using System.Runtime.InteropServices;

public class MouseOperations
{
    public struct MousePoint
    {
        public int X;

        public int Y;

        public MousePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetCursorPos(out MousePoint lpMousePoint);

    public static MousePoint GetCursorPosition()
    {
        if (!GetCursorPos(out MousePoint currentMousePoint))
        {
            currentMousePoint = new MousePoint(0, 0);
        }
        return currentMousePoint;
    }


    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);


    // ConsoleApp1.MouseOperations
    public static void MouseEvent(MouseEventFlags value)
    {
        MousePoint position = GetCursorPosition();
        mouse_event((int)value, position.X, position.Y, 0, 0);
    }


    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetCursorPos(int x, int y);

    // ConsoleApp1.MouseOperations
    public static void SetCursorPosition(int x, int y)
    {
        SetCursorPos(x, y);
    }

    // ConsoleApp1.MouseOperations
    public static void SetCursorPosition(MousePoint point)
    {
        SetCursorPos(point.X, point.Y);
    }

    [Flags]
    public enum MouseEventFlags
    {
        LeftDown = 0x2,
        LeftUp = 0x4,
        MiddleDown = 0x20,
        MiddleUp = 0x40,
        Move = 0x1,
        Absolute = 0x8000,
        RightDown = 0x8,
        RightUp = 0x10
    }

}