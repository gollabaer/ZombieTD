using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class Zombie : Character, IZombie
    {
        public int _numberOfArms;

        public Zombie()
            : base()
        {
            _health = EngineConstants.Zombie_Health;
            _attackDamageMelee = EngineConstants.Zombie_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Zombie_AttackDamageRanged;
            _attackRange = EngineConstants.Zombie_AttackRange;
            _defense = EngineConstants.Zombie_Defense;
            _speed = EngineConstants.Zombie_Speed;
            _lineOfSite = EngineConstants.Zombie_LineOfSite;
        }

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does
            mediator.GetMap(this);


            /*
            if enemy has a character on its vision map
               if zombie has arms remaining
                  ThrowArm
               if zombie is next to a character
                  Attack
               else
                  MoveToCharacter
            if zombie has no characters on its vision map
               if there is a dead zombie and a counter hits a certain limit
                  Raise Soul
               else
                  MoveToCenter
            else
               Hold
             */

            this.ThrowArm(mediator, this, mediator.GetCharacter(0,0));
            this.RaiseSoul(mediator, this, mediator.GetCharacter(0, 0));

        }
       
        public void ThrowArm(IMediator mediator, ICharacter character, ICharacter target)
        {
            mediator.ThrowArm(mediator, this, target);
        }

        public void RaiseSoul(IMediator mediator, ICharacter character, ICharacter target)
        {
            mediator.RaiseSoul(mediator, character, target);
        }
    }
}
