using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieTD
{
    public class Map
    {
        public List<Tile> Tiles {get; set;}

        public void Draw()
        {
            Parallel.ForEach(Tiles, tile =>
                {
                    tile.Draw();
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

            Parallel.ForEach(map.Tiles, tile =>
            {
                tile.SetTexture(mediator);
         
            });

            return map;
        }
    }
}
