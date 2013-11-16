using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ZombieTD
{
    public class MouseInputActionDirector
    {
        private IMediator mediator;
        private MouseState mouseStateCurrent, mouseStatePrevious;
        private IOrder order = null;
        private Tuple<int, int> returnXY;
        private bool _waitingToPlace = false;

        public MouseInputActionDirector(IMediator mediator)
        {
            // TODO: Complete member initialization
            this.mediator = mediator;

        }

        public Tuple<int,int> ProcessInput(MouseState state)
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
                    //This Click fell within the Menu
                    if ((mouseX >= EngineConstants.MenuStartX && mouseX <= (EngineConstants.MenuStartX + EngineConstants.SelectMenuTextureWidth)) &&
                        (mouseY >= EngineConstants.MenuStartY && mouseY <= EngineConstants.MenuStartY + EngineConstants.SelectMenuTextureHeight))
                    {
                        ProcessMenuClick(mouseX, mouseY);
                    }
                    //This click was on the map
                    else
                    {
                        ProcessMapClick(mouseX, mouseY);
                    }
                }
                // Right MouseClick
                if (mouseStateCurrent.RightButton == ButtonState.Pressed && mouseStatePrevious.RightButton == ButtonState.Released)
                {
                    order = null;
                }
            }

            
            returnXY = new Tuple<int, int>(mouseStateCurrent.X,mouseStateCurrent.Y);

            mouseStatePrevious = mouseStateCurrent;

            return returnXY;
        }


        private void ProcessMenuClick(int x, int y)
        {
            if ((x >= EngineConstants.Button_1_X && x <= EngineConstants.Button_1_X + EngineConstants.SmallTextureWidth) &&
               (y >= EngineConstants.Button_1_Y && y <= EngineConstants.Button_1_Y + EngineConstants.SmallTextureWidth))
            {
                CreateOrder(SpawnType.RedNeck);
            }
            else if ((x >= EngineConstants.Button_2_X && x <= EngineConstants.Button_2_X + EngineConstants.SmallTextureWidth) &&
               (y >= EngineConstants.Button_2_Y && y <= EngineConstants.Button_2_Y + EngineConstants.SmallTextureWidth))
            {
                CreateOrder(SpawnType.Sheriff);
            }
            else if ((x >= EngineConstants.Button_3_X && x <= EngineConstants.Button_3_X + EngineConstants.SmallTextureWidth) &&
               (y >= EngineConstants.Button_3_Y && y <= EngineConstants.Button_3_Y + EngineConstants.SmallTextureWidth))
            {
                CreateOrder(SpawnType.Priest);
            }
            else if ((x >= EngineConstants.Button_4_X && x <= EngineConstants.Button_4_X + EngineConstants.SmallTextureWidth) &&
               (y >= EngineConstants.Button_4_Y && y <= EngineConstants.Button_4_Y + EngineConstants.SmallTextureWidth))
            {
                CreateOrder(SpawnType.Hay);
            }
            else if ((x >= EngineConstants.Button_5_X && x <= EngineConstants.Button_5_X + EngineConstants.SmallTextureWidth) &&
               (y >= EngineConstants.Button_5_Y && y <= EngineConstants.Button_5_Y + EngineConstants.SmallTextureWidth))
            {
                CreateOrder(SpawnType.RedNeck);CreateOrder(SpawnType.Pit);
            }
            else if ((x >= EngineConstants.Button_6_X && x <= EngineConstants.Button_6_X + EngineConstants.SmallTextureWidth) &&
               (y >= EngineConstants.Button_6_Y && y <= EngineConstants.Button_6_Y + EngineConstants.SmallTextureWidth))
            {
                CreateOrder(SpawnType.RedNeck); CreateOrder(SpawnType.Car);
            }
        }

        private void CreateOrder(SpawnType type)
        {
            order = new BaseOrder();
            order.Type = type;
        }

        private void ProcessMapClick(int x, int y)
        {
            bool orderOkay = false;

            if (order != null)
            {
                Tile tile = mediator.GetTileByXY(x, y);

                if (!tile.HasCharacters())
                {
                    if (order.Type == SpawnType.Sheriff || order.Type == SpawnType.Priest)
                    {
                        if (tile.TextureType == MapTileType.Grass || tile.TextureType == MapTileType.Building_roof_center ||
                            tile.TextureType == MapTileType.Building_roof_corner || tile.TextureType == MapTileType.Building_Roof_Side)
                        {
                            orderOkay = true;
                        }
                    }
                    if (order.Type == SpawnType.RedNeck)
                    {
                        if (tile.TextureType == MapTileType.Grass)
                        {
                            orderOkay = true;
                        }
                    }
                    else if (order.Type == SpawnType.Hay || order.Type == SpawnType.Car)
                    {
                        if (tile.TextureType == MapTileType.Path_noRock || tile.TextureType == MapTileType.Path_withRock ||
                            tile.TextureType == MapTileType.RoadMiddle || tile.TextureType == MapTileType.RoadOutside)
                        {
                            orderOkay = true;
                        }
                    }
                    else if (order.Type == SpawnType.Pit)
                    {
                        if (tile.TextureType == MapTileType.Path_noRock || tile.TextureType == MapTileType.Path_withRock)
                        {
                            orderOkay = true;
                        }
                    }

                    if (orderOkay)
                    {
                        order.X = tile.Xpos;
                        order.Y = tile.Ypos;
                        mediator.AcceptOrder(order as IOrder, OrderFor.Player);
                    }
                    else
                    {
                        mediator.GetAsset<SoundType, ISound>(SoundType.Error).Play();
                    }
                }
                else
                {
                    mediator.GetAsset<SoundType, ISound>(SoundType.Error).Play();
                }
            }
            else
            {
                //normal map click show usits stats
            }
        }
    }
}
