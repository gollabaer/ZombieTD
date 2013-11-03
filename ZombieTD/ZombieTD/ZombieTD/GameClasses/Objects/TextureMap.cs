using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{
    public class TextureMap : BaseTexture
    {
        public TextureMap(ContentManager content, string fileName) : base(content, fileName)
        {
           //Flip Texture Based once based on flips
        }
    }
}
