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

        }
    }
}
