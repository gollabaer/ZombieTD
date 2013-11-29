using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;

namespace ZombieTD
{
    public abstract class Character : Attribute, ICharacter
    {
        protected IMediator _mediator;
        public ITexture _texture; //Change tto protected
        protected Map _lineOfSiteMap;

        protected int _health;
        public int _attackDamageMelee;
        public int _attackDamageRanged;
        public int _attackRange;
        public int _defense;
        public int _speed;
        public int _lineOfSite;
        public float _directionFacing;
        public int _movmentRange;
        public CurrentAction _currentAction;
        public Tile _currentTile;
        public Tile _previousTile;
        public Tile _startingTile;
        public IEnumerable<MapTileType> _legalMovmentTiles;
        public IEnumerable<SpawnType> _legalAttackTiles;
        public MoveDirection _movingDirection;
        public int _moveCounter = 0;
        public int _xPos, _yPos;
        protected int timer = 0;
        public SpawnType _spawnType;
        public ICharacter _targetCharacter;
        public Tile _targetTile;
        public Tile _targetMoveToTile;
        public List<ICharacter> _targetCharacterList;


        protected List<Tile> _nextToTiles;
        private int upperXPosition, upperYPosition, lowerXPosition, lowerYPosition;
        protected bool _isDoingAction;
        private bool _amIDead = false;
        protected float _preAttackFace;

        protected Character(int x, int y)
        {
            this._xPos = x;
            this._yPos = y;
            this._currentAction = CurrentAction.None;
            this._movingDirection = MoveDirection.None;
        }

        protected Character()
        {
            
        }

        public void SetRotation(float rotation)
        {
            this._texture.setRotation(rotation);
        }
        public virtual void TakeTurn(IMediator mediator)
        {
            if (!_amIDead)
            {
                //Figure out what the character is doing and continue/start the action
                switch (_currentAction)
                {
                    case CurrentAction.None: ChooseAction(); break;
                    case CurrentAction.Attack: Attack(); break;
                    case CurrentAction.Move: Move(); break;
                    case CurrentAction.Range: RangeAttack(); break;
                    case CurrentAction.Special1: Special1(); break;
                    case CurrentAction.Special2: Special2(); break;
                    case CurrentAction.Special3: Special3(); break;
                }
            }

           

            timer++;
        }

        #region ActionMethods
        protected abstract void Special3();
        
        protected abstract void Special2();
       
        protected abstract void Special1();
       
        protected abstract void RangeAttack();
      
        protected abstract void Move();

        protected virtual void Attack()
        {
            SetAttackDirection();
        }

        private void SetAttackDirection()
        {
            int x = 0, y = 0;

            if (_targetTile != null)
            {
                x = _targetTile.Xpos;
                y = _targetTile.Ypos;
            }
            else if (_targetCharacter != null)
            {
                x = _targetCharacter.GetX();
                y = _targetCharacter.GetY();
            }

            if (x > this._xPos && y < this._yPos)
            {
                //upright
                this._directionFacing = EngineConstants.UpRight;
            }
            else if (x > this._xPos && y > this._yPos)
            {
                //lower right
                this._directionFacing = EngineConstants.DownRight;
            }
            else if (x < this._xPos && y > this._yPos)
            {
                //lower left
                this._directionFacing = EngineConstants.DownLeft;
            }
            else if (x < this._xPos && y < this._yPos)
            {
                //upper left
                this._directionFacing = EngineConstants.UpLeft;
            }
            else if (y == this._yPos && x > this._xPos)
            {
                //right
                this._directionFacing = EngineConstants.Right;
            }
            else if (y > this._yPos && x == this._yPos)
            {
                //Down
                this._directionFacing = EngineConstants.Down;
            }
            else if (x < this._xPos && y == this._yPos)
            {
                //left
                this._directionFacing = EngineConstants.Left;
            }
            else if (x == this._xPos && y < this._yPos)
            {
                //up
                this._directionFacing = EngineConstants.Up;
            }
        }
      
        protected virtual void ChooseAction()
        {
            //If there is no current Action then the character needs to refresh the map
            this._lineOfSiteMap = _mediator.GetMapByLineOfSight(this);
            SetNextToTiles();
        }

