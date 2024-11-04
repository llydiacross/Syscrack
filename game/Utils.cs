using Syscrack;

namespace Game
{
    public static class Utils
    {

        public static Entity CreateEntity(string entityName, string ns = "Game.Entities")
        {

            var t = Type.GetType($"{ns}.{entityName}") ?? throw new ApplicationException("Invalid entity class " + $"Game.Entities.{entityName}");
            var c = Activator.CreateInstance(t) ?? throw new ApplicationException("Invalid entity class");
            return Entity.Register((Entity)c);
        }

        public static Entity CreateEntity(Type t)
        {

            if (!t.IsAssignableTo(typeof(Entity)))
                throw new ApplicationException("Must inherit entity class");

            var c = Activator.CreateInstance(t) ?? throw new ApplicationException("Invalid entity class");
            return Entity.Register((Entity)c);
        }
    }
}