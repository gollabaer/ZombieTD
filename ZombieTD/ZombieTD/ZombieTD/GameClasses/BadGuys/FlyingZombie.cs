using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class FlyingZombie : Character, IFlyingZombie
    {
        public bool madeSound = true;

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);

            //FlyingZombie Logic for turn
            if (madeSound)
            {
                mediator.GetAsset<SoundType, ISound>(SoundType.Zombie4).Play();
                madeSound = false;
            }
        }
    }
}
