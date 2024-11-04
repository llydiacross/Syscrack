namespace Syscrack
{
    internal class Program
    {

        public List<Host> Hosts = new List<Host>();

        static void Main(string[] args)
        {

            Console.WriteLine("OS: " + Utils.FriendlyName());

            // have be set by a flag
            var IsLocal = true;

            Console.WriteLine("Creating Engine");
            _ = new Engine();

            Console.WriteLine("Creating Hosts");
            var program = new Program();

            // start the main game dll on the main server
            var game = new Host();
            game.Start("game.dll"); // load the main game dll

            program.Hosts.Add(game);

            if (!game.IsActive)
            {
                Console.WriteLine("Sorry! For some unexplained reason. A critical error in the server instance has prevented it from starting. Please check if any mods are installed, and try again");
                Environment.Exit(0);
            }

            if (!IsLocal)
            {
                Engine.s_instance.SetAsDedicatedServer();
            }

            if (!Engine.s_instance.IsServer)
            {

                // TODO: if we are running as a client and not just the sever, load the client.dll
                var client = new Host();
                client.Start("client.dll", "Client.Game"); // load the main game dll

                if (!client.IsActive)
                {
                    Console.WriteLine("Sorry! For some unexplained reason. A critical error in the client instance has prevented it from starting. Please check if any mods are installed, and try again");
                    Environment.Exit(0);
                }

                program.Hosts.Add(client);
            }

            // Mod Test TODO: Make this read from some sort of directory all the mods and stuff
            var mod = new Host();
            mod.Start("mod.dll", "Mod.Mod");

            if (!Engine.s_instance.IsServer)
            {
                // Initialize the current viewport
                Engine.s_instance.Viewport.Init();
            }

            // enter game loop
            while (true)
            {

                // invoke update
                program.Hosts[0].Game.Invoke("Update", []);

                mod.Game.Invoke("Update", [], "Mod.Mod");

                if (!Engine.s_instance.IsServer)
                {
                    // invoke update on client
                    program.Hosts[1].Game.Invoke("Update", [], "Client.Game");
                    // invoke draw
                    program.Hosts[1].Game.Invoke("Draw", [], "Client.Game");
                }

                // draw the viewport
                Engine.s_instance.Viewport.Draw();
            }
        }
    }

    public class Engine
    {

        public Host Host;
        public Database Database;
        public Viewport Viewport;
        public Network Network;

        public Input Input;

        public static Engine s_instance;

        public bool IsServer { get; private set; }


        public void SetAsDedicatedServer()
        {

            IsServer = true;
        }

        public Engine()
        {

            if (s_instance != null)
                throw new ApplicationException("you cannot create engine class twice");


            Viewport = new Viewport();
            Database = new Database();
            Host = new Host();
            Network = new Network();
            Input = new Input();

            s_instance = this;
        }
    }
}
