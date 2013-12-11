using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    public class Redneck : Character, IRedneck
    {
        protected Vector2 _targetPosition;
        protected Vector2 _startPositionVector;

        public Redneck(int x, int y)
            : base(x, y)
        {
            _maxHealth = EngineConstants.Redneck_Health;
            _health = EngineConstants.Redneck_Health;
            _attackDamageMelee = EngineConstants.Redneck_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Redneck_AttackDamageRanged;
            _attackRange = EngineConstants.Redneck_AttackRange;
            _defense = EngineConstants.Redneck_Defense;
            _speed = EngineConstants.Redneck_Speed;
            _lineOfSite = EngineConstants.Redneck_LineOfSite;
            _legalMovmentTiles = FilterEnumWithAttributeOf<MapTileType, Redneck>();
            _legalAttackTiles = FilterEnumWithAttributeOf<SpawnType, Redneck>();
            _movmentRange = EngineConstants.Redneck_MovmentRange;

        }

        public Redneck()
        {
        }

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
        }

        //Special 1
        public void CutOffArm(IMediator mediator, ICharacter charater, ICharacter target)
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

        }

        protected override void RangeAttack()
        {
            throw new NotImplementedException();
        }

        protected override void Move()
        {
            if (_movingDirection == MoveDirection.None)
            {
                Tile workingTile = _lineOfSiteMap.GetTileByXY(this._xPos + 32, this._yPos);

                if (this._xPos < _targetPosition.X
                    && workingTile != null
                    && _legalMovmentTiles.Contains(workingTile.TextureType)
                    && this._previousTile != workingTile)
                {
                    _movingDirection = MoveDirection.Right;
                    this._directionFacing = EngineConstants.Right;
                    this._previousTile = _currentTile;
                    this._currentTile.RemoveElement(this);
                    workingTile.AddElementToTile(this);
                }

                workingTile = _lineOfSiteMap.GetTileByXY(this._xPos - 32, this._yPos);
                if (this._xPos > _targetPosition.X
                    && workingTile != null
                    && _legalMovmentTiles.Contains(workingTile.TextureType)
                    && this._previousTile != workingTile)
                {
                    _movingDirection = MoveDirection.Left;
                    this._directionFacing = EngineConstants.Left;
                    this._previousTile = _currentTile;
                    this._currentTile.RemoveElement(this);
                    workingTile.AddElementToTile(this);
                }

                workingTile = _lineOfSiteMap.GetTileByXY(this._xPos, this._yPos - 32);
                if (this._yPos > _targetPosition.Y
                    && workingTile != null
                    && _legalMovmentTiles.Contains(workingTile.TextureType)
                    && this._previousTile != workingTile)
                {
                    _movingDirection = MoveDirection.Up;
                    this._directionFacing = EngineConstants.Up;
                    this._previousTile = _currentTile;
                    this._currentTile.RemoveElement(this);
                    workingTile.AddElementToTile(this);
                }

                workingTile = _lineOfSiteMap.GetTileByXY(this._xPos, this._yPos + 32);
                if (this._yPos < _targetPosition.Y
                    && workingTile != null
                    && _legalMovmentTiles.Contains(workingTile.TextureType)
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
                if (GameMediator.numberofTicks % EngineConstants.Redneck_NumberOfFramesBeforeMove == 0)
                {
                    if (_moveCounter != 32)
                    {
                        switch (_movingDirection)
                        {
                            case MoveDirection.Up: this._yPos -= EngineConstants.Redneck_Speed; break;
                            case MoveDirection.Right: this._xPos += EngineConstants.Redneck_Speed; break;
                            case MoveDirection.Down: this._yPos += EngineConstants.Redneck_Speed; break;
                            case MoveDirection.Left: this._xPos -= EngineConstants.Redneck_Speed; break;
                        }

                        _moveCounter = _moveCounter + EngineConstants.Redneck_Speed;
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

            if (GameMediator.numberofTicks % 30 == 0)
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

            if (IsPlayerNextToMe())
            {
                _currentAction = CurrentAction.Attack;
            }
            else if (isPlayerInrange())
            {
                _currentAction = CurrentAction.Move;
            }
            else
            {
                _targetPosition = _startPositionVector;
                _currentAction = CurrentAction.None;
            }
        }

        protected bool isPlayerInrange()
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
                                && distance < EngineConstants.Redneck_AttackRange * 32 + _movmentRange)
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
                                && distance < EngineConstants.Redneck_AttackRange * 32)
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
