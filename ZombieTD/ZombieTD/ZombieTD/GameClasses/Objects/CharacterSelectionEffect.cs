using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    class CharacterSelectionEffect : EffectBase
    {

        Rectangle rectangle1;
        IMediator _mediator;

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture.GetTexture(), rectangle1, Color.White);
        }

        public override void LoadContent(IMediator mediator)
        {
            this._texture = mediator.GetAsset<EffectTextureType, ITexture>(EffectTextureType.CharacterSelection);
            rectangle1 = new Rectangle(0, 0, _texture.GetTexture().Width, _texture.GetTexture().Height);
            _texture.SetNumberOfAnimations(1);
            this._mediator = mediator;
        }

        public override void update()
        {
            if (GameMediator._mouseInputs.Item2 != null)
            {
                switch (GameMediator._mouseInputs.Item2)
                {
                    case SpawnType.RedNeck: rectangle1.X = EngineConstants.Button_1_X - 2; rectangle1.Y = EngineConstants.Button_1_Y - 2; break;
                    case SpawnType.Sheriff: rectangle1.X = EngineConstants.Button_2_X - 2; rectangle1.Y = EngineConstants.Button_2_Y - 2; break;
                    case SpawnType.Priest: rectangle1.X = EngineConstants.Button_3_X - 2; rectangle1.Y = EngineConstants.Button_3_Y - 2; break;
                    case SpawnType.Hay: rectangle1.X = EngineConstants.Button_4_X - 2; rectangle1.Y = EngineConstants.Button_4_Y - 2; break;
                    case SpawnType.Pit: rectangle1.X = EngineConstants.Button_5_X - 2; rectangle1.Y = EngineConstants.Button_5_Y - 2; break;
                    case SpawnType.Car: rectangle1.X = EngineConstants.Button_6_X - 2; rectangle1.Y = EngineConstants.Button_6_Y - 2; break;
                }
            }
            else
            {
                rectangle1.X = -37;
                rectangle1.Y = -37;
            }
        }
    }
}
