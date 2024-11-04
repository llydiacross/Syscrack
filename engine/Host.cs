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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool IsActive { get; set; }
        public Host()
        {

            this.IsActive = false;
        }

        public void Start(string gameDll, string mainClass = "Game.Game")
        {

            this.Game = new Game(gameDll);
            this.Name = this.Game.Metadata.Name;
            this.Version = this.Game.Metadata.Version;
            this.Description = this.Game.Metadata.Description;

            try
            {
                Console.WriteLine("[Intializing] " + this.Description);
                this.Game.Invoke("Init", [], mainClass);
                this.IsActive = true;
            }
            catch (Exception ex)
            {

                Console.Error.WriteLine("[FAILED! TO INIT] " + this.Name);
                Console.Error.WriteLine(ex.ToString());
                this.IsActive = false;
            }
        }
    }
}
