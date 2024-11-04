using Syscrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Entities
{
    public class ExampleEntity : Entity
    {

        public override void OnSpawn()
        {
            Console.WriteLine("Hello World");
        }
    }
}
