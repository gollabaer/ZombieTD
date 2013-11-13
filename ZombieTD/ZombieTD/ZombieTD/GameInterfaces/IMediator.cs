using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{



    public interface IMediator: IZombie , IZombieDog, IFlyingZombie, IRedneck, IPriest, ISheriff,  ICar, IHay, IPit, IProjectile, IAssetManager
    {
        void Tick();
        Map GetMap(ICharacter element);
        ICharacter GetCharacter(int x, int y);
        void AcceptOrder(IOrder order, OrderFor orderFor);
        bool LoadContent(ContentManager content, SpriteBatch spriteBatch);
        Tile GetTileByXY(int x, int y);
        Score GetScore();
        int GetTownhallHealth();
       
    }
}
