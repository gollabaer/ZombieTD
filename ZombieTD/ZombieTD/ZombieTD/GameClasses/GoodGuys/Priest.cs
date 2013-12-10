using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace ZombieTD
{
    public class Priest : Character, IPriest
    {
        protected Vector2 _targetPosition;
        protected Vector2 _startPositionVector;

        public Priest() { }

        public Priest(int x, int y)
            : base(x,y)
        {
            _startPositionVector = new Vector2(x, y);
            _health = EngineConstants.Priest_Health;
            _attackDamageMelee = EngineConstants.Priest_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Priest_AttackDamageRanged;
            _attackRange = EngineConstants.Priest_AttackRange;
            _defense = EngineConstants.Priest_Defense;
            _speed = EngineConstants.Priest_Speed;
            _lineOfSite = EngineConstants.Priest_LineOfSite;
            _movmentRange = 70;

            //Set up a enum of tile types this character can walk on
            _legalMovmentTiles = FilterEnumWithAttributeOf<MapTileType, Priest>();
            //Set up an enum of characters this character can attack
            _legalAttackTiles = FilterEnumWithAttributeOf<SpawnType, Priest>();
        }

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            

        
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
                if (distance > _attackRange * 32 || distance <34 )
                {
                    _currentAction = CurrentAction.None;
                    _targetCharacter = null;
                    return;
                }
                Projectile p = new Projectile(_targetCharacter, _xPos, _yPos, _mediator);
                p.RegisterWithMediator(_mediator, p);
            }
           
        }

        protected override void Move()
        {
            if (_movingDirection == MoveDirection.None)
            {
                Tile workingTile = _lineOfSiteMap.GetTileByXY(this._xPos+32, this._yPos);

                if (this._xPos < _targetPosition.X 
                    && workingTile != null
                    &&_legalMovmentTiles.Contains( workingTile.TextureType)
                    && this._previousTile != workingTile)
                    {
                        _movingDirection = MoveDirection.Right;
                        this._directionFacing = EngineConstants.Right;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }

                workingTile = _lineOfSiteMap.GetTileByXY(this._xPos-32, this._yPos);
                if (this._xPos > _targetPosition.X 
                    && workingTile != null
                    &&_legalMovmentTiles.Contains( workingTile.TextureType)
                    && this._previousTile != workingTile)
                    {
                        _movingDirection = MoveDirection.Left;
                        this._directionFacing = EngineConstants.Left;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }

                workingTile = _lineOfSiteMap.GetTileByXY(this._xPos, this._yPos-32);
                if (this._yPos > _targetPosition.Y
                    && workingTile != null
                    &&_legalMovmentTiles.Contains( workingTile.TextureType)
                    && this._previousTile != workingTile)
                    {
                        _movingDirection = MoveDirection.Up;
                        this._directionFacing = EngineConstants.Up;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }

                workingTile = _lineOfSiteMap.GetTileByXY(this._xPos, this._yPos+32);
                if (this._yPos < _targetPosition.Y 
                    && workingTile != null
                    &&_legalMovmentTiles.Contains( workingTile.TextureType)
                    && this._previousTile != workingTile)
                    {
                        _movingDirection = MoveDirection.Down;
                        this._directionFacing = EngineConstants.Down;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }


                _currentAction = CurrentAction.None;
               
            }
            else //Character is in the move phase
            {
                if (GameMediator.numberofTicks % EngineConstants.Priest_NumberOfFramesBeforeMove == 0)
                {
                    if (_moveCounter != 32)
                    {
                        switch (_movingDirection)
                        {
                            case MoveDirection.Up: this._yPos -= EngineConstants.Priest_Speed; break;
                            case MoveDirection.Right: this._xPos += EngineConstants.Priest_Speed; break;
                            case MoveDirection.Down: this._yPos += EngineConstants.Priest_Speed; break;
                            case MoveDirection.Left: this._xPos -= EngineConstants.Priest_Speed; break;
                        }

                        _moveCounter = _moveCounter + EngineConstants.Priest_Speed;
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

            if (GameMediator.numberofTicks % 60 == 0)
            {
                bool targetDestroyed = false;

                
                if (_targetCharacter != null)
                {
                    targetDestroyed = _mediator.AttackCharacter(this, _targetCharacter);
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

            if (GameMediator.numberofTicks % 10 == 0)
            {
                if (IsPlayerNextToMe())
                {
                    _currentAction = CurrentAction.Attack;
                }

                else if (IsPlayerNearMe())
                {

                   _currentAction = CurrentAction.Range;
                }
                else if (isPlayerInrange())
                {
                    _currentAction = CurrentAction.Move;
                }
                else
                {
                    if (this._xPos != _startPositionVector.X || this._startPositionVector.Y != this._yPos)
                    {
                        _targetPosition = _startPositionVector;
                        _currentAction = CurrentAction.Move;

                    }
                    else
                    {
                        _texture.setFrame(0);
                    }
                }
            }
        }

        protected bool isPlayerInrange() {
            if (_targetCharacter == null)
            {
                foreach (Tile tile in _lineOfSiteMap.Tiles)
                {
                    if (tile.HasCharacters())
                    {
                        foreach (ICharacter character in tile.GetCharactersOnTile())
                        {
                            int distance = Math.Abs(character.GetX() - (int) _startPositionVector.X) +
                                                Math.Abs(character.GetY() - (int)_startPositionVector.Y);
                            if (_legalAttackTiles.Contains(character.getSpawnType())
                                && distance < EngineConstants.Priest_AttackRange * 32 + _movmentRange)
                            {
                                this._targetPosition = new Vector2(character.GetX(), character.GetY());
                                _preAttackFace = _directionFacing;
                                return true;
                            }
                        }
                    }
                }

            }
            return false;
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
                                && distance < EngineConstants.Priest_AttackRange * 32)
                            {
                                    this._targetCharacter =  character;
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
