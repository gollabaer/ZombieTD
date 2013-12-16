using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    //http://nullcandy.com/particle-text-in-xna-and-javascript/
    public class Particle
    {
        public Vector2 Position { get; set; }
        public Vector2 Destination { get; set; }

        public void Update()
        {
            // move 1/60th of the way to your destination
            Position += (Destination - Position) / 60f;
        }


    }
}
