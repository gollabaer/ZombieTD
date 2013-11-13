using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class EnemyWaveGenerator
    {
        List<Tile> _entryPoints;
        List<Tile> _usedPoints;
        IMediator _mediator;
        Random _rnd;
        int count = 0;
     
        public EnemyWaveGenerator(IMediator mediator)
        {
            _usedPoints = new List<Tile>();
            _mediator = mediator;
            _rnd = new Random();
        }

        public void SetEnrtyPoints(List<Tile> entryPoints)
        {
            _entryPoints = entryPoints;
        }

        public void IssueOrders()
        {
            if (_mediator.GetScore().GetNumberOfZombies() < EngineConstants.MaxNumberOfSpawns)
            {
                if (count == EngineConstants.NumberOfFramesBeforeOrder)
                {
                    if (_entryPoints.Count == 0)
                    {
                        foreach (Tile usedTile in _usedPoints)
                        {
                            _entryPoints.Add(usedTile);
                        }

                        _usedPoints.Clear();
                    }

                    BaseOrder order = new BaseOrder();
                    int r = _rnd.Next(_entryPoints.Count);
                    Tile tile = (Tile)_entryPoints[r];

                    _usedPoints.Add(tile);
                    _entryPoints.Remove(tile);

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
}
