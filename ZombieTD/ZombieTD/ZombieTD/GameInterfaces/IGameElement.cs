using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;


namespace ZombieTD
{
    public interface IGameElement
    {
        void TakeTurn(IMediator mediator);
        void RegisterWithMediator(IMediator mediator, IGameElement element);
        void Draw(SpriteBatch spritebatch);
        int GetX();
        int GetY();
    }
}
