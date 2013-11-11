using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class EnemySpawnPool : SpawnPoolBase
    {
        public EnemySpawnPool(IMediator mediator) : base(mediator)
        {

        }

        public override void SpawnElements(IMediator mediator)
        {
            if (this._spawnQueue.Count > 0)
                mediator.GetScore().AddEnemy();
            base.SpawnElements(mediator);
            
        }
    }
}
