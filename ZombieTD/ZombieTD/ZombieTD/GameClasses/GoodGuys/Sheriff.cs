using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Sheriff : Character, ISheriff
    {
        public Sheriff(int x, int y)
            : base(x, y)
        {
            _maxHealth = EngineConstants.Sheriff_Health;
            _health = EngineConstants.Sheriff_Health;
            _attackDamageMelee = EngineConstants.Sheriff_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Sheriff_AttackDamageRanged;
            _attackRange = EngineConstants.Sheriff_AttackRange;
            _defense = EngineConstants.Sheriff_Defense;
            _speed = EngineConstants.Sheriff_Speed;
            _lineOfSite = EngineConstants.Sheriff_LineOfSite;
            _legalMovmentTiles = FilterEnumWithAttributeOf<MapTileType, Sheriff>();

            //Set up a enum of tile types this character can walk on
            _legalMovmentTiles = FilterEnumWithAttributeOf<MapTileType, Sheriff>();
            //Set up an enum of characters this character can attack
            _legalAttackTiles = FilterEnumWithAttributeOf<SpawnType, Sheriff>();
        }

        public Sheriff()
        {

        }

        public override void TakeTurn(IMediator mediator)
        {

            base.TakeTurn(mediator);
           



        }

        public void FireGun(IMediator mediator, ICharacter character, ICharacter target)
        {

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
            base.Attack();

            if (GameMediator.numberofTicks % 60 == 0)
            {
                if (_targetCharacter.GetDeadFlag())
                {
                    _currentAction = CurrentAction.None;
                    _targetCharacter = null;
                    return;
                }
                float distance = Math.Abs(_targetCharacter.GetX() - GetX()) + Math.Abs(_targetCharacter.GetY() - GetY());
                if (distance > _attackRange * 32 || distance < 34)
                {
                    _currentAction = CurrentAction.None;
                    _targetCharacter = null;
                    return;
                }
                ProjectileSheriff p = new ProjectileSheriff(_targetCharacter, _xPos, _yPos, _mediator);
                p.RegisterWithMediator(_mediator, p);
            }
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

            if (GameMediator.numberofTicks % 30 == 0)
            {
                if (IsPlayerNearMe())
                {

                    _currentAction = CurrentAction.Range;
                }
            
                else
                {
                    _currentAction = CurrentAction.None;
                }
            }

        }

        protected override bool IsPlayerNearMe()
        {

            if (_targetCharacter == null)
            {
                foreach (Tile tile in _lineOfSiteMap.Tiles)
                {
                    if (tile.HasCharacters())
                    {
                        foreach (ICharacter character in tile.GetCharactersOnTile())
                        {
                            int distance = Math.Abs(character.GetX() - _xPos) + Math.Abs(character.GetY() - _yPos);
                            if (_legalAttackTiles.Contains(character.getSpawnType())
                                && distance < EngineConstants.Sheriff_AttackRange * 32)
                            {
                                this._targetCharacter = character;
                                _preAttackFace = _directionFacing;
                                return true;
                            }
                        }
                    }
                }

            }
            return false;
        }
    }
}
