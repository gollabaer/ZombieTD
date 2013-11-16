using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ZombieTD
{
    public class Projectile : Character, IProjectile
    {
        public void TakeTurn(IMediator mediator)
        {
            //Projectile Logic
        }

        protected Projectile(int x, int y):base(x,y)
        {
        
        }
        

        public void  RegisterWithMediator(IMediator mediator, IGameElement element)
        {
 	        throw new NotImplementedException();
        }

        public void  Draw(SpriteBatch spritebatch)
        {
 	        throw new NotImplementedException();
        }

        protected override void Special3()
        {
            throw new NotImplementedException();
        }

        protected override void Special2()
        {
            throw new NotImplementedException();
        }

        protected override void Special1()
        {
            throw new NotImplementedException();
        }

        protected override void RangeAttack()
        {
            throw new NotImplementedException();
        }

        protected override void Move()
        {
            throw new NotImplementedException();
        }

        protected override void Attack()
        {
            throw new NotImplementedException();
        }

        protected override void ChooseAction()
        {
            base.ChooseAction();
        }
    }
}
