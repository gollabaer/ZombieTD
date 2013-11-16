using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public interface ICharacter : IGameElement
    {
        bool TakeDamage(int damageAmount);

        int getLineOfSight();
        SpawnType getSpawnType();
    }
}
