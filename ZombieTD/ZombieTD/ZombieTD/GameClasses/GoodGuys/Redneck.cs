using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Redneck : Character, IRedneck
    {

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does
            mediator.GetMap(this);

            /*
            if character has an enemy on its vision map
               if character is next to a zombie
                   if zombie has an arm
                      CutOffArm
                   else 
                      Attack
               else
                  MoveToEnemy
            else
               Hold
             */
        }

        public void CutOffArm(IMediator mediator, ICharacter charater, ICharacter target)
        {
           
        }
    }
}
