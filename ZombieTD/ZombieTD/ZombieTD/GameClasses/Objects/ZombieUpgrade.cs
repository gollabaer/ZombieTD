using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class ZombieHealthUpgrade : BaseUpgrade
    {
        public ZombieHealthUpgrade(string upgradeName) : base(upgradeName)
        {
            _ticksTillUpgrade = EngineConstants.HealthUpgradeTicks;
        }

        public override void PreformUpgrade(List<IGameElement> elementsToUpgrade)
        {
            foreach (Character character in elementsToUpgrade)
            {
                if (character is IZombie || character is IZombieDog || character is IFlyingZombie)
                {
                    character._health += 10;
                    character._maxHealth += 10;
                }
            }
        }
    }

    public class ZombieSpeedUpgrade : BaseUpgrade
    {
        public ZombieSpeedUpgrade(string upgradeName)
            : base(upgradeName)
        {
            _ticksTillUpgrade = EngineConstants.SpeedUpgradeTicks;
        }

        public override void PreformUpgrade(List<IGameElement> elementsToUpgrade)
        {
            foreach (Character character in elementsToUpgrade)
            {
                if (character is IZombie || character is IZombieDog || character is IFlyingZombie)
                {
                    if (character._speed == 1)
                    {
                        character._speed = character._speed + 1;
                    }
                    else if (character._speed == 2)
                    {
                        character._speed = character._speed + 2;
                    }
                    else if (character._speed == 4)
                    {
                        character._speed = character._speed + 4;
                    }
                }
            }
        }
    }

    public class ZombieAttackUpgrade : BaseUpgrade
    {
        public ZombieAttackUpgrade(string upgradeName) : base(upgradeName)
        {
            _ticksTillUpgrade = EngineConstants.AttackUpgradeTicks;
        }

        public override void PreformUpgrade(List<IGameElement> elementsToUpgrade)
        {
            foreach (Character character in elementsToUpgrade)
            {
                if (character is IZombie || character is IZombieDog || character is IFlyingZombie)
                {
                    character._attackDamageMelee += 4;
                    character._attackDamageRanged += 4;
                }
            }
        }
    }
}
