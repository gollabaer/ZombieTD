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
                  
                    IGameElement element = _spawnQueue.Dequeue();

                    Tile tile = mediator.GetTileByXY(element.GetX(),element.GetY());

                    if (!tile.HasCharacters())
                    {

                        mediator.GetScore().AddEnemy();
                        element.RegisterWithMediator(mediator, element);
                       
                    }
                    else
                    {
                        _spawnQueue.Enqueue(element);
                    }
                }
               
            }            
        }
    }

