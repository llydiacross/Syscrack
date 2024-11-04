using Game.Entities;
using Syscrack;

namespace Game
{
    public class Game
    {

        public static void Init()
        {

            Console.WriteLine("Game Init");

            Syscrack.Utils.RegisterEntity(typeof(Player));
            Syscrack.Utils.RegisterEntity(typeof(Computer));
        }

        public static void Update()
        {
            
            // Update input on the server
            Engine.s_instance.Input.UpdateInput();
        }
    }
}
