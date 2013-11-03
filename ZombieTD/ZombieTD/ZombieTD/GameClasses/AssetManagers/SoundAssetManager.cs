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

        public void LoadAssets(ContentManager content)
        {
            Array values = Enum.GetValues(typeof(SoundType));

            foreach (SoundType soundType in values)
            {
                ISound sound = new Sound(content, soundType.ToWaveFilename());
                soundPool.Add(soundType, sound);
                
            }
        }

        public I GetAsset<T, I>(T enumItem)
        {
            var found = from KeyValuePair<T,I> entry in soundPool
                        where entry.Key.ToString() == enumItem.ToString()
                        select entry;

            KeyValuePair<T, I> foundItem = found.FirstOrDefault();

            return foundItem.Value;   
        }
    }
}
