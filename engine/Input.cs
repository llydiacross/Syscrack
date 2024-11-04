using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Syscrack;

public class Input
{

    public Vector2D MousePosition {get; set;}
 
    /// <summary>
    /// Struct representing a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Point(POINT point)
        {
            return new Point(point.X, point.Y);
        }
    }

    /// <summary>
    /// Retrieves the cursor's position, in screen coordinates.
    /// </summary>
    /// <see>See MSDN documentation for further information.</see>
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out POINT lpPoint);

    public static Point GetCursorPosition()
    {
        POINT lpPoint;
        GetCursorPos(out lpPoint);
        // NOTE: If you need error handling
        // bool success = GetCursorPos(out lpPoint);
        // if (!success)
            
        return lpPoint;
    }

    public void UpdateInput() {
        MousePosition = GetMousePosition();
    }

    public static Vector2D GetMousePosition() {

        var window = Engine.s_instance.Viewport.GetViewportRectangle();
        var cur = GetMousePosition();

        return new Vector2D(window.Left - cur.X, window.Top - cur.Y);
    }
}