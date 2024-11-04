using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Syscrack
{
    public struct AssemblyMetadata
    {

        public string Name;
        public string Description;
        public string Version { get; set; }
    }
    public class Game
    {

        public AssemblyMetadata Metadata { get; set; }
        public Assembly Assembly { get; set; }

        public Game(string gameDll)
        {

            var mod = Assembly.LoadFrom(gameDll) ?? throw new ApplicationException("invalid assembly");
            var assemblyMetadata = new AssemblyMetadata
            {
                Name = mod.FullName ?? mod.GetName().Name ?? "Unknown",
                Description = mod.Location,
                Version = mod.GetName()?.Version?.ToString() ?? "0.0",
            };

            Console.WriteLine("Loaded DLL " + mod.ToString());
            Metadata = assemblyMetadata;
            Assembly = mod;
        }

        public void Init()
        {

            // check that the assembly is valid by creating an instance of the Game class                                                                  
            var game = Assembly.CreateInstance("Game.Game") ?? throw new ApplicationException("no class called Game in assembly");

            var type = game.GetType();
            var method = type.GetMethod("Init");

            if (method == null)
                throw new ApplicationException($"{type.Name} does not exist");

            _ = method.Invoke(game, []);
        }
    }
}
