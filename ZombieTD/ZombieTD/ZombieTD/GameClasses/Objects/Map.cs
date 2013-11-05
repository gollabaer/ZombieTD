﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ZombieTD
{
    public class Map
    {
        public List<Tile> Tiles {get; set;}

        public void Draw(SpriteBatch spritebatch)
        {
            Parallel.ForEach(Tiles, tile =>
                {
                    tile.Draw(spritebatch);
                });
        }

        public Map GetMapByLineOfSight(int lineOfSight, int x, int y)
        {
            return new Map();
        }

        public static Map LoadMap(IMediator mediator)
        {
            Map map = new Map();
            map = (EngineConstants.MapFileLocation.LoadFromFilename()).LoadFromXMLString();

            foreach(Tile tile in map.Tiles)
            {
                tile.SetTexture(mediator);
         
            }

            return map;
        }
    }
}
