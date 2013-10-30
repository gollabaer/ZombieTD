using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
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
