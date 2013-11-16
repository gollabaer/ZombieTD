using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class EnemyTypeAttribute : Attribute
    {
            private SpawnType _spawnType;

            public SpawnType SpawnType { get { return _spawnType; } }

            public EnemyTypeAttribute(SpawnType spawnType)
            {
                this._spawnType = spawnType;
            }
    }
}

