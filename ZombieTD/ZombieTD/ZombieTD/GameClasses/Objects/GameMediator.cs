using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

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
        private IEffect _characterSelectionEffect;
        private ISound _bgMusic;
        private SplashScreen _splashScreen;
        private GameOverScreen _gameOverScreen;
        private HelpMenuScreen _helpMenuScreen;

        public static GameState _gameState;
        public static ulong numberofTicks = 0;
        public static Tuple<Vector2, SpawnType?> _mouseInputs;
        public static bool isRunning;
        #endregion

        #region Constructors
        public GameMediator(GameState gameState)
        {
            //Set the Game state
            _gameState = gameState;

            //Create Game Objects
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
            _characterSelectionEffect = new CharacterSelectionEffect();

            //Create State Objects
            _gameOverScreen = new GameOverScreen(this);
            _splashScreen = new SplashScreen(this);
            _helpMenuScreen = new HelpMenuScreen(this);

            //Set running flag
            GameMediator.isRunning = true;
        }
        #endregion

        #region Content Loading
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
                //Load the asset managers
                LoadAssets(content);

                //Load The content for other game elements from the asset managers
                _fogEffect.LoadContent(this);
                _tileSelectionEffect.LoadContent(this);
                _characterSelectionEffect.LoadContent(this);
                _menu.LoadContent(content);
                _score.LoadContent(content);

                //Load State Objects
                _splashScreen.LoadContent(content);
                _gameOverScreen.LoadContent(content);
                _helpMenuScreen.LoadContent(content);

                //Map has to load before the objects that require it 
                _map = Map.LoadMap(this);
               
                //Require Map Parts
                _waveGenerator.SetEnrtyPoints(_map.EntryPoints);
                _base.SetBaseTiles(_map.Base);

                //Set the base sound
                _base.SetSound(this.GetAsset<SoundType,ISound>(SoundType.BaseAttack));

                //Set the Background Music
                _bgMusic = GetAsset<MusicType, ISound>(MusicType.TBG);
                this.StartMusic();

                Logger.Log(Logger.Log_Type.INFO, "The Game Has Been Loaded");
               
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Log_Type.ERROR, "Error Loading Assets " + ex.ToString());
                return false;
            }
        }
        #endregion

        #region Mediator Methods
        public void Draw(SpriteBatch spritebatch)
        {
            switch (_gameState)
            {
                case GameState.SplashScreen:
                    #region Game State (SplashScreen)
                    _splashScreen.Draw(_spriteBatch);
                    _fogEffect.Draw(_spriteBatch);
                    #endregion
                    break;
                case GameState.HelpMenu:
                    #region Game State (HelpScreen)
                    _helpMenuScreen.Draw(_spriteBatch);
                    _fogEffect.Draw(_spriteBatch);
                    #endregion
                    break;
                case GameState.GameRunning:
                    #region Game State (Game)
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
                    _characterSelectionEffect.Draw(_spriteBatch);
                    _score.Draw(_spriteBatch);
                    #endregion
                    break;
                case GameState.GameOver:
                    #region Game State (GameOver)
                    _gameOverScreen.Draw(_spriteBatch);
                    _score.DrawGameOver(_spriteBatch);
                    _fogEffect.Draw(_spriteBatch);
                    #endregion
                    break;
            }
        }

        public void Tick(Tuple<Vector2,SpawnType?> mouseInputs)
        {
            switch (_gameState)
            {
                case GameState.SplashScreen:
                    #region Game State (SplashScreen)
                    _fogEffect.update();
                    #endregion
                    break;
                case GameState.HelpMenu:
                    #region Game State (HelpScreen)
                    _fogEffect.update();
                    #endregion
                    break;
                case GameState.GameRunning:
                    #region Game State (Game)
                    //The Game Continues
                    if (GetTownhallHealth() > 0)
                    {
                        //Set mouse xy
                        _mouseInputs = mouseInputs;

                        //Take Turn
                        _waveGenerator.IssueOrders();
                        _badGuySpawnPool.ProcessOrder();
                        _goodGuySpawnPool.ProcessOrder();
                        _goodGuySpawnPool.SpawnElements(this);
                        _badGuySpawnPool.SpawnElements(this);


                        //UpdateEffects
                        _tileSelectionEffect.update();
                        _fogEffect.update();
                        _characterSelectionEffect.update();

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
                    }
                    else
                    {
                        //The Game Is Over
                        if (GameMediator.isRunning)
                            Logger.Log(Logger.Log_Type.INFO, "The Game Has Ended");

                        GameMediator.isRunning = false;
                        _score.StopTime();

                        _gameState = GameState.GameOver;
                    }

                    #endregion
                    break;
                case GameState.GameOver:
                    #region Game State (GameOver)
                    _fogEffect.update();
                    #endregion
                    break;
            }

            //Prevent Exception
            if (numberofTicks == ulong.MaxValue)
                numberofTicks = 0;
            else
                numberofTicks++;
        }

        public void StartMusic()
        {
            //Start Music
            _bgMusic.Play(.25f, 0f, 0f, true);
        }

        public I GetAsset<T, I>(T enumItem) where I : ICloneable
        {
            if (typeof(I) == typeof(ISound)) //if I is a sound.
                return _soundAssetManager.GetAsset<T, I>(enumItem);
            if (typeof(I) == typeof(ITexture))//if I is a texture
                return _textureAssetManager.GetAsset<T, I>(enumItem);

            Logger.Log(Logger.Log_Type.ERROR, ("Cannot get Asset of Type" + Type.GetType(typeof(I).Name).Name));
            throw new NotImplementedException("Cannot get Asset of Type" + Type.GetType(typeof(I).Name).Name);
        }

        public Tile GetTileByXY(int x, int y)
        {
            return _map.GetTileByXY(x, y);
        }

        public Score GetScore()
        {
            return this._score;
        }

        public void ReportDeath(IGameElement element)
        {
            if (element is IZombie ||
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

        public bool AttackCharacter(int damage, ICharacter target)
        {
            return target.TakeDamage(damage);
        }

        #endregion

        #region Townhall Methods
        public int GetTownhallHealth()
        {
            return _base.GetTownhallHealth();
        }

        public bool AttackTownHall(ICharacter character)
        {
            return _base.TakeDamage(((Character)character)._attackDamageMelee);
        }
        #endregion

        #region Map Methods
        public Map GetMapByLineOfSight(ICharacter character)
        {
            return _map.GetMapByLineOfSight(character.getLineOfSight(),
                                            character.GetX(),
                                            character.GetY());
        }
        #endregion

        #region SpawnPools
        public void AcceptOrder(IOrder order, OrderFor orderFor)
        {
            switch (orderFor)
            {
                case OrderFor.Player: _goodGuySpawnPool.AcceptOrder(order); break;
                case OrderFor.Enemy: _badGuySpawnPool.AcceptOrder(order); break;
            }   
        }
        #endregion

        #region Unused Methods
        public int GetX()
        {
            throw new NotImplementedException();
        }

        public int GetY()
        {
            throw new NotImplementedException();
        }

        public ITexture GetTexture()
        {
            throw new NotImplementedException();
        }

        public void TakeTurn(IMediator mediator)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
