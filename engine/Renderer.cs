using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syscrack
{
    public abstract class Renderer(Viewport viewport)
    {
        public Viewport Viewport { get; private set; } = viewport;

        public abstract void DrawRectangle(int x, int y, int width, int height);

        public abstract void DrawString(int x, int y, string str);
    }
}
