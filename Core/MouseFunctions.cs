using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TabletMaster.Core;

namespace TabletMaster
{
    internal class MouseFunctions
    {

        //DLL Imports to use for simulation of left click!
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


        // Handles simulating the left clicks given a MousePosition instance as a parameter
        public static void SimulateLeftClick(MousePosition mousePos)
        {
            int mouseX = mousePos.getMouseX();
            int mouseY = mousePos.getMouseY();

            SetCursorPos(mouseX, mouseY);
            mouse_event(MOUSEEVENTF_LEFTDOWN, mouseX, mouseY, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, mouseX, mouseY, 0, 0);
        }
    }
}
