using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    public class Tile
    {
        
        ITexture _texture;
        MapTileType _textureType;
        List<IGameElement> _charactersOnTile = new List<IGameElement>();

        int _number_of_90_degree_flips;
        int _xPos;
        int _yPos;

        public MapTileType TextureType
        {
            get { return _textureType; }
            set { _textureType = value; }

        }


        [XmlIgnore()] 
        public ITexture Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public int Xpos
        {
            get { return _xPos; }
            set { _xPos = value; }

        }

        public int Ypos
        {
            get { return _yPos; }
            set { _yPos = value; }

        }

        public int Flips
        {
            get { return _number_of_90_degree_flips; }
            set { _number_of_90_degree_flips = value; }
        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            int dy = EngineConstants.SmallTextureHeight / 2;
            int dx = EngineConstants.SmallTextureWidth / 2;

            if (_texture != null)
                spritebatch.Draw(_texture.GetTexture(), new Rectangle(_xPos+ dx, _yPos +dy, EngineConstants.SmallTextureWidth, EngineConstants.SmallTextureHeight),
                    _texture.getViewRec(), Color.White, _texture.getRotation(), new Vector2(dx,dy), SpriteEffects.None, 0);
        }

        public bool HasCharacters()
        {
            return (_charactersOnTile.Count > 0);

        }
        public void SetTexture(IMediator mediator)
        {
           this._texture = mediator.GetAsset<MapTileType, ITexture> (this._textureType);
          _texture.setRotation((float)(Math.PI / 2) * this._number_of_90_degree_flips);
        }

        public void AddElementToTile(IGameElement element)
        {
            this._charactersOnTile.Add(element);
        }

        public void RemoveElementFromTile(IGameElement element)
        {
            this._charactersOnTile.Remove(element);
        }

    }
}


