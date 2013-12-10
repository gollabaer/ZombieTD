using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ZombieTD
{
    public abstract class EffectBase: Attribute, IEffect
    {
        protected ITexture _texture;

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void LoadContent(IMediator mediator);

        public abstract void update();
    }
}
