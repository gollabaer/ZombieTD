using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Pit : Character, IPit
    {
        public Pit()
            : base()
        {
            _health = EngineConstants.Pit_Health;
            _attackDamageMelee = EngineConstants.Pit_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Pit_AttackDamageRanged;
            _attackRange = EngineConstants.Pit_AttackRange;
            _defense = EngineConstants.Pit_Defense;
            _speed = EngineConstants.Pit_Speed;
            _lineOfSite = EngineConstants.Pit_LineOfSite;
        }
    }
}
