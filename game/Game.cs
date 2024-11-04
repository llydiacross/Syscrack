using Game.Entities;
using Syscrack;

namespace Game
{
    public class Game
    {

        public static void Init()
        {

            Engine.s_instance.Draw.Text("Hello World");

            var player = (Player)Utils.CreateEntity("Player");
            player.Health = 100;

            var computer = (Computer)Utils.CreateEntity("Computer");
            var computer2 = (Computer)Utils.CreateEntity("Computer");
            var computer3 = (Computer)Utils.CreateEntity("Computer");

            Engine.s_instance.Draw.Text("Player Health (Server):" + player.Health);
        }

        public static void Update()
        {

        }
    }
}
