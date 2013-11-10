using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{
    public class Menu : MenuBase
    {
        //List<Tuple<string, ITexture>> selectionItems = new List<Tuple<string,ITexture>>();
       
        public Menu()
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture.GetTexture(), new Rectangle(this._xPos, this._yPos, EngineConstants.SelectMenuTextureWidth, EngineConstants.SelectMenuTextureHeight), Color.White);

            //int itemX = this.Xpos + 32;
            //int itemY = this.Ypos + 16;


            //int dy = EngineConstants.SmallTextureHeight / 2;
            //int dx = EngineConstants.SmallTextureWidth / 2;

            //foreach (Tuple<string, ITexture> entry in selectionItems)
            //{
            //    spriteBatch.Draw(entry.Item2.GetTexture(), new Rectangle(itemX, itemY, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight), 
            //                     entry.Item2.getViewRec(), Color.White, _texture.getRotation(), new Vector2(dx, dy), SpriteEffects.None, 0);
            //    itemX += 32;
            //}

           //// spriteBatch.Draw(
           // if (_texture != null)
           //     spriteBatch.Draw(_texture.GetTexture(), new Rectangle(_xPos , _yPos, EngineConstants.SelectMenuTextureWidth, EngineConstants.SelectMenuTextureHeight),
           //         _texture.getViewRec(), Color.White, _texture.getRotation(), new Vector2(dx, dy), SpriteEffects.None, 0);
        }

        public override void LoadContent(IMediator mediator, ContentManager content)
        {
            this._texture = mediator.GetAsset<MenuTextureType, ITexture>(MenuTextureType.SelectMenu);
            this._xPos = EngineConstants.MenuStartX;
            this._yPos = EngineConstants.MenuStartY;

            //selectionItems.Add(new Tuple<string, ITexture>("RedNeck", mediator.GetAsset<CharacterTextureType, ITexture>(CharacterTextureType.RedNeck)));
            //selectionItems.Add(new Tuple<string, ITexture>("Sheriff", mediator.GetAsset<CharacterTextureType, ITexture>(CharacterTextureType.Sheriff)));
            //selectionItems.Add(new Tuple<string, ITexture>("Priest", mediator.GetAsset<CharacterTextureType, ITexture>(CharacterTextureType.Priest)));
            //selectionItems.Add(new Tuple<string, ITexture>("Hay", mediator.GetAsset<StructureTextureType, ITexture>(StructureTextureType.Hay)));
            //selectionItems.Add(new Tuple<string, ITexture>("Pit", mediator.GetAsset<StructureTextureType, ITexture>(StructureTextureType.Pit)));
            //selectionItems.Add(new Tuple<string, ITexture>("Car", mediator.GetAsset<StructureTextureType, ITexture>(StructureTextureType.CarFront)));   
        }
    }
}
