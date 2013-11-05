using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZombieTD
{
    public abstract class Character : ICharacter
    {
        protected IMediator _mediator;
        protected ITexture _texture;
        protected Map _lineOfSiteMap;

        public int _health;
        public int _attackDamageMelee;
        public int _attackDamageRanged;
        public int _attackRange;
        public int _defense;
        public int _speed;
        public int _lineOfSite;
        public int _xPos, _yPos;
        public int directionFacing; //0 - 360
        
        public virtual void TakeTurn(IMediator mediator)
        {
            _lineOfSiteMap = mediator.GetMap(this);
        }
        
        public void RegisterWithMediator(IMediator mediator, IGameElement element)
        {
            _mediator = mediator;
            mediator.RegisterWithMediator(mediator, this);    
        }

        public virtual void TakeDamage(int damage)
        {

        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            if(_texture != null)
            spritebatch.Draw(_texture.GetTexture(), new Rectangle(_xPos, _yPos, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight),
                _texture.getViewRec(), Color.White,_texture.getRotation(), Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
