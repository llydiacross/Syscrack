using Game.Entities;
using Syscrack;

namespace Game
{
    public class Game
    {

        public static void Init()
        {

            Engine.s_instance.Draw.Text("Hello World");

            var player = (Player)Entity.GetFirstEntityByClassName("Player");
            Console.WriteLine("Health according to client: " + player.Health);

            ConsoleKeyInfo t;
            while ((t = Console.ReadKey()).Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Hello World!");
                Console.WriteLine(t.KeyChar);
            }
        }

        public static void Update()
        {


        }
    }
}
