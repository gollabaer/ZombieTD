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
            if (_spawnQueue.Count != 0)
            {
                Tile tile = mediator.GetTileByXY(_spawnQueue.Peek().GetX(), _spawnQueue.Peek().GetY());

                if (!tile.HasCharacters())
                {
                    IGameElement spawn = _spawnQueue.Dequeue();
                    mediator.GetScore().AddEnemy();
                    spawn.RegisterWithMediator(mediator, spawn);
                }
            }            
        }
    }
}
