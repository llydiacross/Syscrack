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
        public object? MainClass { get; set; }

        public Game(string gameDll)
        {

            var mod = Assembly.LoadFrom(gameDll) ?? throw new ApplicationException("invalid assembly");
            var assemblyMetadata = new AssemblyMetadata
            {
                Name = mod.FullName ?? mod.GetName().Name ?? "Unknown",
                Description = $"{mod.FullName} ({mod.Location})",
                Version = mod.GetName()?.Version?.ToString() ?? "0.0",
            };

            Console.WriteLine("Loaded DLL " + mod.ToString());
            Metadata = assemblyMetadata;
            Assembly = mod;
        }

        public void Invoke(string method, object[]? args, string mainClass = "Game.Game")
        {

            // check that the assembly is valid by creating an instance of the Game class                                                                  
            MainClass = MainClass ?? Assembly.CreateInstance(mainClass) ?? throw new ApplicationException("no class called Game in assembly");

            var type = MainClass.GetType();
            var func = type.GetMethod(method);

            if (func == null)
                throw new ApplicationException($"{type.Name} does not exist");

            _ = func.Invoke(MainClass, args);
        }
    }
}
