using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Pit : Character, IPit
    {
        public Pit(int x, int y)
            : base(x,y)
        {
            _health = EngineConstants.Pit_Health;
            _attackDamageMelee = EngineConstants.Pit_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Pit_AttackDamageRanged;
            _attackRange = EngineConstants.Pit_AttackRange;
            _defense = EngineConstants.Pit_Defense;
            _speed = EngineConstants.Pit_Speed;
            _lineOfSite = EngineConstants.Pit_LineOfSite;
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
