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

        int upperXPosition, upperYPosition, lowerXPosition, lowerYPosition;

        public Map()
        {
            Tiles = new List<Tile>();
        }

        public void Draw(SpriteBatch spritebatch)
        {
#if DEBUG
            foreach (Tile tile in Tiles)
            {
                tile.Draw(spritebatch);
            }
#else
            Parallel.ForEach(Tiles, tile =>
                {
                    lock (spritebatch) tile.Draw(spritebatch);
                });
#endif
        }

        public Map GetMapByLineOfSight(int lineOfSight, int x, int y)
        {
            Map returnMap = new Map();

            upperXPosition = x + -32 * lineOfSight;
            upperYPosition = y + -32 * lineOfSight;
            lowerXPosition = x + (32 * lineOfSight);
            lowerYPosition = y + (32 * lineOfSight);

            var found = from tile in Tiles
                        where tile.Xpos >= upperXPosition && tile.Xpos <= lowerXPosition &&
                                tile.Ypos >= upperYPosition && tile.Ypos <= lowerYPosition
                        select tile;

            returnMap.Tiles = (List<Tile>)found.ToList();
            returnMap.Base = this.Base;
            returnMap.EntryPoints = this.EntryPoints;

            return returnMap;
        }

        public static Map LoadMap(IMediator mediator)
        {
            Map map = new Map();
            map = (EngineConstants.MapFileLocation.LoadFromFilename()).LoadFromXMLString();

#if DEBUG
            foreach(Tile tile in map.Tiles)
            {
                tile.SetTexture(mediator);
            }
#else
            Parallel.ForEach(map.Tiles, tile =>
            {
                tile.SetTexture(mediator);
            });
#endif

            SetEntryPoints(map);
            SetBase(map);

            return map;
        }

        private static void SetEntryPoints(Map map)
        {
#if DEBUG
            foreach (Tile tile in map.Tiles)
            {
                if ((tile.Xpos == 0 || tile.Ypos == 0 || tile.Xpos == EngineConstants.MapEdgeX || tile.Ypos == EngineConstants.MapEdgeY) &&
                    (tile.TextureType == MapTileType.Path_withRock ||
                     tile.TextureType == MapTileType.Path_noRock ||
                     tile.TextureType == MapTileType.RoadMiddle ||
                     tile.TextureType == MapTileType.RoadOutside))
                {
                    map.EntryPoints.Add(tile);
                }
            }
#else
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
#endif
        }

        private static void SetBase(Map map)
        {
#if DEBUG
            foreach (Tile tile in map.Tiles)
            {
                if (tile.TextureType == MapTileType.RoofTownHall_corner ||
                     tile.TextureType == MapTileType.TownHallRoof_Middle ||
                     tile.TextureType == MapTileType.TownhallRoof_Side)
                {
                    map.Base.Add(tile);
                }
            }
#else
            Parallel.ForEach(map.Tiles, tile =>
            {
                if (tile.TextureType == MapTileType.RoofTownHall_corner ||
                    tile.TextureType == MapTileType.TownHallRoof_Middle ||
                    tile.TextureType == MapTileType.TownhallRoof_Side)
                {
                    lock(map) map.Base.Add(tile);
                }
            });
#endif
        }

        public Tile GetTileByXY(int x, int y)
        {
            var found = from tile in Tiles
                        where (x >= tile.Xpos && x < tile.Xpos + EngineConstants.SmallTextureWidth) &&
                              (y >= tile.Ypos && y < tile.Ypos + EngineConstants.SmallTextureWidth)
                        select tile;

            return found.FirstOrDefault();
        }
    }
}
