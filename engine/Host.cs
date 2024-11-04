using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Syscrack
{
    public class Host
    {

        public Game Game { get; set; }
        public bool IsActive { get; set; }

        public Host()
        {

            this.IsActive = false;
        }

        public void Start(string gameDll, string mainClass = "Game.Game")
        {

            this.Game = new Game(gameDll);

            try
            {
                Console.WriteLine("[Intializing] " + this.Game.Metadata.Description);
                this.Game.Invoke("Init", [], mainClass);
                this.IsActive = true;
            }
            catch (Exception ex)
            {

                Console.Error.WriteLine("[FAILED! TO INIT] " + this.Game.Metadata.Name);
                Console.Error.WriteLine(ex.ToString());
                this.IsActive = false;
            }
        }
    }
}
