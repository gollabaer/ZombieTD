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
        public ITexture _texture; //Change tto protected
        protected Map _lineOfSiteMap;

        public int _health;
        public int _attackDamageMelee;
        public int _attackDamageRanged;
        public int _attackRange;
        public int _defense;
        public int _speed;
        public int _lineOfSite;
        public FaceDirection directionFacing;

        public int _xPos, _yPos;
        public int directionFacing; //0 - 360
        protected int timer = 0;

        protected Character()
        {

        }

        public virtual void TakeTurn(IMediator mediator)
        {
            _lineOfSiteMap = mediator.GetMap(this);

            #region animationtests
            if (_texture != null && (GameMediator.numberofTicks % 10 == 0))
                _texture.update();

            #endregion

            timer++;
        }

        public int getLineOfSight()
        {
            return _lineOfSite;
        }

        public int GetX()
        {
            return this._xPos;
        }

        public int GetY()
        {
            return this._yPos;
        }

    
        public void move(MoveDirection direction) {
            if (timer > _speed)
            {
                switch (direction)
                {
                    case MoveDirection.Down:
                        _yPos++;
                        break;
                    case MoveDirection.Up:
                        _yPos--;
                        break;
                    case MoveDirection.Left:
                        _xPos--;
                        break;
                    case MoveDirection.Right:
                        _xPos++;
                        break;
                    default: break;
                }
                timer = 0;
            }
        }

        public static float DirectionEnumToPiValue(FaceDirection direction)
        {
            
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
            int dy = EngineConstants.SmallTextureHeight / 2;
            int dx = EngineConstants.SmallTextureWidth / 2;

            if (_texture != null)
                spritebatch.Draw(_texture.GetTexture(), new Rectangle(_xPos + dx, _yPos + dy, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight),
                    _texture.getViewRec(), Color.White, _texture.getRotation(), new Vector2(dx, dy), SpriteEffects.None, 0);
        }
    }
}
