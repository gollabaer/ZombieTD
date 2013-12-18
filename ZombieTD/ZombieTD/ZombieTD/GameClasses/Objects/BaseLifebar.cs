using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ZombieTD
{
    class BaseLifebar 
    {
        
        public ITexture _lifebar;
        Rectangle _recbar;
        Rectangle _rec2life;
       

        public BaseLifebar() {
            _recbar = new Rectangle(32 * 18,32 * 10,32 * 3, 10);
            _rec2life = new Rectangle(32 * 18, 32 * 10, 32 * 3, 10);
        }

        public  void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(_lifebar.GetTexture(),_recbar, Color.Red);
            spriteBatch.Draw(_lifebar.GetTexture(), _rec2life, Color.Green);

        }

        public  void update(float life) {
            int lifeperBar = (int) (((float)life / (float)EngineConstants.Base_Health) * 32f * 3f);
            _rec2life.Width = lifeperBar;
        }

        public  void LoadContent(IMediator mediator)
        {
            //throw new NotImplementedException();
        }

    }
}
