using Game.Entities;
using Syscrack;

namespace Client
{
    public class Game
    {

        public static void Init()
        {

            Console.WriteLine("Client Init");
            Engine.s_instance.Viewport = new AsciiViewport(Console.WindowWidth - 8, Console.WindowHeight - 8);
        }

        public static void Update()
        {


        }

        public static void Draw()
        {

            Client.Utils.PrintLine(0, 0, "Hello World!");
            Client.Utils.PrintLine(0, 1, "Tick: " + Environment.TickCount);

            var viewport = (AsciiViewport)Engine.s_instance.Viewport;
            viewport.Renderer.DrawRectangle(10, 10, 5, 10);
            viewport.Renderer.DrawRectangle(20, 10, 5, 5, '?');
        }
    }
}

