using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    class MouseInputMenuDirector
    {
        private IMediator mediator;
        private MouseState mouseStateCurrent, mouseStatePrevious;

        public MouseInputMenuDirector(IMediator mediator)
        {
            // TODO: Complete member initialization
            this.mediator = mediator;
        }

        public Vector2 ProcessInput(MouseState state)
        {
            // Get current mouseState
            mouseStateCurrent = state;
            int mouseX = state.X;
            int mouseY = state.Y;

            if ((mouseX >= 0 && mouseX <= EngineConstants.GameX) && (mouseY >= 0 && mouseY <= EngineConstants.GameY))
            {
                // Left MouseClick
                if (mouseStatePrevious.LeftButton == ButtonState.Pressed && mouseStateCurrent.LeftButton == ButtonState.Released)
                {
                    switch (GameMediator._gameState)
                    {
                        //This Clicks are in the context of the splash screen
                        case GameState.SplashScreen:

                            //StartGame Button
                            if ((mouseX >= EngineConstants.Button_Start_TopX && mouseX <= EngineConstants.Button_Start_BottomX) &&
                                (mouseY >= EngineConstants.Button_Start_TopY && mouseY <= EngineConstants.Button_Start_BottomY))
                            {
                                GameMediator.numberofTicks = 1;
                                GameMediator._gameState = GameState.GameRunning;
                            }

                            //Help Menu Button
                            if ((mouseX >= EngineConstants.Button_Help_TopX && mouseX <= EngineConstants.Button_Help_BottomX) &&
                                (mouseY >= EngineConstants.Button_Help_TopY && mouseY <= EngineConstants.Button_Help_BottomY))
                            {
                                GameMediator._gameState = GameState.HelpMenu;
                            }
                            break;

                        //This clicks are in the context of the Help Menu
                        case GameState.HelpMenu:
                            //Back Button
                            if ((mouseX >= EngineConstants.Button_Back_TopX && mouseX <= EngineConstants.Button_Back_BottomX) &&
                                (mouseY >= EngineConstants.Button_Back_TopY && mouseY <= EngineConstants.Button_Back__BottomY))
                            {
                                GameMediator._gameState = GameState.SplashScreen;
                            }
                            break;
                        //This clicks are in the context of the Game Over Menu
                        case GameState.GameOver:
                            //Yes Button
                            if ((mouseX >= EngineConstants.Button_Yes_TopX && mouseX <= EngineConstants.Button_Yes_BottomX) &&
                                (mouseY >= EngineConstants.Button_Yes_TopY && mouseY <= EngineConstants.Button_Yes_BottomY))
                            {
                                GameMediator.numberofTicks = 1;
                                GameMediator._gameState = GameState.GameReset;
                            }

                            //No Button
                            if ((mouseX >= EngineConstants.Button_No_TopX && mouseX <= EngineConstants.Button_No_BottomX) &&
                                (mouseY >= EngineConstants.Button_No_TopY && mouseY <= EngineConstants.Button_No_BottomY))
                            {
                                GameMediator._gameState = GameState.GameExit;
                            }
                            break;
                    }
                    // Right MouseClick
                    if (mouseStateCurrent.RightButton == ButtonState.Pressed && mouseStatePrevious.RightButton == ButtonState.Released)
                    {

                    }
                }
            }
            
            mouseStatePrevious = mouseStateCurrent;

            return new Vector2(mouseStateCurrent.X, mouseStateCurrent.Y);
        }
    }
}
