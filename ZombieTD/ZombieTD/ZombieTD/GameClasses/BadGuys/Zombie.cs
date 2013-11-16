using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class Zombie : Character, IZombie
    {
        public int _numberOfArms;

        public Zombie(int x, int y)
            : base(x, y)
        {
            _health = EngineConstants.Zombie_Health;
            _attackDamageMelee = EngineConstants.Zombie_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Zombie_AttackDamageRanged;
            _attackRange = EngineConstants.Zombie_AttackRange;
            _defense = EngineConstants.Zombie_Defense;
            _speed = EngineConstants.Zombie_Speed;
            _lineOfSite = EngineConstants.Zombie_LineOfSite;
            _walkableTiles = FilterEnumWithAttributeOf<MapTileType, Zombie>();

        }

        public Zombie()
        {

        }

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does
            //mediator.GetMap(this);


            /*
            if enemy has a character on its vision map
               if zombie has arms remaining
                  ThrowArm
               if zombie is next to a character
                  Attack
               else
                  MoveToCharacter
            if zombie has no characters on its vision map
               if there is a dead zombie and a counter hits a certain limit
                  Raise Soul
               else
                  MoveToCenter
            else
               Hold
             */

            this.ThrowArm(mediator, this, mediator.GetCharacter(0,0));
            this.RaiseSoul(mediator, this, mediator.GetCharacter(0, 0));

        }
       
        public void ThrowArm(IMediator mediator, ICharacter character, ICharacter target)
        {
            mediator.ThrowArm(mediator, this, target);
        }

        public void RaiseSoul(IMediator mediator, ICharacter character, ICharacter target)
        {
            mediator.RaiseSoul(mediator, character, target);
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
            if (movingDirection == MoveDirection.None)
            {
                Tile workingTile;
                

                if (directionFacing == EngineConstants.Up)
                {
                    workingTile = _lineOfSiteMap.GetTileByXY(_currentTile.Xpos, _currentTile.Ypos -32);

                    if (workingTile != null && this._previousTile != workingTile && _walkableTiles.Contains(workingTile.TextureType))
                    {
                        movingDirection = MoveDirection.Up;
                        this.directionFacing = EngineConstants.Up;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }
                    else
                    {
                        directionFacing = EngineConstants.Right;
                    }
                }

                if (directionFacing == EngineConstants.Right)
                {
                    workingTile = _lineOfSiteMap.GetTileByXY(_currentTile.Xpos + 32, _currentTile.Ypos);

                    if (workingTile != null && this._previousTile != workingTile && _walkableTiles.Contains(workingTile.TextureType))
                    {
                        movingDirection = MoveDirection.Right;
                        this.directionFacing = EngineConstants.Right;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }
                    else
                    {
                        directionFacing = EngineConstants.Down;
                    }
                }

                if (directionFacing == EngineConstants.Down)
                {
                    workingTile = _lineOfSiteMap.GetTileByXY(_currentTile.Xpos, _currentTile.Ypos + 32);

                    if (workingTile != null && this._previousTile != workingTile && _walkableTiles.Contains(workingTile.TextureType))
                    {
                        movingDirection = MoveDirection.Down;
                        this.directionFacing = EngineConstants.Down;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }
                    else
                    {
                        directionFacing = EngineConstants.Left;
                    }
                }

                if (directionFacing == EngineConstants.Left)
                {
                    workingTile = _lineOfSiteMap.GetTileByXY(_currentTile.Xpos - 32, _currentTile.Ypos);

                    if (workingTile != null && this._previousTile != workingTile && _walkableTiles.Contains(workingTile.TextureType))
                    {
                        movingDirection = MoveDirection.Left;
                        this.directionFacing = EngineConstants.Left;
                        this._previousTile = _currentTile;
                        this._currentTile.RemoveElement(this);
                        workingTile.AddElementToTile(this);
                    }
                    else
                    {
                        this._currentAction = CurrentAction.None;
                        //this._previousTile = _currentTile;
                        directionFacing = EngineConstants.Up;
                    }
                }

            }
            else //Character is in the move phase
            {
                if (GameMediator.numberofTicks % EngineConstants.Zombie_NumberOfFramesBeforeMove == 0)
                {
                    if (_moveCounter != 32)
                    {
                        switch (movingDirection)
                        {
                            case MoveDirection.Up: this._yPos -= EngineConstants.Zombie_Speed; break;
                            case MoveDirection.Right: this._xPos += EngineConstants.Zombie_Speed; break;
                            case MoveDirection.Down: this._yPos += EngineConstants.Zombie_Speed; break;
                            case MoveDirection.Left: this._xPos -= EngineConstants.Zombie_Speed; break;
                        }

                        _moveCounter = _moveCounter + EngineConstants.Zombie_Speed;
                    }
                    else
                    {
                        this._currentAction = CurrentAction.None;
                        this.movingDirection = MoveDirection.None;
                        _moveCounter = 0;
                    }

                }

            }
        }

        protected override void Attack()
        {
           // throw new NotImplementedException();
        }

        protected override void ChooseAction()
        {
           base.ChooseAction();

           if (IsBaseNextToMe())
           {
               _currentAction = CurrentAction.Attack;
           }
           else if (IsPlayerNextToMe())
           {
               _currentAction = CurrentAction.Attack;
           }
           else if (CanITrowArm())
           {

           }
           else
           {
               _currentAction = CurrentAction.Move;
           }


        }


        private bool CanITrowArm()
        {
            return false;
        }
    }
}
