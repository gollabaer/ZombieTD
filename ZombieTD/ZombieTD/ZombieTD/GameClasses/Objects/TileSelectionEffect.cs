using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    class TileSelectionEffect : EffectBase
    {

        Rectangle rectangle1;
        IMediator _mediator;
        Tile _tile;

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture.GetTexture(), rectangle1, Color.White);
        }

        public override void LoadContent(IMediator mediator)
        {
            this._texture = mediator.GetAsset<EffectTextureType, ITexture>(EffectTextureType.SelectTile);
            rectangle1 = new Rectangle(0, 0, _texture.GetTexture().Width, _texture.GetTexture().Height);
            _texture.SetNumberOfAnimations(1);
            this._mediator = mediator;
        }

        public override void update()
        {
            if (GameMediator.numberofTicks % 10 == 0)
            {
                _tile = _mediator.GetTileByXY((int)GameMediator._mouseInputs.Item1.X, (int)GameMediator._mouseInputs.Item1.Y);

                if (_tile != null)
                {
                    rectangle1.X = _tile.Xpos;
                    rectangle1.Y = _tile.Ypos;
                }
                else
                {
                    rectangle1.X = -32;
                    rectangle1.Y = -32;
                }
            }
        }
    }
}
