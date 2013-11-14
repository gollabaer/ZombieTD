using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZombieTD
{
    public abstract class Character : ICharacter
    {
        protected IMediator _mediator;
        public ITexture _texture; //Change tto protected
        protected Map _lineOfSiteMap;

        public int _health;
        public int _attackDamageMelee;
        public int _attackDamageRanged;
        public int _attackRange;
        public int _defense;
        public int _speed;
        public int _lineOfSite;
        public float directionFacing;

        public int _xPos, _yPos;
        protected int timer = 0;

        protected Character()
        {

        }

        public virtual void TakeTurn(IMediator mediator)
        {
            _lineOfSiteMap = mediator.GetMap(this);

            #region animationtests
            if (_texture != null && (GameMediator.numberofTicks % 10 == 0))
                _texture.update();

            #endregion

            timer++;
        }

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

        protected bool isWalkable(MoveDirection direction) {
            
            MapTileType tempType;
            MapTileType currentType = _lineOfSiteMap.GetTileByXY(_xPos, _yPos).TextureType;

            switch (direction)
                {
                    case MoveDirection.Down:
                        tempType =  _lineOfSiteMap.GetTileByXY(_xPos, _yPos + 32).TextureType;
                        break;
                    case MoveDirection.Up:
                        tempType =  _lineOfSiteMap.GetTileByXY(_xPos, _yPos - 32).TextureType;
                        break;
                    case MoveDirection.Left:
                        tempType =  _lineOfSiteMap.GetTileByXY(_xPos - 32, _yPos).TextureType;
                        break;
                    case MoveDirection.Right:
                        tempType =  _lineOfSiteMap.GetTileByXY(_xPos + 32, _yPos).TextureType;
                        break;
                    default: tempType = MapTileType.Error;
                        break;
                }
            
            if( (this.GetType() == typeof(Zombie)
                ||this.GetType() == typeof(ZombieDog))
                && (tempType == MapTileType.Path_noRock
                || tempType == MapTileType.Path_withRock
                || tempType == MapTileType.RoadMiddle
                || tempType == MapTileType.RoadOutside))
                return true;
            
            if( this.GetType() == typeof(FlyingZombie)) return true;
             
            if( (this.GetType() == typeof(Priest)
                || this.GetType() == typeof(Sheriff))
                && ((tempType == MapTileType.Building_roof_center
                    || tempType == MapTileType.Building_roof_corner
                    || tempType == MapTileType.Building_Roof_Side
                    || tempType == MapTileType.Path_noRock
                    || tempType == MapTileType.Path_withRock)
                    && (currentType != MapTileType.Grass
                    || currentType != MapTileType.RoadMiddle
                    || currentType != MapTileType.RoadOutside)))
                    return true;

            if( (this.GetType() == typeof(Priest)
                || this.GetType() == typeof(Sheriff))
                && ((currentType == MapTileType.Building_roof_center
                    || currentType == MapTileType.Building_roof_corner
                    || currentType == MapTileType.Building_Roof_Side)
                    && (tempType != MapTileType.Grass
                    || tempType != MapTileType.RoadMiddle
                    || tempType != MapTileType.RoadOutside
                    || tempType != MapTileType.Path_noRock
                    || tempType != MapTileType.Path_withRock)))
                    return true;

            if(this.GetType() == typeof(Redneck)
                && ( tempType == MapTileType.Grass
                    || tempType == MapTileType.RoadMiddle
                    || tempType == MapTileType.RoadOutside))
                return true;
            
            return false;
            
           }
        
    
        public void move(MoveDirection direction) {
            int time;
            int speed;

            if( this.GetType() == typeof(Zombie) ){
                    time = EngineConstants.Zombie_NumberOfFramesBeforeMove;
                    speed = EngineConstants.Zombie_Speed;
            }
            else if(this.GetType() == typeof(FlyingZombie) {
                time = EngineConstants.FlyingZombie_NumberOfFramesBeforeMove;
                speed = EngineConstants.FlyingZombie_Speed;
            }
                    
            else if(this.GetType() ==typeof(ZombieDog) ){
                time = EngineConstants.ZombieDog_NumberOfFramesBeforeMove;
                speed = EngineConstants.ZombieDog_Speed;
            }
            
            else if(this.GetType() ==typeof(Redneck) ){
                time = EngineConstants.Redneck_NumberOfFramesBeforeMove;
                speed = EngineConstants.Redneck_Speed;
            }
            
            else if(this.GetType() ==typeof(Priest) ){
                time = EngineConstants.Priest_NumberOfFramesBeforeMove;
                speed = EngineConstants.Priest_Speed;
            }
            
            else if(this.GetType() ==typeof(Sheriff) ){
                time = EngineConstants.Sheriff_NumberOfFramesBeforeMove;
                speed = EngineConstants.Sheriff_Speed;
            }
            else{
              time = 1;
              speed = 0;
            }
           
            /*
            if (timer > time )
            {
                switch (direction)
                {
                    case MoveDirection.Down:
                        _yPos+=speed;
                        break;
                    case MoveDirection.Up:
                        _yPos-= speed;
                        break;
                    case MoveDirection.Left:
                        _xPos-= speed;
                        break;
                    case MoveDirection.Right:
                        _xPos+= speed;
                        break;
                    default: break;
                }
                timer = 0;
            }
             */
        }



        public void RegisterWithMediator(IMediator mediator, IGameElement element)
        {
            _mediator = mediator;
            mediator.RegisterWithMediator(mediator, this);    
        }

        public virtual void TakeDamage(int damage)
        {

        }

        public ITexture GetTexture()
        {
            return _texture;
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            int dy = EngineConstants.SmallTextureHeight / 2;
            int dx = EngineConstants.SmallTextureWidth / 2;

            if (_texture != null)
            {
                //_texture.setRotation(this.GetTexture().getRotation());

                spritebatch.Draw(_texture.GetTexture(), new Rectangle(_xPos + dx, _yPos + dy, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight),
                    _texture.getViewRec(), Color.White, _texture.getRotation(), new Vector2(dx, dy), SpriteEffects.None, 0);
            }
        }
    }
}
