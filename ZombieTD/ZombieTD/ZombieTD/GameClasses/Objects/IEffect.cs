using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ZombieTD
{
    public interface IEffect
    {
        void Draw(SpriteBatch spriteBatch);

        void update();
    }
}
