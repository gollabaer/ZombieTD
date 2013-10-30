using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    public abstract class BaseTexture : ITexture
    {
        public Rectangle _rec;
        public Texture2D _texture2d;
        public int _height;
        public int _width;
        float _rotation;
        float _alpha;
    }
}
