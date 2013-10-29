using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZombieTDEngine.GameInterfaces;

namespace ZombieTDEngine.GameClasses
{
    class Texture : ITexture
    {
        public Rectangle _rec;
        public Texture2D _texture2d;
        public int _height;
        public int _width;
    }
}
