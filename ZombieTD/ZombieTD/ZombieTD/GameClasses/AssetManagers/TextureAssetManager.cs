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
        Dictionary<MapTileType, ITexture> mapTexturePool = new Dictionary<MapTileType, ITexture>();
        Dictionary<CharacterTextureType, ITexture> characterTexturePool = new Dictionary<CharacterTextureType, ITexture>();
        Dictionary<StructureTextureType, ITexture> structureTexturePool = new Dictionary<StructureTextureType, ITexture>();
        Dictionary<EffectTextureType, ITexture> effectTexturePool = new Dictionary<EffectTextureType, ITexture>();
        Dictionary<MenuTextureType, ITexture> menuTexturePool = new Dictionary<MenuTextureType, ITexture>();

        public void LoadAssets(ContentManager content)
        {
            try
            {
                Array characterValues = Enum.GetValues(typeof(CharacterTextureType));

                foreach (CharacterTextureType characterType in characterValues)
                {
                    ITexture texture = new TextureNormal(content, characterType.ToCharacterTextureFilename());
                    characterTexturePool.Add(characterType, texture);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Log_Type.ERROR, "Failed to load character textures " + ex.ToString());
            }

            try
            {
                Array mapValues = Enum.GetValues(typeof(MapTileType));

                foreach (MapTileType mapTileType in mapValues)
                {
                    ITexture texture = new TextureMap(content, mapTileType.ToMapTileTextureFileFilename());
                    mapTexturePool.Add(mapTileType, texture);

                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Log_Type.ERROR, "Failed to load map textures " + ex.ToString());
            }

            try
            {
                Array structureValues = Enum.GetValues(typeof(StructureTextureType));

                foreach (StructureTextureType structureType in structureValues)
                {
                    ITexture texture = new TextureNormal(content, structureType.ToStructureTextureFileFilename());
                    structureTexturePool.Add(structureType, texture);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Log_Type.ERROR, "Failed to load structure textures " + ex.ToString());
            }

            try
            {
                Array effectValues = Enum.GetValues(typeof(EffectTextureType));

                foreach (EffectTextureType effectType in effectValues)
                {
                    ITexture texture = new TextureNormal(content, effectType.ToEffectTextureFileFilename());
                    effectTexturePool.Add(effectType, texture);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Log_Type.ERROR, "Failed to load effect textures " + ex.ToString());
            }

            try
            {
                Array menuValues = Enum.GetValues(typeof(MenuTextureType));

                foreach (MenuTextureType menuType in menuValues)
                {
                    ITexture texture = new TextureNormal(content, menuType.ToMenuTextureFileFilename());
                    menuTexturePool.Add(menuType, texture);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Log_Type.ERROR, "Failed to load menu textures " + ex.ToString());
            }
        }

        public I GetAsset<T, I>(T enumItem) where I : ICloneable
        {

            //if It is a map texture
            if (enumItem.GetType() == typeof(MapTileType))
            {
                var found = from KeyValuePair<T, I> entry in mapTexturePool
                            where entry.Key.ToString() == enumItem.ToString()
                            select entry;

                KeyValuePair<T, I> foundItem = found.FirstOrDefault();

                return (I)foundItem.Value.Clone();   
            }

            if (enumItem.GetType() == typeof(CharacterTextureType))
            {
                var found = from KeyValuePair<T, I> entry in characterTexturePool
                            where entry.Key.ToString() == enumItem.ToString()
                            select entry;

                KeyValuePair<T, I> foundItem = found.FirstOrDefault();

                return (I)foundItem.Value.Clone();   
            }

            if (enumItem.GetType() == typeof(StructureTextureType))
            {
                var found = from KeyValuePair<T, I> entry in structureTexturePool
                            where entry.Key.ToString() == enumItem.ToString()
                            select entry;

                KeyValuePair<T, I> foundItem = found.FirstOrDefault();

                return (I)foundItem.Value.Clone();   
            }

            if (enumItem.GetType() == typeof(MenuTextureType))
            {
                var found = from KeyValuePair<T, I> entry in menuTexturePool
                            where entry.Key.ToString() == enumItem.ToString()
                            select entry;

                KeyValuePair<T, I> foundItem = found.FirstOrDefault();

                return (I)foundItem.Value.Clone();
            }

            if (enumItem.GetType() == typeof(EffectTextureType))
            {
                var found = from KeyValuePair<T, I> entry in effectTexturePool
                            where entry.Key.ToString() == enumItem.ToString()
                            select entry;

                KeyValuePair<T, I> foundItem = found.FirstOrDefault();

                return (I)foundItem.Value.Clone();
            }

            throw new NotImplementedException("Cannot get Texture of Type" + Type.GetType(typeof(I).Name).Name);
        }
    }
}
