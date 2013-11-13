using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{

    public interface IMenu
    {
        void Draw(SpriteBatch spriteBatch);
        void LoadContent(ContentManager content);
    }
}
