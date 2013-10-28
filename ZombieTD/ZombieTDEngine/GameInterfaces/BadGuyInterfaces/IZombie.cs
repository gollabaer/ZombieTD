using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTDEngine
{
    public interface IZombie
    {
        void ThrowArm(IMediator mediator, ICharacter character, ICharacter target);
        void RaiseSoul(IMediator mediator, ICharacter character, ICharacter target);
    }
}
