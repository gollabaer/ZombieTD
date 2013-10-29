using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTDEngine
{
    class Tile
    {
        ITexture _texture;
        int _textureType;
        int _xPos;
        int _yPos;
        List<ICharacter> _charactersOnTile;
    }
}
