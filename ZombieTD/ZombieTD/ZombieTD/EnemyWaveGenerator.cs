using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ZombieTD
{
    public class EnemyWaveGenerator : Attribute
    {
        List<Tile> _entryPoints;
        List<Tile> _usedPoints;
        IMediator _mediator;
        Random _rnd;
        int count = 0;
        public IEnumerable<SpawnType> _legalSpawnTypes;

        //Used to make it harder
        int maxSpawns = EngineConstants.MaxNumberOfSpawns;
        int timeBeforeSpawn = EngineConstants.NumberOfFramesBeforeOrder;
    
        public EnemyWaveGenerator(IMediator mediator)
        {
            _usedPoints = new List<Tile>();
            _mediator = mediator;
            _rnd = new Random();
            _legalSpawnTypes = FilterEnumWithAttributeOf<SpawnType, EnemyWaveGenerator>();

        }

        public EnemyWaveGenerator()
        {

        }

        public void SetEnrtyPoints(List<Tile> entryPoints)
        {
            _entryPoints = entryPoints;
        }

        public void IssueOrders()
        {
            if (GameMediator.numberofTicks % EngineConstants.NumberOfTicksBeforeTimeIncrease == 0  && timeBeforeSpawn > EngineConstants.MimimumSpawnFrame)
            {
                timeBeforeSpawn = timeBeforeSpawn - (int)(timeBeforeSpawn * EngineConstants.PercentageIncreaseFrames);
            }

            if (GameMediator.numberofTicks % EngineConstants.NumberOfTicksBeforeSpawnIncrease == 0 && maxSpawns < EngineConstants.TotalSpawnLimit)
            {
                maxSpawns = maxSpawns + (int)(maxSpawns * EngineConstants.PercentageIncreaseSpawn);
            }


            if (_mediator.GetScore().GetNumberOfZombies() < maxSpawns)
            {
                if (GameMediator.numberofTicks % (ulong)timeBeforeSpawn == 0)
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

                    int r2 = _rnd.Next( _legalSpawnTypes.Count<SpawnType>());
                    order.Type = _legalSpawnTypes.ElementAt(r2);


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

        //http://tiredblogger.wordpress.com/2009/07/09/filtering-an-enum-by-attribute/
        public static IEnumerable<TEnum> FilterEnumWithAttributeOf<TEnum, TAttribute>()
            where TEnum : struct
            where TAttribute : class
        {
            foreach (var field in
                typeof(TEnum).GetFields(BindingFlags.GetField |
                                        BindingFlags.Public |
                                        BindingFlags.Static))
            {

                if (field.GetCustomAttributes(typeof(TAttribute), false).Length > 0)
                    yield return (TEnum)field.GetValue(null);
            }
        }
    }
}
