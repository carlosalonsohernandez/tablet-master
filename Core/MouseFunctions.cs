using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TabletMaster
{
    internal class MouseFunctions
    {
        // WinForm-Like Cursor.Position workaround
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        // This method handles simulating a left mouse click
        public static void SimulateLeftClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        // This method obtains the current position of the mouse cursor.
        public static Point GetPosition(Window window)
        {
            var cursorPosition = System.Windows.Input.Mouse.GetPosition(window);
            return new Point(cursorPosition.X + window.Left, cursorPosition.Y + window.Top);
        }
    }
}
