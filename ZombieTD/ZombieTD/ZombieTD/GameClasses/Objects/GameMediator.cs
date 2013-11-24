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
        Random _rnd = new Random();

        #endregion
       

        #region XnaSpecific
        private SpriteBatch _spriteBatch;
        private ContentManager _content;

        #endregion

        #region LogicSpecific
        private Map _map;
        private List<IGameElement> _gameElements = new List<IGameElement>();
        private List<IGameElement> _gamePitElements = new List<IGameElement>();

        private ISpawnPool _goodGuySpawnPool;
        private ISpawnPool _badGuySpawnPool;
        private IAssetManager _textureAssetManager;
        private IAssetManager _soundAssetManager;
        private IBase _base;
        private Menu _menu;
        private Score _score;
        private EnemyWaveGenerator _waveGenerator;
        private IEffect _fogEffect;
        private IEffect _tileSelectionEffect;
        private ISound _bgMusic;
        public static ulong numberofTicks = 0;
        public static Tuple<int, int> _mouseXY;
        public static bool isRunning;
        #endregion

        public GameMediator()
        {
            #region Init Logic
         
            _goodGuySpawnPool = new PlayerSpawnPool(this);
            _badGuySpawnPool = new EnemySpawnPool(this);
            _textureAssetManager = new TextureAssetManager();
            _soundAssetManager = new SoundAssetManager();
            _waveGenerator = new EnemyWaveGenerator(this);
            _base = new Base(0,0);
            _menu = new Menu(this);
            _score = new Score(this);
            _fogEffect = new FogEffect2();
            _tileSelectionEffect = new TileSelectionEffect();
            GameMediator.isRunning = true;
            #endregion
        }

        #region Engine Methods
       
        public bool LoadContent(ContentManager content, SpriteBatch spritebatch)
        {
            _spriteBatch = spritebatch;
            _content = content;
            
            try
            {
                //Load the asset managers
                LoadAssets(content);

                //Load The content for other game elements from the asset managers
                _fogEffect.LoadContent(this);
                _tileSelectionEffect.LoadContent(this);
                _menu.LoadContent(content);
                _score.LoadContent(content);

                //Map has to load before the objects that require it 
                _map = Map.LoadMap(this);
               
                //Require Map Parts
                _waveGenerator.SetEnrtyPoints(_map.EntryPoints);
                _base.SetBaseTiles(_map.Base);

                //Set the base sound
                _base.SetSound(this.GetAsset<SoundType,ISound>(SoundType.BaseAttack));

                //Start Music
                _bgMusic = GetAsset<MusicType, ISound>(MusicType.TBG);
                _bgMusic.Play(.25f, 0f, 0f, true);

                Logger.Log(Logger.Log_Type.INFO, "The Game Has Started");
               
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

            //Draw the Pits
            foreach (IGameElement element in _gamePitElements)
                element.Draw(_spriteBatch);

           //Draw each of the IGameElement in the game
            foreach (IGameElement element in _gameElements)
                element.Draw(_spriteBatch);
            
            

            //Draw any Effects
            _tileSelectionEffect.Draw(_spriteBatch);
            _fogEffect.Draw(_spriteBatch);

            //Draw The Menu
            _menu.Draw(_spriteBatch);
            _score.Draw(_spriteBatch);
        }

        public void Tick(Tuple<int,int> mouseXY)
        {
            //The Game Continues
            if (GetTownhallHealth() > 0)
            {
                //Set mouse xy
                _mouseXY = mouseXY;

                //Take Turn
                _waveGenerator.IssueOrders();
                _badGuySpawnPool.ProcessOrder();
                _goodGuySpawnPool.ProcessOrder();
                _goodGuySpawnPool.SpawnElements(this);
                _badGuySpawnPool.SpawnElements(this);


                //UpdateEffects
                _tileSelectionEffect.update();
                _fogEffect.update();

                //Remove all dead characters
                _gameElements.RemoveAll(x => x.GetDeadFlag());
                _gamePitElements.RemoveAll(x => x.GetDeadFlag());

                
#if DEBUG
                //Game Characters
                foreach (IGameElement element in _gameElements)
                {
                    element.TakeTurn(this);
                }
#else
                //Game Characters
                Parallel.ForEach(_gameElements, element =>
                {
                    lock (_gameElements) element.TakeTurn((IMediator)this);
                });

#endif

                //Pit Characters
                foreach (IGameElement element in _gamePitElements)
                {
                    element.TakeTurn(this);
                }

                //Prevent Exception
                if (numberofTicks == ulong.MaxValue)
                    numberofTicks = 0;
                else
                    numberofTicks++;
            }
            else
            {
                //The Game Is Over
                if(GameMediator.isRunning)
                    Logger.Log(Logger.Log_Type.INFO, "The Game Has Ended");

                GameMediator.isRunning = false;
                _score.StopTime();
            }
        }

        #endregion

        #region Mediator Methods
        public Map GetMapByLineOfSight(ICharacter character)
        {
            return _map.GetMapByLineOfSight(character.getLineOfSight(),
                                            character.GetX(),
                                            character.GetY());
        }

        public ICharacter GetCharacter(int x, int y)
        {
            return null;
        }

        public void RegisterWithMediator(IMediator mediator, IGameElement element)
        {

            if (element is IPit)
            {
                this._gamePitElements.Add(element);
            }
            else
            {
                this._gameElements.Add(element);
            }

            _map.GetTileByXY(element.GetX(), element.GetY()).AddElementToTile(element);
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
        public bool AttackCharacter(ICharacter charater, ICharacter target)
        {
            return target.TakeDamage(((Character)charater)._attackDamageMelee);
        }



        #endregion

        #region Townhall Methods
        public int GetTownhallHealth()
        {
            return _base.GetTownhallHealth();
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

        public void AcceptOrder(IOrder order, OrderFor orderFor)
        {
            switch (orderFor)
            {
                case OrderFor.Player: _goodGuySpawnPool.AcceptOrder(order); break;
                case OrderFor.Enemy: _badGuySpawnPool.AcceptOrder(order); break;
            }   
        }


        public Tile GetTileByXY(int x, int y)
        {
            return _map.GetTileByXY(x, y);
        }


        public int GetX()
        {
            throw new NotImplementedException();
        }

        public int GetY()
        {
            throw new NotImplementedException();
        }


        public Score GetScore()
        {
            return this._score;
        }

        public void ReportDeath(IGameElement element)
        {
            if(element is IZombie ||
               element is IZombieDog ||
               element is IFlyingZombie)
            {
                _score.SubtractEnemy();
                _score.AddKill();
            }
             
            else if (element is ISheriff ||
                     element is IRedneck ||
                     element is IPriest ||
                     element is IBase)
            {
                _score.SubtractPlayer();
                _score.AddKilled();
            }

            

            //_map.RemoveElementFromTile(element);
            //_gameElements.Remove(element);
            //element.SetDeadFlag();
        }


        public ITexture GetTexture()
        {
            throw new NotImplementedException();
        }


        public bool AttackTownHall(ICharacter character)
        {
            return _base.TakeDamage(((Character)character)._attackDamageMelee);
        }



        public bool AttackCharacter(int damage, ICharacter target)
        {
            return target.TakeDamage(damage);
        }
    }
}
