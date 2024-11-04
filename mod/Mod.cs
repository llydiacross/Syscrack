using Mod.Entities;
using Syscrack;
using System.Numerics;

namespace Mod
{
    public class Mod
    {

        public static void Init()
        {

            Console.WriteLine("Mod successfully loaded!");
            Game.Utils.CreateEntity(typeof(ExampleEntity));
        }

        public static void Update()
        {

        }
    }
}
