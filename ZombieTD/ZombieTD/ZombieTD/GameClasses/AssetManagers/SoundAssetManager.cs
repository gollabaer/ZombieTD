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
    public class SoundAssetManager : IAssetManager
    {
        Dictionary<SoundType, ISound> soundPool = new Dictionary<SoundType, ISound>();
        Dictionary<MusicType, ISound> musicPool = new Dictionary<MusicType, ISound>();

        public void LoadAssets(ContentManager content)
        {
            Array values = Enum.GetValues(typeof(SoundType));

            foreach (SoundType soundType in values)
            {
                ISound sound = new Sound(content, soundType.ToSoundFileFilename());
                soundPool.Add(soundType, sound);
                
            }

            values = Enum.GetValues(typeof(MusicType));

            foreach (MusicType musicType in values)
            {
                ISound music = new Music(content, musicType.ToMusicFileFilename());
                musicPool.Add(musicType, music);
            }
        }

        public I GetAsset<T, I>(T enumItem) where I : ICloneable
        {
            if (enumItem.GetType() == typeof(SoundType))
            {
                var found = from KeyValuePair<T, I> entry in soundPool
                            where entry.Key.ToString() == enumItem.ToString()
                            select entry;

                KeyValuePair<T, I> foundItem = found.FirstOrDefault();

                return foundItem.Value;
            }

            if (enumItem.GetType() == typeof(MusicType))
            {
                var found = from KeyValuePair<T, I> entry in musicPool
                            where entry.Key.ToString() == enumItem.ToString()
                            select entry;

                KeyValuePair<T, I> foundItem = found.FirstOrDefault();

                return foundItem.Value;
            }

            throw new NotImplementedException("Cannot get Audio of Type" + Type.GetType(typeof(I).Name).Name);
        }
    }
}
