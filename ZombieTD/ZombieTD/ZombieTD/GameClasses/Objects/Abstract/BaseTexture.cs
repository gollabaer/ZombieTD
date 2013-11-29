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
        public float _rotation;
        public float _alpha;
        public int flips;
        public int numberOfSprites;
        public int currentSprite;

        /// <summary>
        /// Creates basic texture w/o animation.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fileName"></param>
        public BaseTexture(ContentManager content, string fileName)
        {
            _texture = content.Load<Texture2D>(fileName);
            _rotation = 0;
            _alpha = 1;
            _rec = new Rectangle(0, 0, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight);
        }

        public BaseTexture()
        {

        }

        public  float getAlpha() {
            return _alpha;
        }

        public void setAlpha(float alpha)
        {
            _alpha = alpha;
        }

        public abstract void update();

        public virtual Texture2D GetTexture()
        {
            return _texture;
        }

        public virtual float getRotation()
        {
            return _rotation;
        }

        public virtual Rectangle getViewRec()
        {
            return _rec;
        }

        public void setRotation(float angle) {
            this._rotation = angle;
        }

        public void setFrame(int f) {
            currentSprite = f;
        }

        public abstract Object Clone();


        public void SetNumberOfAnimations(int numberOfAnimations)
        {
            this.numberOfSprites = numberOfAnimations;
        }
    }
}
