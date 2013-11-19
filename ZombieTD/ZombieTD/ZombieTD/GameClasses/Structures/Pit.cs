using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    public class Pit : Character, IPit
    {
        public Pit(int x, int y)
            : base(x,y)
        {
            _health = EngineConstants.Pit_Health;
            _attackDamageMelee = EngineConstants.Pit_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Pit_AttackDamageRanged;
            _attackRange = EngineConstants.Pit_AttackRange;
            _defense = EngineConstants.Pit_Defense;
            _speed = EngineConstants.Pit_Speed;
            _lineOfSite = EngineConstants.Pit_LineOfSite;
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
