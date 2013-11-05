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

        }

        public void CutOffArm(IMediator mediator, ICharacter charater, ICharacter target)
        {
           
        }
    }
}
