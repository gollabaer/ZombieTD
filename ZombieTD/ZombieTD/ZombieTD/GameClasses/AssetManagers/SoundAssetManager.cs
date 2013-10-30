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
        static AudioEngine _audioEngine;
        static WaveBank _waveBank;
        static SoundBank _soundBank;
        static Cue cue1;
        static Cue cue2;
        
        public static void load(ContentManager content) {
        
        }

        public static void play(String track) {
        
        }

        public static void playBackground(String bgtrack){}




        public void LoadAssets()
        {
            //throw new NotImplementedException();
        }
    }
}
