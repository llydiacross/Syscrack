using Syscrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    public class Player : Entity
    {

        public int Health { get; set; }

        public Player()
        {

            Engine.s_instance.Draw.Text("Hello World!");
        }
    }
}
