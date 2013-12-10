using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    class BloodStain : EffectBase, IGameElement
    {
        Rectangle rectangle1;
        IMediator _mediator;
        int _remainOnScreen = EngineConstants.BloodStainOnScreen;
        bool _removeBloodStain = false;
        public int X { get; set; }
        public int Y { get; set; }

        public BloodStain()
        {
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture.GetTexture(), rectangle1, Color.White);
        }

        public override void LoadContent(IMediator mediator)
        {
            rectangle1 = new Rectangle(X, Y, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight);
            _texture.SetNumberOfAnimations(0);
            this._mediator = mediator;
            _mediator.RegisterWithMediator(_mediator, this);
        }

        public override void update()
        {
      
        }

        public void TakeTurn(IMediator mediator)
        {
            if (_remainOnScreen <= 0)
            {
                _removeBloodStain = true;
            }
            else
            {
                _remainOnScreen--;
            }
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
            return this._removeBloodStain;
        }
    }
}
