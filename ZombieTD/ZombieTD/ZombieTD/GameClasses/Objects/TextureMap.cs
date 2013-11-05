using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{
    public class TextureMap : BaseTexture
    {

        public TextureMap() : base()
        {

        }

        public TextureMap(ContentManager content, string fileName) : base(content, fileName)
        {
           //Flip Texture Based once based on flips
        }

        public override object Clone()
        {
            TextureMap clone = new TextureMap();

            clone._rec = this._rec;
            clone._texture = this._texture;
            clone._height = this._height;
            clone._width = this._width;
            clone._rotation = this._rotation;
            clone._alpha = this._alpha;
            clone.flips = this.flips;
            clone.numberOfSprites = this.numberOfSprites;
            clone.currentSprite = this.currentSprite;

            return clone as Object;
        }
    }
}
