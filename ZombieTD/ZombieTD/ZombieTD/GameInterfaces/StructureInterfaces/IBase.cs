using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public interface IBase : IGameElement
    {
        int GetTownhallHealth();

        void SetBaseTiles(List<Tile> list);
        bool TakeDamage(int damage);
    }
}
