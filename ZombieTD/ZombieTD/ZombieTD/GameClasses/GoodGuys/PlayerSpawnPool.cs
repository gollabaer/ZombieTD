using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class PlayerSpawnPool : SpawnPoolBase
    {
        public PlayerSpawnPool(IMediator mediator) : base(mediator)
        {
            
        }

        public override void SpawnElements(IMediator mediator)
        {
            if(this._spawnQueue.Count > 0)
                mediator.GetScore().AddTownsfolk();
            base.SpawnElements(mediator);
           
        }
    }
}
