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

        public const string CharacterImageLocation = "Images/Character/";
        public const string StructureImageLocation = "Images/Structure/";
        public const string MapTilesImageLocation = "Images/MapTile/";
        public const string SoundFileLocation = "SoundFX/";
        public const string EffectImageLocation = "Images/Effects/";


        public const int SmallTextureHeight = 32;
        public const int SmallTextureWidth = 32;

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

    public enum CharacterType
    {
        Zombie,
        ZombieDog,
        FlyingZombie,
        Priest,
        RedNeck,
        Sheriff
    }

    public enum StructureType
    {
        Hay,
        CarBack,
        CarFront,
        Pit
    }

    public enum StructureTextureType
    {
        Hay,
        CarBack,
        CarFront,
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
        Zombie5,
        Chainsaw
    }

    public enum SpawnType
    {
        Zombie,
        ZombieDog,
        FlyingZombie,
        Priest,
        RedNeck,
        Sheriff,
        Hay,
        Car,
        Pit
    }

    public enum EffectTextureType
    {
        Fog
    }
}
