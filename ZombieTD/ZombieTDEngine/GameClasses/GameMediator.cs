using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTDEngine
{
    public class GameMediator : IMediator
    {
        private Map _map;
        private List<IGameElement> _gameElements = new List<IGameElement>();

        public GameMediator()
        {
            IGameElement zombie = new Zombie();
            IGameElement flyingZombie = new FlyingZombie();
            IGameElement zombieDog = new ZombieDog();

            IGameElement redneck = new Redneck();
            IGameElement sheriff = new Sheriff();
            IGameElement priest = new Priest();






            zombie.RegisterWithMediator(this, zombie);
            flyingZombie.RegisterWithMediator(this, flyingZombie);
            zombieDog.RegisterWithMediator(this, zombieDog);

            redneck.RegisterWithMediator(this, redneck);
            sheriff.RegisterWithMediator(this, sheriff);
            priest.RegisterWithMediator(this, priest);

            //_enemies.Add(zombie);




            
        }

        public void DrawElements()
        {

        }

        public void Tick()
        {
            foreach (IGameElement elements in _gameElements)
            {
                elements.TakeTurn(this);
            }

        }

        //Mediator Elements
        public Map GetMap(ICharacter character)
        {

            return null;
        }

        public ICharacter GetCharacter(int x, int y)
        {
            return null;
        }


    

        //IGameElementMethods
        public void RegisterWithMediator(IMediator mediator, IGameElement element)
        {
            this._gameElements.Add(element);
        }

        public void TakeTurn(IMediator mediator)
        {
            //Implemented because of interface not needed.
        }


        //Zombie Methods
        public void ThrowArm(IMediator mediator, ICharacter charater, ICharacter target)
        {
            int i = 1;
        }

        public void RaiseSoul(IMediator mediator, ICharacter charater, ICharacter target)
        {
        }


        //Zombie Dog Methods
        public void SpitAcid(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }


        //Sheriff Methods
        public void FireGun(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }


        //Priest Methods
        public void ThrowHolyWater(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }



        //Redneck Methods
        public void CutOffArm(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }



        //Universal Methods
        public void Attack(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }

       












    }
}
