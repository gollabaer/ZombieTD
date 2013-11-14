using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    class Car : Character,  ICar
    {
        public Car()
            : base()
        {
            _health = EngineConstants.Car_Health;
            _attackDamageMelee = EngineConstants.Car_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Car_AttackDamageRanged;
            _attackRange = EngineConstants.Car_AttackRange;
            _defense = EngineConstants.Car_Defense;
            _speed = EngineConstants.Car_Speed;
            _lineOfSite = EngineConstants.Car_LineOfSite;
        }
    }
}
