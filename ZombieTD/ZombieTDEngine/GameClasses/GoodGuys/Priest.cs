using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTDEngine
{
    public class Priest : Character, IPriest
    {
        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does
        }

        public void ThrowHolyWater(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }
    }
}
