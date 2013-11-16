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
        void SetTile(Tile tile);
        int GetX();
        int GetY();
        void SetRotation(float rotation);
        ITexture GetTexture();
        void SetDeadFlag();
        bool GetDeadFlag();
    }
}
