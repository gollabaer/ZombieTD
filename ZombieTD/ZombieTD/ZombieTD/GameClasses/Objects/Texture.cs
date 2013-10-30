using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    class Texture : ITexture
    {
        public Rectangle _rec;
        public Texture2D _texture2d;
        public int _height;
        public int _width;
    }
}
