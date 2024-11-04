using Syscrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class Utils
    {

        public static void PrintLine(int x, int y, string line)
        {
            var viewport = (AsciiViewport)Engine.s_instance.Viewport;
            viewport.Renderer.DrawString(x, y, line);
        }
    }
}
