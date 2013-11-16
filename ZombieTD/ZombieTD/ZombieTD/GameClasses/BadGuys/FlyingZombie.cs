using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class FlyingZombie : Character, IFlyingZombie
    {
        public FlyingZombie(int x, int y)
            : base(x,y)
        {
            _health = EngineConstants.FlyingZombie_Health;
            _attackDamageMelee = EngineConstants.FlyingZombie_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.FlyingZombie_AttackDamageRanged;
            _attackRange = EngineConstants.FlyingZombie_AttackRange;
            _defense = EngineConstants.FlyingZombie_Defense;
            _speed = EngineConstants.FlyingZombie_Speed;
            _lineOfSite = EngineConstants.FlyingZombie_LineOfSite;


            //MapTileType kfkfkflfk = typeof(FlyingZombie).GetEnumFromSpawnType<MapTileType>();

            //string jjj = kfkfkflfk.ToString();
            //FlyingZombie zombie = new FlyingZombie();
            //float j = 5.0f;


            //int i = 0;

        }

        public FlyingZombie()
        {

        }

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
            //mediator.GetMap(this);

            /*
            if enemy has a character on its vision map
               if character is on the roof
                  PrioritizeAttack
               else if flying zombie is next to character
                  Attack
               else
                  MoveToCharacter
            if zombie has no characters on its vision map
               MoveToCenter
            else
               Hold
             */
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
