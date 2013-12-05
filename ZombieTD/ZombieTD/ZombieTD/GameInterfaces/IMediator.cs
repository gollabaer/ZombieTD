using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace ZombieTD
{



    public interface IMediator: IZombie , IZombieDog, IFlyingZombie, IRedneck, IPriest, ISheriff,  ICar, IHay, IPit, IAssetManager
    {
        void Tick(Tuple<Vector2,SpawnType?> mouseXY);
        void Draw(SpriteBatch spriteBatch);
        Map GetMapByLineOfSight(ICharacter element);
        ICharacter GetCharacter(int x, int y);
        void AcceptOrder(IOrder order, OrderFor orderFor);
        bool LoadContent(ContentManager content, SpriteBatch spriteBatch);
        Tile GetTileByXY(int x, int y);
        Score GetScore();
        int GetTownhallHealth(); 
        void RegisterWithMediator(IMediator mediator, IGameElement element);
        bool AttackTownHall(ICharacter character);
        bool AttackCharacter(ICharacter character, ICharacter target);
        bool AttackCharacter(int damage, ICharacter target);
        void ReportDeath(IGameElement element);
    }
}
