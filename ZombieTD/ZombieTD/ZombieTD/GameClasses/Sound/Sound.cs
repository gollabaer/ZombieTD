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
        public SoundEffectInstance soundEffect;

        public Sound(ContentManager Content, String Filename)
        {
            sound = Content.Load<SoundEffect>(Filename);
            soundEffect = sound.CreateInstance();
        }

        public void Play(float Volume = 1f, float Pan = 0f, float Pitch = 0f, bool isLoop = false)
        {
                if (soundEffect.State == SoundState.Stopped)
                {
                    Play(soundEffect, Volume, Pan, Pitch);
                    return;
                }
        }
        private void Play(SoundEffectInstance SoundEffectInstance, float Volume, float Pan, float Pitch)
        {
            SoundEffectInstance.Volume = Volume;
            SoundEffectInstance.Pan = Pan;
            SoundEffectInstance.Pitch = Pitch;
            SoundEffectInstance.Play();
        }

       
        public object Clone()
        {
            throw new NotImplementedException();
        }


        public void Stop()
        {
            if (soundEffect.State == SoundState.Playing)
                soundEffect.Stop();
        }
    }
}
