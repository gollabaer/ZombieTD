using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{
    public class Score : MenuBase
    {
        Stopwatch _stopWatch = new Stopwatch();
        int _totalKills = 0;
        int _totalKilled = 0;
        int _numberOfTownsFolk = 0;
        int _numberOfZombies = 0;
        float _townHallHealth = 0.0f;
        string _aliveTime = "";
        SpriteFont _spr_font;

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture.GetTexture(), new Rectangle(this._xPos, this._yPos, EngineConstants.ScoreTextureWidth, EngineConstants.ScoreTextureHeight), Color.White);


            spriteBatch.DrawString(_spr_font, string.Format("Total Kills = {0}", _totalKills),
                   new Vector2(EngineConstants.TotalKills_X, EngineConstants.TotalKills_Y), Color.Black);

            spriteBatch.DrawString(_spr_font, string.Format("Total Killed = {0}", _totalKilled),
        new Vector2(EngineConstants.TotalKilled_X, EngineConstants.TotalKilled_Y), Color.Black);

            spriteBatch.DrawString(_spr_font, string.Format("Total Townsfolk = {0}", _numberOfTownsFolk),
        new Vector2(EngineConstants.TotalTownsfolk_X, EngineConstants.TotalTownsfolk_Y), Color.Black);

            spriteBatch.DrawString(_spr_font, string.Format("Total Zombies = {0}", _numberOfZombies),
        new Vector2(EngineConstants.TotalZombies_X, EngineConstants.TotalZombies_Y), Color.Black);

            spriteBatch.DrawString(_spr_font, string.Format("Townhall Health = {0}%", _townHallHealth),
        new Vector2(EngineConstants.TownhallHealth_X, EngineConstants.TownHallHealth_Y), Color.Black);

            spriteBatch.DrawString(_spr_font, string.Format("Survival Time = {0}", _aliveTime),
        new Vector2(EngineConstants.SurvivalTime_X, EngineConstants.SurvivalTime_Y), Color.Black);
        }

        public override void LoadContent(IMediator mediator, ContentManager content)
        {
            this._texture =  mediator.GetAsset<MenuTextureType, ITexture>(MenuTextureType.Score);
             this._xPos = EngineConstants.ScoreStartX;
            this._yPos = EngineConstants.ScoreStartY;
            _spr_font = content.Load<SpriteFont>("Score"); 
            
        }
    }
}
