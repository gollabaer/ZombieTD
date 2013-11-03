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
        public TextureNormal(ContentManager content, string fileName) : base(content, fileName)
        {
           
        }
    }
}
