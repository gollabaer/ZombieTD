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
    class Sound : ISound
    {
        public SoundEffect sound;
        public List<SoundEffectInstance> pool;
        public Sound(ContentManager Content, String Filename)
        {
            sound = Content.Load<SoundEffect>(Filename);
            pool = new List<SoundEffectInstance>() { sound.CreateInstance() };
        }
        public void Play(float Volume = 1f, float Pan = 0f, float Pitch = 0f)
        {
            for (int p = 0; p < pool.Count; p++)
            {
                if (pool[p].State == SoundState.Stopped)
                {
                    Play(pool[p], Volume, Pan, Pitch);
                    return;
                }
            }
            pool.Add(sound.CreateInstance());
            Play(pool[pool.Count - 1], Volume, Pan, Pitch);
        }
        private void Play(SoundEffectInstance SoundEffectInstance, float Volume, float Pan, float Pitch)
        {
            SoundEffectInstance.Volume = Volume;
            SoundEffectInstance.Pan = Pan;
            SoundEffectInstance.Pitch = Pitch;
            SoundEffectInstance.Play();
        }
    }
}
