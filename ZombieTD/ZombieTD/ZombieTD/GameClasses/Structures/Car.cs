using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    class Car : Character,  ICar
    {
        ISound fireSound;

        public Car(int x, int y)
            : base(x,y)
        {
            _maxHealth = EngineConstants.Car_Health;
            _health = EngineConstants.Car_Health;
            _attackDamageMelee = EngineConstants.Car_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Car_AttackDamageRanged;
            _attackRange = EngineConstants.Car_AttackRange;
            _defense = EngineConstants.Car_Defense;
            _speed = EngineConstants.Car_Speed;
            _lineOfSite = EngineConstants.Car_LineOfSite;

            //Set up an enum of characters this character can attack
            _legalAttackTiles = FilterEnumWithAttributeOf<SpawnType, Car>();
        }

        public Car()
        {

        }

        public override void Draw(SpriteBatch spritebatch)
        {
            #region animationtests
            if (_texture != null && (GameMediator.numberofTicks % 30 == 0))
                _texture.update();
            #endregion

            int dy = EngineConstants.SmallTextureHeight / 2;
            int dx = EngineConstants.SmallTextureWidth / 2;

            if (_texture != null)
            {
                _texture.setRotation(this._directionFacing);

                spritebatch.Draw(_texture.GetTexture(), new Rectangle(_xPos + dx, _yPos + dy, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight),
                    _texture.getViewRec(), Color.White, _texture.getRotation(), new Vector2(dx, dy), SpriteEffects.None, 0);
            }
        }

        public override void RegisterWithMediator(IMediator mediator, IGameElement element)
        {
            base.RegisterWithMediator(mediator, element);
            fireSound = _mediator.GetAsset<SoundType, ISound>(SoundType.Fire);
        }

        protected override bool IsPlayerNextToMe()
        {
            _targetCharacterList = new List<ICharacter>();
            bool isCharacters = false;

            foreach (Tile tile in _nextToTiles)
            {
                if (tile.HasCharacters())
                {
                    foreach (ICharacter character in tile.GetCharactersOnTile())
                    {
                        if (_legalAttackTiles.Contains(character.getSpawnType()))
                        {
                            this._targetCharacterList.Add(character);
                            isCharacters = true;
                        }
                    }
                }
            }

            return isCharacters;
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
            if (GameMediator.numberofTicks % 60 == 0)
            {
                foreach (ICharacter targetCharacter in _targetCharacterList)
                {
                    _mediator.AttackCharacter(this, targetCharacter);
                }

                _currentAction = CurrentAction.None;
            }
        }

        protected override void ChooseAction()
        {
            if (GameMediator.numberofTicks % 60 == 0)
            {
                fireSound.Play();
                base.ChooseAction();

                if (this.IsPlayerNextToMe())
                {
                    _currentAction = CurrentAction.Attack;
                    fireSound.Play();
                }
            }
        }

        public override bool TakeDamage(int damage)
        {

            this._health -= damage;

            if (this._health <= 0)
            {
                ClearTargets();
                _currentTile.RemoveElement(this);
                _amIDead = true;
                _mediator.ReportDeath(this);
                fireSound.Stop();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
