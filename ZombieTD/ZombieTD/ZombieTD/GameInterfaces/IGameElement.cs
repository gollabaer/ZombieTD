using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public interface IGameElement
    {
        void TakeTurn(IMediator mediator);
        void RegisterWithMediator(IMediator mediator, IGameElement element);
        void Draw();
    }
}
