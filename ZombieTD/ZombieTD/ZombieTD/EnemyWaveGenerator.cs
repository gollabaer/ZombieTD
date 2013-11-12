using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class EnemyWaveGenerator
    {
        List<Tile> _entryPoints;
        IMediator _mediator;
        Random _rnd;
        int count = 0;
     
        public EnemyWaveGenerator(IMediator mediator, List<Tile> entryPoints)
        {
            _entryPoints = entryPoints;
            _mediator = mediator;
            _rnd = new Random();

        }

        public void IssueOrders()
        {
            if (count == 200)
            {
                BaseOrder order = new BaseOrder();
                int r = _rnd.Next(_entryPoints.Count);
                Tile tile = (Tile)_entryPoints[r];


                order.Type = SpawnType.Zombie;
                order.X = tile.Xpos;
                order.Y = tile.Ypos;
                _mediator.AcceptOrder(order as IOrder, OrderFor.Enemy);

                count = 0;
            }
            else
            {
                count++;
            }
        }
    }
}
