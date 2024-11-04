using Syscrack;

namespace Game
{
    public static class Utils
    {

        public static Entity CreateEntity(string entityName)
        {

            var t = Type.GetType($"Game.Entities.{entityName}") ?? throw new ApplicationException("Invalid entity class " + $"Game.Entities.{entityName}");
            var c = Activator.CreateInstance(t) ?? throw new ApplicationException("Invalid entity class");
            return Entity.Register((Entity)c);
        }
    }
}