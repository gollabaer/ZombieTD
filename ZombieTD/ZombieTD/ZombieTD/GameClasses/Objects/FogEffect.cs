using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace ZombieTD
{
    public class FogEffect : EffectBase
    {
        public ITexture _fogtexture;
        Vector2 _centerVec;
        Vector2 _velocity;
        ulong timetracker = 0;

        public FogEffect() {
            _centerVec = new Vector2(0, 0);
            _velocity = new Vector2(1, 1);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int textureWidth = _fogtexture.GetTexture().Width;
            int textureHeight = _fogtexture.GetTexture().Height;
            int x =(int) _centerVec.X;
            int y =(int) _centerVec.Y;

            spriteBatch.Draw(_fogtexture.GetTexture(), new Rectangle(x - textureWidth, y - textureHeight, textureWidth, textureHeight), Color.White *_fogtexture.getAlpha());
            spriteBatch.Draw(_fogtexture.GetTexture(), new Rectangle(x               , y - textureHeight, textureWidth, textureHeight), Color.White* _fogtexture.getAlpha());
            spriteBatch.Draw(_fogtexture.GetTexture(), new Rectangle(x + textureWidth, y - textureHeight, textureWidth, textureHeight), Color.White * _fogtexture.getAlpha());

            spriteBatch.Draw(_fogtexture.GetTexture(), new Rectangle(x - textureWidth, y, textureWidth, textureHeight), Color.White * _fogtexture.getAlpha());
            spriteBatch.Draw(_fogtexture.GetTexture(), new Rectangle(x, y, textureWidth, textureHeight), Color.White * _fogtexture.getAlpha());
            spriteBatch.Draw(_fogtexture.GetTexture(), new Rectangle(x + textureWidth, y, textureWidth, textureHeight), Color.White * _fogtexture.getAlpha());

            spriteBatch.Draw(_fogtexture.GetTexture(), new Rectangle(x - textureWidth, y + textureHeight, textureWidth, textureHeight), Color.White * _fogtexture.getAlpha());
            spriteBatch.Draw(_fogtexture.GetTexture(), new Rectangle(x, y + textureHeight, textureWidth, textureHeight), Color.White * _fogtexture.getAlpha());
            spriteBatch.Draw(_fogtexture.GetTexture(), new Rectangle(x + textureWidth, y + textureHeight, textureWidth, textureHeight), Color.White * _fogtexture.getAlpha());

        }

        public override void update() {

            //TODO CHANGEVELOCITY
            if (timetracker % 3 == 0) 
            _centerVec += _velocity;

            if (_velocity.X < 0 && _centerVec.X + _fogtexture.GetTexture().Width <=0)
            {
                _centerVec.X = 0;
            }
            else if(_velocity.X >0 && _centerVec.X  >= EngineConstants.ScreenWidth ){
                _centerVec.X = EngineConstants.ScreenWidth - _fogtexture.GetTexture().Width;
            }

            if (_velocity.Y > 0 && _centerVec.Y  >= EngineConstants.ScreenHeight) {
                _centerVec.Y = EngineConstants.ScreenHeight - _fogtexture.GetTexture().Height;
            }
            else if (_velocity.Y < 0 && _centerVec.Y + _fogtexture.GetTexture().Height <= 0) {
                _centerVec.Y = 0;
            }
            //TODO CHANGEALPHA
            float al = (float)Math.Cos(timetracker / 30.0);
            al = al * 0.1f + 0.4f;
            _fogtexture.setAlpha(al);
            timetracker++;

        }
    }
}
