using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTDEngine
{



    public interface IMediator: IGameElement,IZombie, IZombieDog, IFlyingZombie, IRedneck, IPriest, ISheriff
    {
        void Tick();
        void DrawElements();
        Map GetMap(ICharacter element);
        ICharacter GetCharacter(int x, int y);
    }
}
