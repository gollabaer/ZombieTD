using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ZombieTD
{
    public abstract class EffectBase: IEffect
    {
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
