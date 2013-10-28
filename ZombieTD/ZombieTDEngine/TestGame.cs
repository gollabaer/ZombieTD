using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTDEngine
{
    public class TestGame
    {
        IMediator _gameMediator;

        public TestGame()
        {
            _gameMediator = new GameMediator();
        }

        
        public void LoadContent()
        {

   
        }

        public void Tick()
        {
            _gameMediator.Tick();
        }

        public void Draw()
        {
            
        }
    }
}
