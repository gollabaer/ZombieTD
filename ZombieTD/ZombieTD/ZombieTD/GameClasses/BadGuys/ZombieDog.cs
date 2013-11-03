﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class ZombieDog : Character, IZombieDog
    {
        public bool madeSound = true;

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does

              
            if (madeSound)
            {
                mediator.GetAsset<SoundType, ISound>(SoundType.Zombie2).Play();
                madeSound = false;
            }
        }

        public void SpitAcid(IMediator mediator, ICharacter character, ICharacter target)
        {
            mediator.SpitAcid(mediator, this, target);
        }
    }
}
