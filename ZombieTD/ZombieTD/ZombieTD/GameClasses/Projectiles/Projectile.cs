using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void  Draw()
        {
 	        throw new NotImplementedException();
        }
    }
}