        private void SetNextToTiles()
        {
            upperXPosition = this._xPos + -32; 
            upperYPosition = this._yPos + -32;
            lowerXPosition = this._xPos +  32;
            lowerYPosition = this._yPos +  32;

            var found = from tile in _lineOfSiteMap.Tiles
                        where tile.Xpos >= upperXPosition && tile.Xpos <= lowerXPosition &&
                                tile.Ypos >= upperYPosition && tile.Ypos <= lowerYPosition
                        select tile;

            this._nextToTiles = (List<Tile>)found.ToList();
        }

        #endregion

        public int getLineOfSight()
        {
            return _lineOfSite;
        }

        public int GetX()
        {
            return this._xPos;
        }

        public int GetY()
        {
            return this._yPos;
        }

        public Tile GetTile()
        {
            return _currentTile;
        }

        public void SetTile(Tile tile)
        {
            this._currentTile = tile;
        }

        public void RegisterWithMediator(IMediator mediator, IGameElement element)
        {
            _mediator = mediator;
            mediator.RegisterWithMediator(mediator, this);    
        }

        public ITexture GetTexture()
        {
            return _texture;
        }



        protected bool IsBaseNextToMe()
        {
            if (_targetTile == null)
            {
                var found = from tile in _nextToTiles
                            where tile != null && (tile.TextureType == MapTileType.TownhallRoof_Side ||
                                  tile.TextureType == MapTileType.RoofTownHall_corner)
                            select tile;

                _targetTile = found.FirstOrDefault();
                _preAttackFace = _directionFacing;

                //TO-DO
                //Set facingdirection to tile
            }

            return (_targetTile != null);
        }

        protected virtual bool IsPlayerNextToMe()
        {
            if (_targetCharacter == null)
            {
                foreach (Tile tile in _nextToTiles)
                {
                    if (tile.HasCharacters())
                    {
                        foreach (ICharacter character in tile.GetCharactersOnTile())
                        {
                            if (_legalAttackTiles.Contains(character.getSpawnType()))
                            {
                                if (this is IZombie || this is IZombieDog)
                                {
                                    if (character.GetTile().TextureType != MapTileType.Building_roof_center &&
                                        character.GetTile().TextureType != MapTileType.Building_roof_corner &&
                                        character.GetTile().TextureType != MapTileType.Building_Roof_Side)
                                    {
                                        this._targetCharacter = character;
                                        _preAttackFace = _directionFacing;
                                        return true;
                                    }
                                }
                                else
                                {
                                    this._targetCharacter = character;
                                    _preAttackFace = _directionFacing;
                                    return true;
                                }
                            }
                        }
                    }

                }

            }
           
            return (_targetTile != null);
        }


       


        protected virtual bool IsPlayerNearMe()
        {
            return true;
        }




        public virtual void Draw(SpriteBatch spritebatch)
        {
            #region animationtests
            if (_texture != null && (GameMediator.numberofTicks % 10 == 0) && _currentAction == CurrentAction.Move)
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

        public virtual bool TakeDamage(int damage)
        {
            
            this._health -= damage;

            if (this._health <= 0)
            {
                ClearTargets();
                _currentTile.RemoveElement(this);
                _amIDead = true;
                _mediator.ReportDeath(this);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ClearTargets()
        {
            _targetCharacter = null;
            _targetCharacterList = null;
            _targetMoveToTile = null;
            _targetTile = null;
        }

        public SpawnType getSpawnType()
        {
            return this._spawnType;
        }

        public bool GetDeadFlag()
        {
            return this._amIDead;
        }

        //http://tiredblogger.wordpress.com/2009/07/09/filtering-an-enum-by-attribute/
        public static IEnumerable<TEnum> FilterEnumWithAttributeOf<TEnum, TAttribute>()
            where TEnum : struct
            where TAttribute : class
        {
            foreach (var field in
                typeof(TEnum).GetFields(BindingFlags.GetField |
                                        BindingFlags.Public |
                                        BindingFlags.Static))
            {

                if (field.GetCustomAttributes(typeof(TAttribute), false).Length > 0)
                    yield return (TEnum)field.GetValue(null);
            }
        }

        public void SetStartTile(Tile tile)
        {
            this._startingTile = tile;
        }
    }
}
