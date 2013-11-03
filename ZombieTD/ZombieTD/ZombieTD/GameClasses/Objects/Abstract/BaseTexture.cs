using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{
    public abstract class BaseTexture : ITexture
    {
        public Rectangle _rec;
        public Texture2D _texture;
        public int _height;
        public int _width;
        float _rotation;
        float _alpha;
        int flips;

        public BaseTexture(ContentManager content, string fileName)
        {
            _texture = content.Load<Texture2D>(fileName);
        }

        public virtual ITexture GetTexture()
        {
            return _texture as ITexture;
        }
    }
}
