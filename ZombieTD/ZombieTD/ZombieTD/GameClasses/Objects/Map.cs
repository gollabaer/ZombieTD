using System;
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
        public List<Tile> EntryPoints { get; set;}
        public List<Tile> Base { get; set; }



        public Map()
        {
            Tiles = new List<Tile>();

        }
        public void Draw(SpriteBatch spritebatch)
        {
            //For Debug
            //foreach(Tile tile in Tiles)
            //    {
            //        tile.Draw(spritebatch);
            //    }

            Parallel.ForEach(Tiles, tile =>
                {
                    lock (spritebatch) tile.Draw(spritebatch);
                });
        }

        public Map GetMapByLineOfSight(int lineOfSight, int x, int y)
        {
            Map returnMap = new Map();

            Parallel.ForEach(Tiles, tile =>
            {
                int dist = Math.Max(Math.Abs(x - tile.Xpos), Math.Abs(y - tile.Ypos));
                if (dist <= lineOfSight)
                {
                    lock (returnMap) returnMap.Tiles.Add(tile);
                }
            });

            //TODO return map by line of sight
            return returnMap;
        }

        public static Map LoadMap(IMediator mediator)
        {
            Map map = new Map();
            map = (EngineConstants.MapFileLocation.LoadFromFilename()).LoadFromXMLString();

            //foreach(Tile tile in map.Tiles)
            //{
            //    tile.SetTexture(mediator);
            //}

            Parallel.ForEach(map.Tiles, tile =>
            {
                tile.SetTexture(mediator);
            });

            SetEntryPoints(map);
            SetBase(map);

            return map;
        }

        private static void SetEntryPoints(Map map)
        {
            //foreach (Tile tile in map.Tiles)
            //{
            //    if ((tile.Xpos == 0 || tile.Ypos == 0 || tile.Xpos == 1248 || tile.Ypos == 672) &&
            //        (tile.TextureType == MapTileType.Path_withRock ||
            //         tile.TextureType == MapTileType.Path_noRock ||
            //         tile.TextureType == MapTileType.RoadMiddle ||
            //         tile.TextureType == MapTileType.RoadOutside))
            //    {
            //        map.EntryPoints.Add(tile);
            //    }
            //}

            Parallel.ForEach(map.Tiles, tile =>
            {
                if ((tile.Xpos == 0 || tile.Ypos == 0 || tile.Xpos == EngineConstants.MapEdgeX || tile.Ypos == EngineConstants.MapEdgeY) &&
                    (tile.TextureType == MapTileType.Path_withRock ||
                     tile.TextureType == MapTileType.Path_noRock ||
                     tile.TextureType == MapTileType.RoadMiddle ||
                     tile.TextureType == MapTileType.RoadOutside))
                {
                    lock(map) map.EntryPoints.Add(tile);
                }
            });
        }

        private static void SetBase(Map map)
        {
            //foreach (Tile tile in map.Tiles)
            //{
            //    if (tile.TextureType == MapTileType.RoofTownHall_corner ||
            //         tile.TextureType == MapTileType.TownHallRoof_Middle ||
            //         tile.TextureType == MapTileType.TownhallRoof_Side)
            //    {
            //        map.EntryPoints.Add(tile);
            //    }
            //}


            Parallel.ForEach(map.Tiles, tile =>
            {
                if (tile.TextureType == MapTileType.RoofTownHall_corner ||
                    tile.TextureType == MapTileType.TownHallRoof_Middle ||
                    tile.TextureType == MapTileType.TownhallRoof_Side)
                {
                    lock(map) map.Base.Add(tile);
                }
            });

        }

        public Tile GetTileByXY(int x, int y)
        {
            Tile foundTile = null;

            Parallel.ForEach(Tiles, tile =>
            {
                if ((x >= tile.Xpos && x < tile.Xpos + EngineConstants.SmallTextureWidth) &&
                (y >= tile.Ypos && y < tile.Ypos + EngineConstants.SmallTextureWidth))
                {
                    foundTile = tile;        
                }
            });

            return foundTile;
        }

        public void RemoveElementFromTile(IGameElement element)
        {
            Parallel.ForEach(Tiles, tile =>
            {
                tile.RemoveElement(element);
            });

        }
    }
}
