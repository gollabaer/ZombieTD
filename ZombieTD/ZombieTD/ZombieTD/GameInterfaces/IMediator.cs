using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{



    public interface IMediator: IZombie , IZombieDog, IFlyingZombie, IRedneck, IPriest, ISheriff, IBase, ICar, IHay, IPit, IProjectile, IAssetManager
    {
        void Tick();
        Map GetMap(ICharacter element);
        ICharacter GetCharacter(int x, int y);
        bool LoadContent(ContentManager content, SpriteBatch spriteBatch);
    }
}
