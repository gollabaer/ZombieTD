using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ZombieTD
{
    public class Tile
    {
        
        ITexture _texture;
        MapTileType _textureType;
        List<ICharacter> _charactersOnTile;

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

        public void Draw()
        {

        }

        public void SetTexture(IMediator mediator)
        {
           // this._texture = mediator.GetAsset<MapTileType, ITexture> (this._textureType);
        }
    }
}


