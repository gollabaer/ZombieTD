using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public static class EngineConstants
    {
        //Map File Location
        public const string MapFileLocation = "Map.txt";

        //Loggin Switch
        public const bool IsLogging = true;




    }

    public enum MapTileType
    {
        RoadOutside,
        Building_roof_center,
        Building_roof_corner,
        Building_Roof_Side,
        Grass,
        Path_noRock,
        Path_withRock,
        RoadMiddle,
        RoofTownHall_corner,
        TownHallRoof_Middle,
        TownhallRoof_Side,
        Tree,
        Error

    }

    public enum CharacterTextureType
    {
        Zombie,
        ZombieDog,
        FlyingZombie,
        Priest,
        RedNeck,
        Sheriff
    }

    public enum StructureTextureType
    {
        Hay,
        Car,
        Pit
    }

    public enum SoundType
    {
        Fire,
        Gunshot,
        HolyWater,
        Priest,
        Zombie1,
        Zombie2,
        Zombie3,
        Zombie4,
        Zombie5
    }
}
