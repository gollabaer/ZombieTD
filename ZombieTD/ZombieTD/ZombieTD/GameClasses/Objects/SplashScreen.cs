using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    public class SplashScreen : MenuBase
    {

        public SplashScreen(IMediator mediator) : base(mediator) 
        { 
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture.GetTexture(), new Rectangle(0, 0, EngineConstants.SplashScreenTextureWidth, EngineConstants.SplashScreenTextureHeight), Color.White);
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            this._texture = _mediator.GetAsset<MenuTextureType, ITexture>(MenuTextureType.SplashScreen);
        }
    }
}
