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
    public class TextureAssetManager : IAssetManager
    {
        const uint NUMOFTEXTURES = 51;

        #region Obsolete Moved To Constants Class
        //public enum TextureTypes{
        //    Grass,
        //    Dirt,
        //    ETC
        //}
        #endregion

        Texture2D[] textures = new Texture2D[NUMOFTEXTURES];

        public static void load(ContentManager content){
            
        }

        public void LoadAssets(ContentManager content)
        {
            //throw new NotImplementedException();
        }


        public I GetAsset<T, I>(T enumItem)
        {

            //if It is a map texture
            if (enumItem.GetType() == typeof(MapTileType))
            {
                //Logic to get texture.
            }

            if (enumItem.GetType() == typeof(CharacterTextureType))
            {

            }

            if (enumItem.GetType() == typeof(StructureTextureType))
            {

            }




            throw new NotImplementedException();
            
        }
    }
}
