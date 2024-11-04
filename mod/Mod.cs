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

            Syscrack.Utils.RegisterEntity(typeof(ExampleEntity));

            // Just a test of creating an entity from the game.dll inside the mod.dll
            Syscrack.Utils.CreateEntity("Game.Entities.Player");
        }

        public static void Update()
        {

        }
    }
}
