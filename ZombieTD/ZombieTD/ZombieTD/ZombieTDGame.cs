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

        //Mouse Input 
        MouseState mouseStateCurrent, mouseStatePrevious;
       
       
        public ZombieTDGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = EngineConstants.SmallTextureWidth * 40;
            graphics.PreferredBackBufferHeight = EngineConstants.SmallTextureHeight * 22;

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
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //Mouse Input Method
            CheckInputs();
            // TODO: Add your update logic here
            mediator.Tick();
           
            base.Update(gameTime);
           
        }

        private void CheckInputs()
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            // Get current mouseState
            mouseStateCurrent = Mouse.GetState();

            // Left MouseClick
            if (mouseStatePrevious.LeftButton == ButtonState.Pressed && mouseStateCurrent.LeftButton == ButtonState.Released)
            {


                BaseOrder order = new BaseOrder();
                order.Type = SpawnType.Sheriff;
                order.X = mouseStatePrevious.X;
                order.Y = mouseStatePrevious.Y;
                ((GameMediator)mediator).AcceptOrder((IOrder)order);
                ((GameMediator)mediator).MakeTestSound();
            }

            // Right MouseClick
            if (mouseStateCurrent.RightButton == ButtonState.Pressed && mouseStatePrevious.RightButton == ButtonState.Released)
            {
                //TODO when right mousebutton clicked
            }

            mouseStatePrevious = mouseStateCurrent;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            mediator.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
            
        }
    }
}
