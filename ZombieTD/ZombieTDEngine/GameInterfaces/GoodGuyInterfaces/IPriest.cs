﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTDEngine
{
    public interface IPriest
    {
        void ThrowHolyWater(IMediator mediator, ICharacter character, ICharacter target);
    }
}
