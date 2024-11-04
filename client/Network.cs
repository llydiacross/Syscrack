using Syscrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Network
    {

        public void ReceiveCreateEntity(Entity entity)
        {

            Entity.Register(entity);
        }
    }
}
