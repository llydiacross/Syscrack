using Game.Entities;
using Syscrack;

namespace Client
{
    public class Game
    {

        public static void Init()
        {

            Console.WriteLine("Client Init");
            Engine.s_instance.Viewport = new AsciiViewport(Console.WindowWidth - 8, Console.WindowHeight - 8); // We want to use the Ascii Viewport given by the engine, can be changed later to another viewport/render very easily
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
            viewport.Renderer.DrawRectangle(20, 15, 15, 5, '?');
        }
    }
}

