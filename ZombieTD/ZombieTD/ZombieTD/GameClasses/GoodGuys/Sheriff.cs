using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Sheriff : Character, ISheriff
    {

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does
            mediator.GetMap(this);

            /*
            if character has an enemy on its vision map
               if the enemy is in the characters ranged attack range
                  FireGun
               if character is next to an enemy
                  Attack
               else
                  MoveToEnemy
            else
               Hold
             */
        }

        public void FireGun(IMediator mediator, ICharacter character, ICharacter target)
        {

        }
    }
}
