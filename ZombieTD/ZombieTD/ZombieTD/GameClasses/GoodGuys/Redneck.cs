using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Redneck : Character, IRedneck
    {
        bool madeSound = true;

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does

            if (madeSound)
            {
                mediator.GetAsset<SoundType, ISound>(SoundType.Chainsaw).Play();
                madeSound = false;
            }

        }

        public void CutOffArm(IMediator mediator, ICharacter charater, ICharacter target)
        {
           
        }
    }
}
