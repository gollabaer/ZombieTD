using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTDEngine
{
    public interface ISheriff
    {
        void FireGun(IMediator mediatror, ICharacter character, ICharacter target);
    }
}
