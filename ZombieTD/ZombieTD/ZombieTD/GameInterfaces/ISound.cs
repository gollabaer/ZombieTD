using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public interface ISound : ICloneable
    {
        void Play(float Volume = 1f, float Pan = 0f, float Pitch = 0f,bool isLoop = false);
    }
}
