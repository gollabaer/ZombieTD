using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ZombieTD
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class TextureNormal : BaseTexture
    {

        public TextureNormal() : base()
        {

        }
        public TextureNormal(ContentManager content, string fileName) : base(content, fileName)
        {
            _rec = new Rectangle(0, 0, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight);
            
            //TODO: Add constant to EngineConstants or as parameter of constructor
            numberOfSprites = 4;
            currentSprite = 0;
        }

        public virtual void update() {
            currentSprite++;
            if (currentSprite == numberOfSprites)
                currentSprite = 0;
            _rec.X = currentSprite * EngineConstants.SmallTextureWidth;
        }


        public override object Clone()
        {
            TextureNormal clone = new TextureNormal();

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
