using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Base : Character, IBase
    {
        List<Tile> _baseTiles;


        public Base()
            : base()
        {
            _health = EngineConstants.Base_Health;
            _attackDamageMelee = EngineConstants.Base_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Base_AttackDamageRanged;
            _attackRange = EngineConstants.Base_AttackRange;
            _defense = EngineConstants.Base_Defense;
            _speed = EngineConstants.Base_Speed;
            _lineOfSite = EngineConstants.Base_LineOfSite;
        }

        public int GetTownhallHealth()
        {
            return base._health;
        }


        public void SetBaseTiles(List<Tile> baseTiles)
        {
            _baseTiles = baseTiles;
        }
    }
}
        
