﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    public class Projectile : Character, IProjectile
    {
        Vector2 _movingDirectionVec;
        float _traveleddistance;

        public Projectile(ICharacter 
            target, int x, int y, IMediator mediator)
            :base(x,y)
        {
            _traveleddistance = 0;
            _mediator = mediator;
            _health = 1;
            _xPos = x;
            _yPos = y;
            _speed = 2;
            _movingDirectionVec = new Vector2(target.GetX() - _xPos, target.GetY() - _yPos);
            _movingDirectionVec.Normalize();
            _movingDirectionVec *= 2.0f;
            _movingDirectionVec.X = (int)Math.Round(_movingDirectionVec.X);
            _movingDirectionVec.Y = (int)Math.Round(_movingDirectionVec.Y);
            _currentAction = CurrentAction.None;
            _attackDamageMelee = 20;
            _attackDamageRanged = 10;
            _spawnType = SpawnType.Projectile;
            //Set up a enum of tile types this character can walk on
            _legalMovmentTiles = FilterEnumWithAttributeOf<MapTileType, Projectile>();
            //Set up an enum of characters this character can attack
            _legalAttackTiles = FilterEnumWithAttributeOf<SpawnType, Projectile>();
        }

        public Projectile() { }

        public override void TakeTurn(IMediator mediator)
        {
            if (_currentAction == CurrentAction.None) {
                ChooseAction();
            }

            if (_currentAction == CurrentAction.Move) {
                Move();
            }

            if (_currentAction == CurrentAction.Attack) {
                Attack();
            }
                
        }


        public override void RegisterWithMediator(IMediator mediator, IGameElement element)
        {
            _mediator = mediator;
            _texture = mediator.GetAsset<CharacterTextureType, ITexture>(CharacterTextureType.Projectile1);
            _mediator.RegisterWithMediator(mediator, this);

            float alph = (float)Math.Atan2(_movingDirectionVec.Y,_movingDirectionVec.X) + (float)Math.PI / 2.0f;
            _texture.setRotation(alph);
        }

        public void  Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);

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
            if (GameMediator.numberofTicks % 1 == 0)
            {
                _xPos += (int)_movingDirectionVec.X;
                _yPos += (int)_movingDirectionVec.Y;
                _currentAction = CurrentAction.None;

                _traveleddistance += Math.Abs((int)_movingDirectionVec.X) + Math.Abs((int)_movingDirectionVec.Y);

                if (_traveleddistance > 100)
                {
                    TakeDamage(_health);
                }
                _currentAction = CurrentAction.None;
            }
        }

        protected override void Attack()
        {
            _mediator.AttackCharacter(this, _targetCharacter);
            this.TakeDamage(_health);
        }

        protected override void ChooseAction()
        {
            base.ChooseAction();
            if (IsPlayerNextToMe())
                _currentAction = CurrentAction.Attack;
            else
                _currentAction = CurrentAction.Move;
        }
    }
}
