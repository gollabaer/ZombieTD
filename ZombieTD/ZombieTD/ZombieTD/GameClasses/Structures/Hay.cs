using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class Hay : Character, IHay
    {
        public Hay()
            : base()
        {
            _health = EngineConstants.Hay_Health;
            _attackDamageMelee = EngineConstants.Hay_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Hay_AttackDamageRanged;
            _attackRange = EngineConstants.Hay_AttackRange;
            _defense = EngineConstants.Hay_Defense;
            _speed = EngineConstants.Hay_Speed;
            _lineOfSite = EngineConstants.Hay_LineOfSite;
        }
    }
}
