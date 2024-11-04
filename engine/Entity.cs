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

        private static readonly Entity[] Entities = new Entity[2048];

        public static Entity Register(Entity entity)
        {

            if (Entities[entity.Id] != null)
                throw new ApplicationException("Entity already alive with that Id");

            Entities[entity.Id] = entity;

#if DEBUG
            Console.WriteLine("Created Entity => " + entity.GetType().FullName + " id:" + entity.Id);
#endif

            if (Engine.s_instance.IsServer)
            {
                // Send this to all the clients
                Engine.s_instance.Network.SendEntityToClient(0, entity);
            }

            return Entities[entity.Id];
        }

        public static Entity GetEntity(int id)
        {

            return Entities.First((a) => a.Id == id);
        }

        public static Entity GetFirstEntityByClassName(string className)
        {
            return Entities.First((a) => a.GetType().Name == className);
        }

        public static Entity GetEntityAtIndex(int index)
        {

            return Entities[index];
        }

        public int Id { get; set; }

        public Entity()
        {
            Id = Entities.Where((a) => a != null).Count();
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
