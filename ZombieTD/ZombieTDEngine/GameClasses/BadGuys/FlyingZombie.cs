using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTDEngine
{
    class FlyingZombie : Character, IFlyingZombie
    {
        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);

            //FlyingZombie Logic for turn

        }
    }
}
