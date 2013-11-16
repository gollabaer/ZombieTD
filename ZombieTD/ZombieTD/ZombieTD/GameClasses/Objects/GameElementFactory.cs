using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ZombieTD
{
    class GameElementFactory
    {
        private IMediator _mediator;

        public GameElementFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IGameElement MakeZombie(int x, int y)
        {
            Zombie zombie = new Zombie(x, y);
            zombie._xPos = x;
            zombie._yPos = y;
            zombie._texture = _mediator.GetAsset<CharacterTextureType, ITexture>(CharacterTextureType.Zombie);

            return zombie as IGameElement;
        }

        public IGameElement MakeZombieDog(int x, int y)
        {
            ZombieDog zombieDog = new ZombieDog(x, y);
            zombieDog._xPos = x;
            zombieDog._yPos = y;
            zombieDog._texture = _mediator.GetAsset<CharacterTextureType, ITexture>(CharacterTextureType.ZombieDog);

            return zombieDog as IGameElement;
        }

        public IGameElement MakeFlyingZombie(int x, int y)
        {
            FlyingZombie flyingZombie = new FlyingZombie(x, y);
            flyingZombie._xPos = x;
            flyingZombie._yPos = y;
            flyingZombie._texture = _mediator.GetAsset<CharacterTextureType, ITexture>(CharacterTextureType.FlyingZombie);

            return flyingZombie as IGameElement;
        }

        public IGameElement MakeRedneck(int x, int y)
        {
            Redneck redneck = new Redneck(x, y);
            redneck._xPos = x;
            redneck._yPos = y;
            redneck._texture = _mediator.GetAsset<CharacterTextureType, ITexture>(CharacterTextureType.RedNeck);

            return redneck as IGameElement;
        }

        public IGameElement MakeSheriff(int x, int y)
        {
            Sheriff sheriff = new Sheriff(x, y);
            sheriff._xPos = x;
            sheriff._yPos = y;
            sheriff._texture = _mediator.GetAsset<CharacterTextureType, ITexture>(CharacterTextureType.Sheriff);

            return sheriff as IGameElement;
        }

        public IGameElement MakePriest(int x, int y)
        {
            Priest priest = new Priest(x, y);
            priest._xPos = x;
            priest._yPos = y;
            priest._texture = _mediator.GetAsset<CharacterTextureType, ITexture>(CharacterTextureType.Priest);

            return priest as IGameElement;
        }

        public IGameElement MakeHay(int x, int y)
        {
            Hay hay = new Hay(x,y);
            hay._xPos = x;
            hay._yPos = y;
            hay._texture = _mediator.GetAsset<StructureTextureType, ITexture>(StructureTextureType.Hay);

            return hay as IGameElement;
        }

        public IGameElement MakeCar(int x, int y)
        {
            Car car = new Car(x, y);
            car._xPos = x;
            car._yPos = y;
            //This needs to be revisited to add both tiles
            car._texture = _mediator.GetAsset<StructureTextureType, ITexture>(StructureTextureType.CarFront);
            //car._texture = _mediator.GetAsset<StructureTextureType, ITexture>(StructureTextureType.CarBack);

            return car as IGameElement;
        }

        public IGameElement MakePit(int x, int y)
        {
            Pit pit = new Pit(x,y);
            pit._xPos = x;
            pit._yPos = y;
           
            pit._texture = _mediator.GetAsset<StructureTextureType, ITexture>(StructureTextureType.Pit);
            
            return pit as IGameElement;
        }
    }
}
