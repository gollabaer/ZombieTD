using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Priest : Character, IPriest
    {
        private Tile _TargetTile;

        public Priest() { }

        public Priest(int x, int y)
            : base(x,y)
        {
            _health = EngineConstants.Priest_Health;
            _attackDamageMelee = EngineConstants.Priest_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Priest_AttackDamageRanged;
            _attackRange = EngineConstants.Priest_AttackRange;
            _defense = EngineConstants.Priest_Defense;
            _speed = EngineConstants.Priest_Speed;
            _lineOfSite = EngineConstants.Priest_LineOfSite;
            _legalMovmentTiles = FilterEnumWithAttributeOf<MapTileType, Priest>();
            _legalAttackTiles = FilterEnumWithAttributeOf<SpawnType, Priest>();
        }

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);

            if (IsPlayerNextToMe() && _currentTile.TextureType == MapTileType.Building_roof_center) Attack();
            else if (IsPlayerNearMe())
                RangeAttack();
            else if (isPlayerInRange()) Move();
            else {
                _TargetTile = null;
                Move();
            }// and set direction towards startpoint
        }

        public void ThrowHolyWater(IMediator mediator, ICharacter charater, ICharacter target)
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
            //TODO Spawn projectile
            if(GameMediator.numberofTicks % 50 == 0)
            if (_mediator.AttackCharacter(this, _targetCharacter))
            {
                _currentAction = CurrentAction.None;
                _targetCharacter = null;
            }
        }

        protected override void Move()
        {
            if (_targetTile == null)
            {

            }
            else { 
            
            }
        }

        protected override void Attack()
        {
            // add timer 
            _mediator.AttackCharacter(this, _targetCharacter);
        }

        protected override void ChooseAction()
        {
            base.ChooseAction();
        }


        protected override bool IsPlayerNearMe()
        {
            foreach (Tile tile in _lineOfSiteMap.Tiles)
            {
                if (tile.HasCharacters())
                {
                    foreach (ICharacter character in tile.GetCharactersOnTile())
                    {
                        if (_legalAttackTiles.Contains(character.getSpawnType()))
                        {
                            if ((Math.Abs(GetX() - character.GetX()) + Math.Abs(GetY() - character.GetY())) < _attackRange)
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

      

        private bool isPlayerInRange() {
            foreach (Tile tile in _lineOfSiteMap.Tiles)
            {
                if (tile.HasCharacters())
                {
                    foreach (ICharacter character in tile.GetCharactersOnTile())
                    {
                        if (_legalAttackTiles.Contains(character.getSpawnType()))
                        {
                            if ((Math.Abs(GetX() - character.GetX()) + Math.Abs(GetY() - character.GetY()) + _movmentRange) < _attackRange)
                            {
                                this._TargetTile = character.GetTile();
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
