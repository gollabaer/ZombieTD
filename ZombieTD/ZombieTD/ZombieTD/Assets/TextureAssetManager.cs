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
    public class TextureAssetManager
    {
        const uint NUMOFTEXTURES = 51;

        public enum TextureTypes{
            Grass,
            Dirt,
            ETC
        }

        Texture2D[] textures = new Texture2D[NUMOFTEXTURES];

        public static void load(ContentManager content){
            
        }

        public ITexture getTexture(int texture) {

            return new TextureCustom();
        }
    }
}
