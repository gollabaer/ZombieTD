using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ZombieTD
{
    public abstract class MenuBase : IMenu
    {
        public ITexture _texture; //Change tto protected
        public int _xPos;
        public int _yPos;


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

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void LoadContent(IMediator mediator, ContentManager content);
    }
}
