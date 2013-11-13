using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{
    public class Music : ISound
    {
       public Song song;
    
        public Music(ContentManager Content, String Filename)
        {
            song = Content.Load<Song>(Filename);
        }
        public void Play(float Volume = 1f, float Pan = 0f, float Pitch = 0f, bool isLoop = false)
        {
            MediaPlayer.Volume = Volume;
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = isLoop;
        }
        
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
