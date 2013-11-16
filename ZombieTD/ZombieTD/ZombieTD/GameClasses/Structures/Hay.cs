using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class Hay : Character, IHay
    {
        public Hay(int x, int y)
            : base(x,y)
        {
            _health = EngineConstants.Hay_Health;
            _attackDamageMelee = EngineConstants.Hay_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Hay_AttackDamageRanged;
            _attackRange = EngineConstants.Hay_AttackRange;
            _defense = EngineConstants.Hay_Defense;
            _speed = EngineConstants.Hay_Speed;
            _lineOfSite = EngineConstants.Hay_LineOfSite;
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
