using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{
    public class GameMediator : IMediator
    {
        #region XnaSpecific
        private SpriteBatch _spriteBatch;
        private ContentManager _content;

        #endregion


        #region LogicSpecific
        private Map _map;
        private List<IGameElement> _gameElements = new List<IGameElement>();
        private ISpawnPool _goodGuySpawnPool;
        private ISpawnPool _badGuySpawnPool;
        private IAssetManager _textureAssetManager;
        private IAssetManager _soundAssetManager;
        private Menu _menu;
        private Score _score;
        





        #endregion

        public GameMediator()
        {
            #region Init Logic
            _goodGuySpawnPool = new PlayerSpawnPool();
            _badGuySpawnPool = new EnemySpawnPool();
            _textureAssetManager = new TextureAssetManager();
            _soundAssetManager = new SoundAssetManager();
            _menu = new Menu();
            _score = new Score();


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
        public void LoadAssets(ContentManager content)
        {
                _textureAssetManager.LoadAssets(content);
                _soundAssetManager.LoadAssets(content);
        }



        public bool LoadContent(ContentManager content, SpriteBatch spritebatch)
        {
            _spriteBatch = spritebatch;
            _content = content;
            
            try
            {
                this._spriteBatch = spritebatch;
                LoadAssets(content);
                _menu.LoadContent();
                _score.LoadContent();
                _map = Map.LoadMap(this);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Log_Type.ERROR, "Error Loading Assets");
                return false;
            }

        }

        public void Draw(SpriteBatch spritebatch)
        {
            

            _map.Draw(spritebatch);
            //Draw The Elements
           
            Parallel.ForEach(_gameElements, element =>
            {
                //To Do Add Lock
               // element.Draw(_spriteBatch);
            });

            _menu.Draw(spritebatch);
            _score.Draw(spritebatch);

           
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
            //throw new NotImplementedException();
        }


        public I GetAsset<T, I>(T enumItem)
        {

            if(typeof(I) == typeof(ISound)) //if T is a sound.
                return _soundAssetManager.GetAsset<T, I>(enumItem);
            if (typeof(I) == typeof(ITexture))//if T is a texture
                return _textureAssetManager.GetAsset<T, I>(enumItem);


            throw new NotImplementedException("Cannot get Asset of Type" + Type.GetType(typeof(I).Name).Name);
        }
    }
}
