using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syscrack
{

    // Entities are computers
    public class Entity
    {


        private static readonly Dictionary<string, Type> s_entityTable = [];
        private static readonly Entity[] s_entities = new Entity[4096];


        public static void Register(Type entity)
        {

            if (!entity.IsAssignableTo(typeof(Entity)))
                throw new ApplicationException("must inheret Entity class");

            s_entityTable.Add(entity.FullName ?? entity.Name, entity);
        }

        public static Type GetEntityType(string FullName)
        {
            return s_entityTable[FullName];
        }

        public static Type GetEntityType(Entity entity)
        {
            return s_entityTable[entity.GetType()?.FullName ?? entity.GetType().Name];
        }

        public static Entity Create(Entity entity)
        {

            if (s_entityTable[entity.GetType().FullName ?? entity.GetType().Name] == null)
                throw new ApplicationException("tired to create unregistered Entity type");

            if (s_entities[entity.Id] != null)
                throw new ApplicationException("Entity already alive with that Id");

            s_entities[entity.Id] = entity;

#if DEBUG
            Console.WriteLine("Created Entity => " + entity.GetType().FullName + " id:" + entity.Id);
#endif

            if (Engine.s_instance.IsServer)
            {
                // Send this to all the clients
                Engine.s_instance.Network.SendEntityToClient(0, entity);
            }

            return s_entities[entity.Id];
        }

        public static Entity GetEntity(int id)
        {

            return s_entities.First((a) => a.Id == id);
        }

        public static Entity GetFirstEntityByClassName(string className)
        {
            return s_entities.First((a) => a.GetType().Name == className);
        }

        public static Entity GetEntityAtIndex(int index)
        {

            return s_entities[index];
        }

        public int Id { get; set; }
        public bool Alive { get; set; }

        public Entity()
        {
            Id = s_entities.Where((a) => a != null).Count();
            Alive = false;
        }

        public void Create()
        {

            Alive = true;
            this.OnSpawn();
        }

        public virtual void OnSpawn()
        {

        }

        public virtual void OnCollision()
        {

        }

        public virtual void OnTouch()
        {

        }

        public virtual void OnUse()
        {

        }

        public virtual void OnKilled()
        {

        }
    }
}
