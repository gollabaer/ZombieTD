using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public interface IOrder
    {
        SpawnType? Type {get; set;}
        int X { get; set; }
        int Y { get; set; }
    }
}
