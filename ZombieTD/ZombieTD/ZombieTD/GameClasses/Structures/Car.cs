using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class Car : Character,  ICar
    {
        public Car(int x, int y)
            : base(x,y)
        {
            _health = EngineConstants.Car_Health;
            _attackDamageMelee = EngineConstants.Car_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Car_AttackDamageRanged;
            _attackRange = EngineConstants.Car_AttackRange;
            _defense = EngineConstants.Car_Defense;
            _speed = EngineConstants.Car_Speed;
            _lineOfSite = EngineConstants.Car_LineOfSite;
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
