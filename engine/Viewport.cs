using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syscrack
{
    public class Viewport
    {

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
