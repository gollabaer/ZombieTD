using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public interface IZombieDog
    {
        void SpitAcid(IMediator mediator, ICharacter character, ICharacter target);
    }
}
