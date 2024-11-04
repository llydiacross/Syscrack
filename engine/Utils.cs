using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syscrack
{
    public struct Vector2D {
            public int X {get; set;}
            public int Y {get; set;}

            public Vector2D(int x, int y ) {
                X = x;
                Y = y;
            }
    }

    public struct Rect {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
    
    }
    public static class Utils
    {
     
        public static Entity CreateEntity(string fullName)
        {

            var t = Entity.GetEntityType(fullName);

            if (t == null)
                throw new ApplicationException("tired to create invalid entity " + fullName);

            if (!t.IsAssignableTo(typeof(Entity)))
                throw new ApplicationException("Must inherit entity class");

            var c = Activator.CreateInstance(t) ?? throw new ApplicationException("Invalid entity class");
            return Entity.Create((Entity)c);
        }

        public static Entity CreateEntity(Type t)
        {

            if (!t.IsAssignableTo(typeof(Entity)))
                throw new ApplicationException("Must inherit entity class");

            var c = Activator.CreateInstance(t) ?? throw new ApplicationException("Invalid entity class");
            return Entity.Create((Entity)c);
        }

        public static void RegisterEntity(Type entity)
        {

#if DEBUG
            Console.WriteLine("Registering Entity " + entity.FullName);
#endif
            Entity.Register(entity);
        }

        public static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public static string FriendlyName()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "MacOS/Linux";
        }
    }
}
