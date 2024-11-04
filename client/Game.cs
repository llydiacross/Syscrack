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
            // Update input on the client
            Engine.s_instance.Input.UpdateInput();
        }

        public static void Draw()
        {

            Client.Utils.PrintLine(0, 0, "Hello World!");
            Client.Utils.PrintLine(0, 1, "Tick: " + Environment.TickCount);
            Client.Utils.PrintLine(0, 2, "x/y: " + Engine.s_instance.Input.MousePosition.X + "/" + Engine.s_instance.Input.MousePosition.Y);

            var viewport = (AsciiViewport)Engine.s_instance.Viewport;
            viewport.Renderer.DrawRectangle(10, 10, 5, 10);
            viewport.Renderer.DrawRectangle(20, 15, 15, 5, '?');
        }
    }
}

