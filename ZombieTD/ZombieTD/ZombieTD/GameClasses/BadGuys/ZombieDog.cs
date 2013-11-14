using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class ZombieDog : Character, IZombieDog
    {
        public ZombieDog()
            : base()
        {
            _health = EngineConstants.ZombieDog_Health;
            _attackDamageMelee = EngineConstants.ZombieDog_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.ZombieDog_AttackDamageRanged;
            _attackRange = EngineConstants.ZombieDog_AttackRange;
            _defense = EngineConstants.ZombieDog_Defense;
            _speed = EngineConstants.ZombieDog_Speed;
            _lineOfSite = EngineConstants.ZombieDog_LineOfSite;
        }


        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does
            mediator.GetMap(this);

            /*
            if enemy has a character on its vision map
               if character hasnt been hit by acid
                  SpitAcid
               if dog is next to a character
                  Attack
               else
                  MoveToCharacter
            if zombie has no characters on its vision map
               MoveToCenter
            else
               Hold
             */
        }

        public void SpitAcid(IMediator mediator, ICharacter character, ICharacter target)
        {
            mediator.SpitAcid(mediator, this, target);
        }
    }
}
