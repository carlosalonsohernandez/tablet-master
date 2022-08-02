using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TabletMaster.Core
{
    public class MousePosition
    {
        public int MouseX { get; set; }
        public int MouseY { get; set; }

        public MousePosition(int MouseX, int MouseY)
        {
            this.MouseX = MouseX;
            this.MouseY = MouseY;
        }

        public int getMouseX()
        {
            return this.MouseX;
        }

        public int getMouseY()
        {
            return this.MouseY;
        }
    }
}
