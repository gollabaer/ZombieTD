using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class ZombieDog : Character, IZombieDog
    {

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does
            mediator.GetMap(this);

            /*
            if enemy has a character on its vision map
               if character hasnt been hit by acid
                  SpitAcid
               if dog is next to a character
                  Attack
               else
                  MoveToCharacter
            if zombie has no characters on its vision map
               MoveToCenter
            else
               Hold
             */
        }

        public void SpitAcid(IMediator mediator, ICharacter character, ICharacter target)
        {
            mediator.SpitAcid(mediator, this, target);
        }
    }
}
