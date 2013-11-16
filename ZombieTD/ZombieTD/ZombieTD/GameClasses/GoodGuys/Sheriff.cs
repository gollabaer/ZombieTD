using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Sheriff : Character, ISheriff
    {
        public Sheriff(int x, int y)
            : base(x, y)
        {
            _health = EngineConstants.Sheriff_Health;
            _attackDamageMelee = EngineConstants.Sheriff_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Sheriff_AttackDamageRanged;
            _attackRange = EngineConstants.Sheriff_AttackRange;
            _defense = EngineConstants.Sheriff_Defense;
            _speed = EngineConstants.Sheriff_Speed;
            _lineOfSite = EngineConstants.Sheriff_LineOfSite;
            _legalMovmentTiles = FilterEnumWithAttributeOf<MapTileType, Sheriff>();
        }

        public Sheriff()
        {

        }

        public override void TakeTurn(IMediator mediator)
        {

            base.TakeTurn(mediator);
            //Game logic for what a zombie does
           // mediator.GetMap(this);

            /*
            if character has an enemy on its vision map
               if the enemy is in the characters ranged attack range
                  FireGun
               if character is next to an enemy
                  Attack
               else
                  MoveToEnemy
            else
               Hold
             */
            


            int i = 0;


        }

        public void FireGun(IMediator mediator, ICharacter character, ICharacter target)
        {

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
            
        }

        protected override void Attack()
        {
            throw new NotImplementedException();
        }

        protected override void ChooseAction()
        {
            base.ChooseAction();

            _currentAction = CurrentAction.Move;


        }
    }
}
