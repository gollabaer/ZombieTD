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
        public const string MenuImageLocation = "Images/Menus/";


        public const int SmallTextureHeight = 32;
        public const int SmallTextureWidth = 32;


        //Menu
        public const int SelectMenuTextureHeight = 64;
        public const int SelectMenuTextureWidth = 352;
        public const int ScoreTextureHeight = 128;
        public const int ScoreTextureWidth = 160;
        public const int MenuStartX = 928;
        public const int MenuStartY = 0;
        public const int ScoreStartX = 0;
        public const int ScoreStartY = 0;

        //Menu Buttons
        public const int Button_1_X = 1016;
        public const int Button_1_Y = 16;
        public const int Button_2_X = 1060;
        public const int Button_2_Y = 16;
        public const int Button_3_X = 1104;
        public const int Button_3_Y = 16;
        public const int Button_4_X = 1148;
        public const int Button_4_Y = 16;
        public const int Button_5_X = 1192;
        public const int Button_5_Y = 16;
        public const int Button_6_X = 1236;
        public const int Button_6_Y = 16;

        //Score
        public const int TotalKills_X = 5;
        public const int TotalKills_Y = 16;
        public const int TotalKilled_X = 5;
        public const int TotalKilled_Y = 32;
        public const int TotalTownsfolk_X = 5;
        public const int TotalTownsfolk_Y = 48;
        public const int TotalZombies_X = 5;
        public const int TotalZombies_Y = 64;
        public const int TownhallHealth_X = 5;
        public const int TownHallHealth_Y = 80;
        public const int SurvivalTime_X = 5;
        public const int SurvivalTime_Y = 96;

        public const int GameX = 1280;
        public const int GameY = 704;

        //FPS Display
        public const bool showFPS = true;
        public const float FPSX = 10.0f;
        public const float FPSY = 672.0f;









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
        Chainsaw,
        Error
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

    public enum MenuTextureType
    {
        SelectMenu,
        Score
    }

    public enum MenuSelectionOptions
    {
        RedNeck,
        Sheriff,
        Priest,
        Hay,
        Pit,
        Car
    }

    public enum OrderFor
    {

        Player,
        Enemy
    }
}
