using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;

namespace ZombieTD
{
    public class Score : MenuBase
    {
        Stopwatch _stopWatch = new Stopwatch();
        int _totalKills = 0;
        int _totalKilled = 0;
        int _numberOfTownsFolk = 0;
        int _numberOfZombies = 0;
        int _finalScore = 0;
        int _money = EngineConstants.StartMoney;
        SpriteFont _spr_font_gameRunning;
        SpriteFont _spr_font_gameOver;
        Color _fontColor;

        public Score(IMediator mediator)
            : base(mediator)
        {
            _fontColor = new Color(new Vector4(146,142,142,1));

            _stopWatch.Start();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture.GetTexture(), new Rectangle(this._xPos, this._yPos, EngineConstants.ScoreTextureWidth, EngineConstants.ScoreTextureHeight), Color.White);

             spriteBatch.DrawString(_spr_font_gameRunning, string.Format("Total Kills = {0}", _totalKills),
             new Vector2(EngineConstants.TotalKills_X, EngineConstants.TotalKills_Y), Color.Black);

            spriteBatch.DrawString(_spr_font_gameRunning, string.Format("Total Killed = {0}", _totalKilled),
            new Vector2(EngineConstants.TotalKilled_X, EngineConstants.TotalKilled_Y), Color.Black);

            spriteBatch.DrawString(_spr_font_gameRunning, string.Format("Total Townsfolk = {0}", _numberOfTownsFolk),
            new Vector2(EngineConstants.TotalTownsfolk_X, EngineConstants.TotalTownsfolk_Y), Color.Black);

            spriteBatch.DrawString(_spr_font_gameRunning, string.Format("Total Zombies = {0}", _numberOfZombies),
            new Vector2(EngineConstants.TotalZombies_X, EngineConstants.TotalZombies_Y), Color.Black);

            spriteBatch.DrawString(_spr_font_gameRunning, string.Format("Townhall Health = {0}", _mediator.GetTownhallHealth()),
            new Vector2(EngineConstants.TownhallHealth_X, EngineConstants.TownHallHealth_Y), Color.Black);

            spriteBatch.DrawString(_spr_font_gameRunning, string.Format("Survival Time = {0}", _stopWatch.Elapsed.ToString("mm\\:ss")),
            new Vector2(EngineConstants.SurvivalTime_X, EngineConstants.SurvivalTime_Y), Color.Black);
        }

        public override void LoadContent(ContentManager content)
        {
            this._texture =  _mediator.GetAsset<MenuTextureType, ITexture>(MenuTextureType.Score);
             this._xPos = EngineConstants.ScoreStartX;
            this._yPos = EngineConstants.ScoreStartY;
            _spr_font_gameRunning = content.Load<SpriteFont>("Score");  
            _spr_font_gameOver = content.Load<SpriteFont>("GameOver");  

        }

        public void AddEnemy()
        {
            _numberOfZombies++;
        }

        public void SubtractEnemy()
        {
            _numberOfZombies--;
        }

        public void AddTownsfolk()
        {
            _numberOfTownsFolk++;
        }

        public int GetNumberOfZombies()
        {

            return _numberOfZombies;
        }

        internal void AddKill()
        {
            _totalKills++;
        }

        internal void SubtractPlayer()
        {
            _numberOfTownsFolk--;
        }

        internal void AddKilled()
        {
            _totalKilled++;
        }

        public void StopTime()
        {
            this._stopWatch.Stop();
            this.CalculateFinalScore();
        }

        private void CalculateFinalScore()
        {
            //Kill Credit
            _finalScore += _totalKills * 100;
            //Loss Debit
            _finalScore -= _totalKilled * 10;
            //Survivor Credit
            _finalScore += _numberOfTownsFolk * 100;
            //Zombie Survivor Debit
            _finalScore -= _numberOfZombies * 10;

            _finalScore += _stopWatch.Elapsed.Seconds * 10;

            Logger.Log(Logger.Log_Type.INFO, "Final Score was " + _finalScore.ToString());
        }

        internal void DrawGameOver(SpriteBatch spriteBatch)
        {
            
            spriteBatch.DrawString(_spr_font_gameOver, string.Format("Total Zombies Killed = {0}", _totalKills),
             new Vector2(EngineConstants.GO_TotalKills_X, EngineConstants.GO_TotalKills_Y), _fontColor);

            spriteBatch.DrawString(_spr_font_gameOver, string.Format("Total Townsfolk Killed = {0}", _totalKilled),
            new Vector2(EngineConstants.GO_TotalKilled_X, EngineConstants.GO_TotalKilled_Y), _fontColor);

            spriteBatch.DrawString(_spr_font_gameOver, string.Format("Total Townsfolk Alive = {0}", _numberOfTownsFolk),
            new Vector2(EngineConstants.GO_TotalTownsfolk_X, EngineConstants.GO_TotalTownsfolk_Y), _fontColor);

            spriteBatch.DrawString(_spr_font_gameOver, string.Format("Total Zombies Alive= {0}", _numberOfZombies),
            new Vector2(EngineConstants.GO_TotalZombies_X, EngineConstants.GO_TotalZombies_Y), _fontColor);

            spriteBatch.DrawString(_spr_font_gameOver, string.Format("Survival Time = {0}", _stopWatch.Elapsed.ToString("mm\\:ss")),
            new Vector2(EngineConstants.GO_SurvivalTime_X, EngineConstants.GO_SurvivalTime_Y), _fontColor);

            spriteBatch.DrawString(_spr_font_gameOver, string.Format("Total Game Score = {0}", _finalScore),
            new Vector2(EngineConstants.GO_FinalScore_X, EngineConstants.GO_FinalScore_Y), _fontColor);
        }


        public void addMoney(int amount)
        {
            _money += amount;
        }


        public void subtractMoney(int amount)
        {
            _money -= amount;
        }

        public int getMoney()
        {
            return _money;
        }
    }
}
