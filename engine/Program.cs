namespace Syscrack
{
    internal class Program
    {

        public List<Host> Hosts = new List<Host>();

        static void Main(string[] args)
        {

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
                Console.WriteLine("Sorry! For some unexplained reason. A criticual server instance has failed to start. Please check if any mods are installed, and try again");
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
                client.Start("client.dll"); // load the main game dll
            }
        }
    }

    public class Engine
    {

        public Host Host;
        public Database Database;
        public Draw Draw;
        public Network Network;

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


            Draw = new Draw();
            Database = new Database();
            Host = new Host();
            Network = new Network();

            s_instance = this;
        }
    }
}
