using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTDEngine
{
    class Zombie : Character, IZombie
    {
        public int _numberOfArms;

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does
           
           
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
