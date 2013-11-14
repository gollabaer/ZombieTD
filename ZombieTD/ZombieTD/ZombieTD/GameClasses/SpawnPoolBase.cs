using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public class SpawnPoolBase : ISpawnPool
    {
        IMediator _mediator;
        GameElementFactory _elementFactory;
        Queue<IOrder> _orderQueue;
        protected Queue<IGameElement> _spawnQueue;

        public SpawnPoolBase(IMediator mediator)
        {
            _mediator = mediator;
            _elementFactory = new GameElementFactory(_mediator);
            _orderQueue = new Queue<IOrder>();
            _spawnQueue = new Queue<IGameElement>();
        }

        public virtual void AcceptOrder(IOrder order)
        {
            _orderQueue.Enqueue(order);
        }

        public virtual void ProcessOrder()
        {
            if (_orderQueue.Count != 0)
            {
                IOrder order = _orderQueue.Dequeue();
                IGameElement spawn; 

                //Process Order
                switch (order.Type)
                {
                    case SpawnType.Zombie: spawn = _elementFactory.MakeZombie(order.X, order.Y); break;
                    case SpawnType.FlyingZombie: spawn = _elementFactory.MakeFlyingZombie(order.X, order.Y); break;
                    case SpawnType.ZombieDog: spawn = _elementFactory.MakeZombieDog(order.X, order.Y); break;
                    case SpawnType.Priest: spawn = _elementFactory.MakePriest(order.X, order.Y); break;
                    case SpawnType.RedNeck: spawn = _elementFactory.MakeRedneck(order.X, order.Y); break;
                    case SpawnType.Sheriff: spawn = _elementFactory.MakeSheriff(order.X, order.Y); break;
                    case SpawnType.Hay: spawn = _elementFactory.MakeHay(order.X, order.Y); break;
                    case SpawnType.Pit: spawn = _elementFactory.MakePit(order.X, order.Y); break;
                    case SpawnType.Car: spawn = _elementFactory.MakeCar(order.X, order.Y); break;
                    default: spawn = null;
                             Logger.Log(Logger.Log_Type.ERROR, "Invalid spawn type in orderQueue"); break;
                }

                //Set Direction
                if (spawn.GetX() == 0)
                    spawn.GetTexture().setRotation(EngineConstants.Right);
                else if (spawn.GetX() == 1248)
                    spawn.GetTexture().setRotation(EngineConstants.Left);
                else if (spawn.GetY() == 0)
                    spawn.GetTexture().setRotation(EngineConstants.Down);
                else if (spawn.GetY() == 672)
                    spawn.GetTexture().setRotation(EngineConstants.Up);

                _spawnQueue.Enqueue(spawn);
            }
        }


        public virtual void SpawnElements(IMediator mediator)
        {
            if (_spawnQueue.Count != 0)
            {
                Tile tile = mediator.GetTileByXY(_spawnQueue.Peek().GetX(), _spawnQueue.Peek().GetY());

                if (!tile.HasCharacters())
                {
                    IGameElement spawn = _spawnQueue.Dequeue();
                    spawn.RegisterWithMediator(mediator, spawn);
                }
            }
        }

        public virtual void ClearQueues()
        {
            _orderQueue.Clear();
            _spawnQueue.Clear();
        }
    }
}
