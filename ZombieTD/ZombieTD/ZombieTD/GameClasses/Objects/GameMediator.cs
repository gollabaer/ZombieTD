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
        #region Test Vars
        int currentSound = 0;
        string[] sounds = Enum.GetNames(typeof(SoundType));

        #endregion


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
            _goodGuySpawnPool = new PlayerSpawnPool(this);
            _badGuySpawnPool = new EnemySpawnPool(this);
            _textureAssetManager = new TextureAssetManager();
            _soundAssetManager = new SoundAssetManager();
            _menu = new Menu();
            _score = new Score();
            #endregion
        }

        #region Engine Methods
       
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
                Logger.Log(Logger.Log_Type.ERROR, "Error Loading Assets " + ex.ToString());
                return false;
            }
        }

        public void LoadAssets(ContentManager content)
        {
            _textureAssetManager.LoadAssets(content);
            _soundAssetManager.LoadAssets(content);
        }

        /// <summary>
        /// The mediators draw method is used to draw
        /// the map, characters, menu, and score. Draw order
        /// within the method affects how the elements
        /// are layered.
        /// </summary>
        /// <param name="spritebatch">Use a sprite to draw a 2D bitmap directly to the screen.</param>
        public void Draw(SpriteBatch spritebatch)
        {
           //Draw the Game Map
            _map.Draw(spritebatch);
           //Draw each of the IGameElement in the game
            foreach (IGameElement element in _gameElements)
                element.Draw(_spriteBatch);
            //Draw any Effects


            //Draw The Menu
            _menu.Draw(spritebatch);
            _score.Draw(spritebatch);

           
        }

        public void Tick()
        {
            //Take Turn
            _goodGuySpawnPool.ProcessOrder();
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
            //Not Needed Though we could replace the tick method with this method
            //throw new NotImplementedException();
        }


        public I GetAsset<T, I>(T enumItem) where I : ICloneable
        {
            if(typeof(I) == typeof(ISound)) //if I is a sound.
                return _soundAssetManager.GetAsset<T, I>(enumItem);
            if (typeof(I) == typeof(ITexture))//if I is a texture
                return _textureAssetManager.GetAsset<T, I>(enumItem);

            Logger.Log(Logger.Log_Type.ERROR, ("Cannot get Asset of Type" + Type.GetType(typeof(I).Name).Name));
            throw new NotImplementedException("Cannot get Asset of Type" + Type.GetType(typeof(I).Name).Name);
        }



        #region TestDemoMethods

        public void MakeTestSound()
        {
            this.GetAsset<SoundType, ISound>((SoundType) Enum.Parse(typeof(SoundType), sounds[currentSound])).Play();

            if (currentSound == sounds.Length - 1)
                currentSound = 0;
            else
                currentSound++;
        }


        #endregion

        public void AcceptOrder(IOrder order)
        {
            _goodGuySpawnPool.AcceptOrder(order);
        }
    }
}
