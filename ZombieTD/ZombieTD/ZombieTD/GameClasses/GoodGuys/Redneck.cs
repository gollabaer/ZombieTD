using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Redneck : Character, IRedneck
    {
        public Redneck(int x, int y)
            : base(x,y)
        {
            _health = EngineConstants.Redneck_Health;
            _attackDamageMelee = EngineConstants.Redneck_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Redneck_AttackDamageRanged;
            _attackRange = EngineConstants.Redneck_AttackRange;
            _defense = EngineConstants.Redneck_Defense;
            _speed = EngineConstants.Redneck_Speed;
            _lineOfSite = EngineConstants.Redneck_LineOfSite;
            _walkableTiles = FilterEnumWithAttributeOf<MapTileType, Redneck>();
           // var g = SpawnType.RedNeck.GetEnumFromSpawnType<MapTileType>();

            int i = 0;
        }

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //Game logic for what a zombie does
            //mediator.GetMap(this);

            /*
            if character has an enemy on its vision map
               if character is next to a zombie
                   if zombie has an arm
                      CutOffArm
                   else 
                      Attack
               else
                  MoveToEnemy
            else
               Hold
             */
        }

        public void CutOffArm(IMediator mediator, ICharacter charater, ICharacter target)
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
