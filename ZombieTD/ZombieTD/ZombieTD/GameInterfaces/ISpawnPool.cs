using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public interface ISpawnPool
    {
        void AcceptOrder(IOrder order);
        void SpawnElements(IMediator mediator);
        void ProcessOrder();
        void ClearQueues();
    }
}
