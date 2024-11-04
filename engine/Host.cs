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

        public Game Server { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool IsActive { get; set; }
        public Host()
        {

            this.IsActive = false;
        }

        public void Start(string gameDll)
        {

            this.Server = new Game(gameDll);
            this.Name = this.Server.Metadata.Name;
            this.Version = this.Server.Metadata.Version;
            this.Description = this.Server.Metadata.Description + " running on " + Utils.FriendlyName();

            try
            {
                Console.WriteLine("[STARTING] " + this.Description);
                this.Server.Init();
                this.IsActive = true;
            }
            catch (Exception ex)
            {

                Console.Error.WriteLine("[FAILED! TO START] " + this.Name);
                Console.Error.WriteLine(ex.ToString());
                this.IsActive = false;
            }
        }
    }
}
