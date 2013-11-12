using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class FlyingZombie : Character, IFlyingZombie
    {

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            mediator.GetMap(this);

            /*
            if enemy has a character on its vision map
               if character is on the roof
                  PrioritizeAttack
               else if flying zombie is next to character
                  Attack
               else
                  MoveToCharacter
            if zombie has no characters on its vision map
               MoveToCenter
            else
               Hold
             */
        }
    }
}
