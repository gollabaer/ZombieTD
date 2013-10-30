using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public abstract class Character : ICharacter
    {
        protected IMediator _mediator;
        protected ITexture _texture;
        protected Map _lineOfSiteMap;

        public int _health;
        public int _attackDamageMelee;
        public int _attackDamageRanged;
        public int _attackRange;
        public int _defense;
        public int _speed;
        public int _lineOfSite;
        public int _xPos, Ypos;
        public int directionFacing; //0 - 360
        
        public virtual void TakeTurn(IMediator mediator)
        {
            _lineOfSiteMap = mediator.GetMap(this);
        }
        
        public void RegisterWithMediator(IMediator mediator, IGameElement element)
        {
            _mediator = mediator;
            mediator.RegisterWithMediator(mediator, this);    
        }

        public virtual void TakeDamage(int damage)
        {

        }

        public virtual void Draw()
        {

        }
    }
}
