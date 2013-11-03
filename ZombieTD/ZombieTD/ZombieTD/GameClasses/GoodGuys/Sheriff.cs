using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Sheriff : Character, ISheriff
    {
        bool madeSound = true;

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does

            if (madeSound)
            {
                mediator.GetAsset<SoundType, ISound>(SoundType.Gunshot).Play();
                madeSound = false;
            }

        }

        public void FireGun(IMediator mediator, ICharacter character, ICharacter target)
        {

        }
    }
}
