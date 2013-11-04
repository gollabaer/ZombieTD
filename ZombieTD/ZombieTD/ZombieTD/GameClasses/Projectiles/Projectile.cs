using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ZombieTD
{
    public class Projectile : IProjectile
    {
        public void TakeTurn(IMediator mediator)
        {
            //Projectile Logic
        }
    

        public void  RegisterWithMediator(IMediator mediator, IGameElement element)
        {
 	        throw new NotImplementedException();
        }

        public void  Draw(SpriteBatch spritebatch)
        {
 	        throw new NotImplementedException();
        }
    }
}
