using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class EnemySpawnPool : SpawnPoolBase
    {
        int randomSoundInt = 0;
        Random rnd = new Random();
        public IEnumerable<SoundType> _soundFiles;

        public EnemySpawnPool(IMediator mediator) : base(mediator)
        {
            //Set up a enum of Sounds types this character Make
            _soundFiles = FilterEnumWithAttributeOf<SoundType, EnemySpawnPool>();
        }

        public EnemySpawnPool()
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

            if (GameMediator.numberofTicks % EngineConstants.NumberOfFramsBeforeSound == (ulong)randomSoundInt)
            {
                randomSoundInt = rnd.Next(100, 200);

                int r2 = rnd.Next(_soundFiles.Count<SoundType>());
                ISound sound = _mediator.GetAsset<SoundType, ISound>(_soundFiles.ElementAt(r2));
                sound.Play(.15f, 0f, 0f, false);
            }
               
         }            
    }
}

