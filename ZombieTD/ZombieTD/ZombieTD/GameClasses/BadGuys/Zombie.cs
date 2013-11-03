using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class Zombie : Character, IZombie
    {
        public int _numberOfArms;
        public bool madeSound = true;
        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does


           
            if (madeSound)
            {
                mediator.GetAsset<SoundType, ISound>(SoundType.Zombie1).Play();
                madeSound = false;
            }
           
            this.ThrowArm(mediator, this, mediator.GetCharacter(0,0));
            this.RaiseSoul(mediator, this, mediator.GetCharacter(0, 0));

        }
       
        public void ThrowArm(IMediator mediator, ICharacter character, ICharacter target)
        {
            mediator.ThrowArm(mediator, this, target);
        }

        public void RaiseSoul(IMediator mediator, ICharacter character, ICharacter target)
        {
            mediator.RaiseSoul(mediator, character, target);
        }
    }
}
