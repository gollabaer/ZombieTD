using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    public class DeathBlood : EffectBase, IGameElement
    {
        Rectangle rectangle1;
        IMediator _mediator;
        int _animationCount = 0;
        bool _animationsComplete = false;
        public int X { get; set; }
        public int Y { get; set; }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
       
            spriteBatch.Draw(_texture.GetTexture(), rectangle1, Color.White);
        }

        public override void LoadContent(IMediator mediator)
        {
            this._texture = mediator.GetAsset<EffectTextureType, ITexture>(EffectTextureType.DeathBlood);
            rectangle1 = new Rectangle(X, Y, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight);
            _texture.SetNumberOfAnimations(6);
            this._mediator = mediator;
            _mediator.RegisterWithMediator(_mediator, this);
        }

        public override void update()
        {
            if (_texture != null && (GameMediator.numberofTicks % 3 == 0))
            {
                _texture.update();
                if (_animationCount >= 6)
                {
                    _animationsComplete = true;
                }
                _animationCount++;
            }
        }

        public void TakeTurn(IMediator mediator)
        {
            update();
        }

        public void RegisterWithMediator(IMediator mediator, IGameElement element)
        {
            _mediator.RegisterWithMediator(_mediator, this);
        }

        public void SetTile(Tile tile)
        {
           
        }

        public void SetStartTile(Tile tile)
        {
            
        }

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }

        public void SetRotation(float rotation)
        {
            
        }

        public ITexture GetTexture()
        {
            return this._texture;
        }

        public bool GetDeadFlag()
        {
            return this._animationsComplete;
        }
    }
}
