using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    class Hay : Character, IHay
    {
        public Hay(int x, int y)
            : base(x,y)
        {
            _maxHealth = EngineConstants.Hay_Health;
            _health = EngineConstants.Hay_Health;
            _attackDamageMelee = EngineConstants.Hay_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Hay_AttackDamageRanged;
            _attackRange = EngineConstants.Hay_AttackRange;
            _defense = EngineConstants.Hay_Defense;
            _speed = EngineConstants.Hay_Speed;
            _lineOfSite = EngineConstants.Hay_LineOfSite;
        }

        public override void TakeTurn(IMediator mediator)
        {
            //I am hay, I do nothing
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            int dy = EngineConstants.SmallTextureHeight / 2;
            int dx = EngineConstants.SmallTextureWidth / 2;

            if (_texture != null)
            {
                _texture.setRotation(this._directionFacing);

                spritebatch.Draw(_texture.GetTexture(), new Rectangle(_xPos + dx, _yPos + dy, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight),
                    _texture.getViewRec(), Color.White, _texture.getRotation(), new Vector2(dx, dy), SpriteEffects.None, 0);
            }
        }

        protected override void Special3()
        {
            throw new NotImplementedException();
        }

        protected override void Special2()
        {
            throw new NotImplementedException();
        }

        protected override void Special1()
        {
            throw new NotImplementedException();
        }

        protected override void RangeAttack()
        {
            throw new NotImplementedException();
        }

        protected override void Move()
        {
            throw new NotImplementedException();
        }

        protected override void Attack()
        {
            throw new NotImplementedException();
        }

        protected override void ChooseAction()
        {
            base.ChooseAction();
        }
    }
}
