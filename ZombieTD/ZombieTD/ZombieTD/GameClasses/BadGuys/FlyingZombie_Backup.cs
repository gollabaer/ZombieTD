using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class FlyingZombie : Character, IFlyingZombie
    {
        public FlyingZombie(int x, int y)
            : base(x,y)
        {
            _maxHealth = EngineConstants.FlyingZombie_Health;
            _health = EngineConstants.FlyingZombie_Health;
            _attackDamageMelee = EngineConstants.FlyingZombie_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.FlyingZombie_AttackDamageRanged;
            _attackRange = EngineConstants.FlyingZombie_AttackRange;
            _defense = EngineConstants.FlyingZombie_Defense;
            _speed = EngineConstants.FlyingZombie_Speed;
            _lineOfSite = EngineConstants.FlyingZombie_LineOfSite;

            //Set up a enum of tile types this character can walk on
            _legalMovmentTiles = FilterEnumWithAttributeOf<MapTileType, FlyingZombie>();

            //Set up an enum of characters this character can attack
            _legalAttackTiles = FilterEnumWithAttributeOf<SpawnType, FlyingZombie>();

        }

        public FlyingZombie()
        {

        }

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //mediator.GetMap(this);

            /*
            if enemy has a character on its vision map
               if character is on the roof
                  PrioritizeAttack
               else if flying zombie is next to character
                  Attack
               else
                  MoveToCharacter
            if zombie has no characters on its vision map
               MoveToCenter
            else
               Hold
             */
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
            if (_movingDirection == MoveDirection.None)
            {
                Tile workingTile;

                if (_directionFacing == EngineConstants.Up)
                {
                    workingTile = _lineOfSiteMap.GetTileByXY(_currentTile.Xpos, _currentTile.Ypos - 32);

                    if (workingTile != null && this._previousTile != workingTile && _legalMovmentTiles.Contains(workingTile.TextureType))
                    {
                        _movingDirection = MoveDirection.Up;
                        this._directionFacing = EngineConstants.Up;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }
                    else
                    {
                        _directionFacing = EngineConstants.Right;
                    }
                }

                if (_directionFacing == EngineConstants.Right)
                {
                    workingTile = _lineOfSiteMap.GetTileByXY(_currentTile.Xpos + 32, _currentTile.Ypos);

                    if (workingTile != null && this._previousTile != workingTile && _legalMovmentTiles.Contains(workingTile.TextureType))
                    {
                        _movingDirection = MoveDirection.Right;
                        this._directionFacing = EngineConstants.Right;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }
                    else
                    {
                        _directionFacing = EngineConstants.Down;
                    }
                }

                if (_directionFacing == EngineConstants.Down)
                {
                    workingTile = _lineOfSiteMap.GetTileByXY(_currentTile.Xpos, _currentTile.Ypos + 32);

                    if (workingTile != null && this._previousTile != workingTile && _legalMovmentTiles.Contains(workingTile.TextureType))
                    {
                        _movingDirection = MoveDirection.Down;
                        this._directionFacing = EngineConstants.Down;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }
                    else
                    {
                        _directionFacing = EngineConstants.Left;
                    }
                }

                if (_directionFacing == EngineConstants.Left)
                {
                    workingTile = _lineOfSiteMap.GetTileByXY(_currentTile.Xpos - 32, _currentTile.Ypos);

                    if (workingTile != null && this._previousTile != workingTile && _legalMovmentTiles.Contains(workingTile.TextureType))
                    {
                        _movingDirection = MoveDirection.Left;
                        this._directionFacing = EngineConstants.Left;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }
                    else
                    {
                        this._currentAction = CurrentAction.None;
                        //this._previousTile = _currentTile;
                        _directionFacing = EngineConstants.Up;
                    }
                }

            }
            else //Character is in the move phase
            {
                if (GameMediator.numberofTicks % EngineConstants.FlyingZombie_NumberOfFramesBeforeMove == 0)
                {
                    if (_moveCounter != 32)
                    {
                        switch (_movingDirection)
                        {
                            case MoveDirection.Up: this._yPos -= EngineConstants.FlyingZombie_Speed; break;
                            case MoveDirection.Right: this._xPos += EngineConstants.FlyingZombie_Speed; break;
                            case MoveDirection.Down: this._yPos += EngineConstants.FlyingZombie_Speed; break;
                            case MoveDirection.Left: this._xPos -= EngineConstants.FlyingZombie_Speed; break;
                        }

                        _moveCounter = _moveCounter + EngineConstants.FlyingZombie_Speed;
                    }
                    else
                    {
                        this._currentAction = CurrentAction.None;
                        this._movingDirection = MoveDirection.None;
                        _moveCounter = 0;
                    }

                }

            }
        }

        protected override void Attack()
        {
            base.Attack();

            if (GameMediator.numberofTicks % EngineConstants.FlyingZombie_NumberOfFramesBeforeAttack == 0)
            {
                bool targetDestroyed = false;

                if (_targetCharacter != null)
                {
                    if (_targetCharacter.GetTile().Equals("Building_roof_center") || _targetCharacter.GetTile().Equals("Building_roof_corner") || _targetCharacter.GetTile().Equals("Building_Roof_Side"))
                    {
                        targetDestroyed = _mediator.AttackCharacter(this, _targetCharacter);
                    }
                }

                if (targetDestroyed)
                {
                    _currentAction = CurrentAction.None;
                    _targetCharacter = null;
                    _targetTile = null;
                    _directionFacing = _preAttackFace;
                }
            }
        }

        protected override void ChooseAction()
        {
            base.ChooseAction();

            if (IsPlayerNextToMe() && (_targetCharacter.GetTile().Equals("Building_roof_center") || _targetCharacter.GetTile().Equals("Building_roof_corner") || _targetCharacter.GetTile().Equals("Building_Roof_Side")))
            {
                _currentAction = CurrentAction.Attack;
            }
            else
            {
                _currentAction = CurrentAction.Move;
            }
        }
    }
}
