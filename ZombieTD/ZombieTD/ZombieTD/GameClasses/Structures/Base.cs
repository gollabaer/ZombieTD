using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class Base : Character, IBase
    {
        List<Tile> _baseTiles;
        ISound _sound;

        public Base(int x, int y)
            : base(x,y)
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

        public override bool TakeDamage(int damage)
        {
            
            this._health -= damage;

            if (this._health <= 0)
                return true;
            else
            {
         
                    _sound.Play(.05f, 0f, 0f, false);
         
                return false;
            }
        }

        public void SetSound(ISound sound)
        {
            _sound = sound;
        }
    }
}
        
