using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;

namespace ZombieTD
{
    public class GameMediator : IMediator
    {
        #region XnaSpecific
        private SpriteBatch _spriteBatch;

        #endregion


        #region LogicSpecific
        private Map _map;
        private List<IGameElement> _gameElements = new List<IGameElement>();
        private ISpawnPool _goodGuySpawnPool;
        private ISpawnPool _badGuySpawnPool;




        #endregion


        public GameMediator()
        {
            #region Init Logic
            _goodGuySpawnPool = new PlayerSpawnPool();
            _badGuySpawnPool = new EnemySpawnPool();


            #endregion

            //Test Code
            IGameElement zombie = new Zombie();
            IGameElement flyingZombie = new FlyingZombie();
            IGameElement zombieDog = new ZombieDog();

            IGameElement redneck = new Redneck();
            IGameElement sheriff = new Sheriff();
            IGameElement priest = new Priest();
            //Test code
            zombie.RegisterWithMediator(this, zombie);
            flyingZombie.RegisterWithMediator(this, flyingZombie);
            zombieDog.RegisterWithMediator(this, zombieDog);

            redneck.RegisterWithMediator(this, redneck);
            sheriff.RegisterWithMediator(this, sheriff);
            priest.RegisterWithMediator(this, priest);

            //_enemies.Add(zombie);

        }


        #region Engine Methods
        public bool LoadContent(SpriteBatch spritebatch)
        {
            try
            {
                this._spriteBatch = spritebatch;





                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public void Draw()
        {
            //Draw The Elements
            Parallel.ForEach(_gameElements, element =>
            {
                element.Draw();
            });
        }

        public void Tick()
        {
            //Take Turn
            _goodGuySpawnPool.SpawnElements((IMediator)this);
            _badGuySpawnPool.SpawnElements((IMediator)this);

            //Game Elements take turn
            Parallel.ForEach(_gameElements, element =>
            {
                lock(_gameElements) element.TakeTurn((IMediator)this);
            });

        }

        #endregion

        #region Mediator Methods
        public Map GetMap(ICharacter character)
        {

            return null;
        }

        public ICharacter GetCharacter(int x, int y)
        {
            return null;
        }

        public void RegisterWithMediator(IMediator mediator, IGameElement element)
        {
            this._gameElements.Add(element);
        }


        #endregion

        #region Zombie Methods
        public void ThrowArm(IMediator mediator, ICharacter charater, ICharacter target)
        {
            int i = 1;
        }
        
        public void RaiseSoul(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }
        #endregion

        #region Zombie Dog Methods
        public void SpitAcid(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }

        #endregion

        #region Sheriff Methods
        public void FireGun(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }
        #endregion

        #region Priest Methods
        public void ThrowHolyWater(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }
        #endregion

        #region Redneck Methods
        public void CutOffArm(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }
        #endregion

        #region Character Methods
        public void Attack(IMediator mediator, ICharacter charater, ICharacter target)
        {

        }
        #endregion














        public void TakeTurn(IMediator mediator)
        {
            throw new NotImplementedException();
        }
    }
}
