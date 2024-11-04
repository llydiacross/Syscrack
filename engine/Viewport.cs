using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Syscrack
{
    public class Viewport
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public Rect GetViewportRectangle() {
            Process process = Process.GetCurrentProcess();
            IntPtr ptr = process.MainWindowHandle;
            Rect Rect = new Rect();
            GetWindowRect(ptr, ref Rect);
            return Rect;
        }

        public virtual void Draw()
        {

            throw new ApplicationException("Draw on Base Viewport should never be called, remove base.Draw() call if present");
        }

        public virtual void Init()
        {

            throw new ApplicationException("Init on Base Viewport should never be called, remove base.Init() call if present");
        }
    }
}
