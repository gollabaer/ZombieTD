using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Priest : Character, IPriest
    {
        public Priest()
            : base()
        {
            _health = EngineConstants.Priest_Health;
            _attackDamageMelee = EngineConstants.Priest_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Priest_AttackDamageRanged;
            _attackRange = EngineConstants.Priest_AttackRange;
            _defense = EngineConstants.Priest_Defense;
            _speed = EngineConstants.Priest_Speed;
            _lineOfSite = EngineConstants.Priest_LineOfSite;
        }

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does
            mediator.GetMap(this);

            /*
            if character has an enemy on its vision map
               if the enemy is in the characters ranged attack range
                  ThrowHolyWater
               if character is next to an enemy
                  Attack
               else
                  MoveToEnemy
            else
               Hold
             */
        }

        public void ThrowHolyWater(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }
    }
}
