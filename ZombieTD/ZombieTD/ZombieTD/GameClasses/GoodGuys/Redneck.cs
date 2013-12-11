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
            _maxHealth = EngineConstants.Redneck_Health;
            _health = EngineConstants.Redneck_Health;
            _attackDamageMelee = EngineConstants.Redneck_AttackDamageMelee;
            _attackDamageRanged = EngineConstants.Redneck_AttackDamageRanged;
            _attackRange = EngineConstants.Redneck_AttackRange;
            _defense = EngineConstants.Redneck_Defense;
            _speed = EngineConstants.Redneck_Speed;
            _lineOfSite = EngineConstants.Redneck_LineOfSite;
            _legalMovmentTiles = FilterEnumWithAttributeOf<MapTileType, Redneck>();
           // var g = SpawnType.RedNeck.GetEnumFromSpawnType<MapTileType>();

            int i = 0;
        }

        public Redneck() { }

        public override void TakeTurn(IMediator mediator)
        {
            base.TakeTurn(mediator);
        }

        //Special 1
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

            if (IsPlayerNextToMe())
            {
                _currentAction = CurrentAction.Attack;
            }
            else if (IsPlayerNearMe())
            {
                _currentAction = CurrentAction.Move;
            }
            else
            {
                _currentAction = CurrentAction.None;
            }
        }
    }
}
