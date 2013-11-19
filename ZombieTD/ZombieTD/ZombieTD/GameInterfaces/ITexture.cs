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
    public interface ITexture : ICloneable
    {
        Texture2D GetTexture();

        Rectangle getViewRec();

        void setRotation(float angle);

        float getRotation();

        float getAlpha();

        void setAlpha(float alpha);

        void update();

        void SetNumberOfAnimations(int numberOfAnimations);

    }
}
