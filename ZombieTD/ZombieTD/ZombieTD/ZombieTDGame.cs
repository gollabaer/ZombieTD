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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        IMediator mediator;
        Random rnd = new Random();
        Tuple<int, int> _mouseXY;

        //FPS
        SpriteFont _spr_font;
        int _total_frames = 0;
        float _elapsed_time = 0.0f;
        int _fps = 0;

        //Mouse Input 
        MouseInputActionDirector inputDirector;
       
        public ZombieTDGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = EngineConstants.ScreenWidth;
            graphics.PreferredBackBufferHeight = EngineConstants.ScreenHeight;


            //Disable Frame Rate
            if (EngineConstants.DisableFrameRate)
            {
                graphics.SynchronizeWithVerticalRetrace = false;
                this.IsFixedTimeStep = false;
                graphics.ApplyChanges();
            }

            if(EngineConstants.IsLogging)
                Logger.StartLogger();

            //Settings
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
            // TODO: Add your initialization logic here

            //Create an instance of our mediator class
            mediator = new GameMediator();
            inputDirector = new MouseInputActionDirector(mediator);
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spr_font = Content.Load<SpriteFont>("GameEngine"); 


            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            mediator.LoadContent(Content, spriteBatch);
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
            _elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
 
            // 1 Second has passed
            if (_elapsed_time >= 1000.0f)
            {
                _fps = _total_frames;
                _total_frames = 0;
                _elapsed_time = 0;
            }


            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //Mouse Input Method,  returns mouse xy
            _mouseXY = inputDirector.ProcessInput(Mouse.GetState());

            mediator.Tick(_mouseXY);
           
            base.Update(gameTime);
           
        }

     

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _total_frames++;

            GraphicsDevice.Clear(Color.CornflowerBlue);

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
                spriteBatch.DrawString(_spr_font, string.Format("(X:{0}, Y:{1})", _mouseXY.Item1, _mouseXY.Item2),
                    new Vector2(EngineConstants.MouseX, EngineConstants.MouseY), Color.White);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
