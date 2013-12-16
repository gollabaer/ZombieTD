using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace ZombieTD
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class ZombieTDGame : Microsoft.Xna.Framework.Game
    {
        //Graphics
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Game Mediator
        IMediator mediator;

        //Random Generator
        Random rnd = new Random();

        //FPS Setup
        SpriteFont _spr_font;
        int _total_frames = 0;
        float _elapsed_time = 0.0f;
        int _fps = 0;

        //Used to gather mouse input
        MouseInputActionDirector actionDirector;
        MouseInputMenuDirector menuDirector;

        //Used to hold mouse position
        Tuple<Vector2, SpawnType?> _mouseInputs;
       
        public ZombieTDGame()
        {
            //Initialize Graphics
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = EngineConstants.ScreenWidth;
            graphics.PreferredBackBufferHeight = EngineConstants.ScreenHeight;

            //Full Screen 
            graphics.IsFullScreen = EngineConstants.FullScreen;


            //Disable Frame Rate
            if (EngineConstants.DisableFrameRate)
            {
                graphics.SynchronizeWithVerticalRetrace = false;
                this.IsFixedTimeStep = false;
                graphics.ApplyChanges();
            }

            //Start Loggin
            if(EngineConstants.IsLogging)
                Logger.StartLogger();

            //Mouse Settings
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Create an instance of our mediator class
            mediator = new GameMediator(GameState.SplashScreen);

            //Create an instance of our Mouse Input Directors
            actionDirector = new MouseInputActionDirector(mediator);
            menuDirector = new MouseInputMenuDirector(mediator);
           
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Load Font for FPS, MouseXY, And Ticks
            _spr_font = Content.Load<SpriteFont>("GameEngine"); 

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //The mediator loads all of its childrens content
            mediator.LoadContent(Content, spriteBatch, GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Used to calculate FPS
            _elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // 1 Second has passed
            if (_elapsed_time >= 1000.0f)
            {
                _fps = _total_frames;
                _total_frames = 0;
                _elapsed_time = 0;
            }

            switch (GameMediator._gameState)
            {
                case GameState.GameRunning:
                    _mouseInputs = actionDirector.ProcessInput(Mouse.GetState());
                    break;
                case GameState.GameOver:
                case GameState.HelpMenu:
                case GameState.SplashScreen:
                    _mouseInputs = new Tuple<Vector2, SpawnType?>(menuDirector.ProcessInput(Mouse.GetState()), null);
                     break;
                case GameState.GameReset:
                     ResetGame();
                     break;
                case GameState.GameExit:
                    this.Exit();
                    break;
            }

            //Update the mediator and pass in the mouse xy and selected spawn type
            mediator.Tick(_mouseInputs);

            base.Update(gameTime);
        }

        private void ResetGame()
        {
            Initialize();
            GameMediator._gameState = GameState.GameRunning;
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _total_frames++;

            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            mediator.Draw(spriteBatch);

            if(EngineConstants.showFPS)
                spriteBatch.DrawString(_spr_font, string.Format("FPS={0}", _fps),
                    new Vector2(EngineConstants.FPSX, EngineConstants.FPSY), Color.White);
            if(EngineConstants.ShowTicks)
                spriteBatch.DrawString(_spr_font, string.Format("Ticks={0}", GameMediator.numberofTicks),
                    new Vector2(EngineConstants.TicksX, EngineConstants.TicksY), Color.White);
            if (EngineConstants.ShowMouseXY)
                spriteBatch.DrawString(_spr_font, string.Format("(X:{0}, Y:{1})", (int)_mouseInputs.Item1.X, (int)_mouseInputs.Item1.Y),
                    new Vector2(EngineConstants.MouseX, EngineConstants.MouseY), Color.White);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
