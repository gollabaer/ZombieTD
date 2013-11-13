using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace ZombieTD
{
    public class FogEffect2 : EffectBase
    {
        Rectangle rectangle1;
        Rectangle rectangle2;
        float _currentAlpha;
        bool _fadeIn;

        public FogEffect2()
        {
            _currentAlpha = EngineConstants.Fog_StartAlpha;
            _fadeIn = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture.GetTexture(), rectangle1, Color.White * _texture.getAlpha());
            spriteBatch.Draw(_texture.GetTexture(), rectangle2, Color.White * _texture.getAlpha());
        }

        public override void update() {

            if (GameMediator.numberofTicks % EngineConstants.Fog_UpdateRate == 0)
            {
                // 5a. This is where the quote unquote "magic" happens.
                // This is a simple bounds check. If the right edge of 
                // rectangle1 is offscreen to the left, you move it to 
                // the right side of rectangle2.
                if (rectangle1.X + _texture.GetTexture().Width <= 0)
                    rectangle1.X = rectangle2.X + _texture.GetTexture().Width;
                // You repeat this check for rectangle2.
                if (rectangle2.X + _texture.GetTexture().Width <= 0)
                    rectangle2.X = rectangle1.X + _texture.GetTexture().Width;

                // 6. Otherwise we incrementally move it to the left. 
                // You can swap out X for Y if you instead want incremental 
                // vertical scrolling.
                rectangle1.X -= EngineConstants.FogSpeed;
                rectangle2.X -= EngineConstants.FogSpeed;

                if (_fadeIn)
                {
                    if (_currentAlpha < EngineConstants.Fog_AlphaThreshold)
                        _currentAlpha += EngineConstants.Fog_AlphaIncrement;
                    else
                    {
                        _fadeIn = false;
                       // _currentAlpha = EngineConstants.Fog_AlphaThreshold;
                    }
                }
                else
                {
                    if (_currentAlpha > EngineConstants.Fog_ResetValue)
                        _currentAlpha -= EngineConstants.Fog_AlphaIncrement;
                    else
                    {
                        _fadeIn = true;
                       // _currentAlpha = EngineConstants.Fog_ResetValue;
                    }

                }

                _texture.setAlpha(_currentAlpha);
            }
        }

        public override void LoadContent(IMediator mediator)
        {
            this._texture = mediator.GetAsset<EffectTextureType, ITexture>(EffectTextureType.Fog);
            rectangle1 = new Rectangle(0, 0, _texture.GetTexture().Width, _texture.GetTexture().Height);
            rectangle2 = new Rectangle(_texture.GetTexture().Width, 0, _texture.GetTexture().Width, _texture.GetTexture().Height);


        }
    }
}
