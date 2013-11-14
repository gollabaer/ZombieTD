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
        public const string MusicFileLocation = "Music/";

        public const int SmallTextureHeight = 32;
        public const int SmallTextureWidth = 32;
        public const int ScreenWidth = EngineConstants.SmallTextureWidth * 40;
        public const int ScreenHeight = EngineConstants.SmallTextureWidth * 22;


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

        public const int GameX = 1279;
        public const int GameY = 703;

        //FPS Display
        public const bool showFPS = true;
        public const float FPSX = 10.0f;
        public const float FPSY = 630.0f;

        //Ticks Display
        public static bool ShowTicks = true;
        public const float TicksX = 10.0f;
        public const float TicksY = 650.0f;


        //Wave Generator
        public const int NumberOfFramesBeforeOrder = 55;
        public const int MaxNumberOfSpawns = 200;


        //Character Attributes

        //Zombie
        public const int Zombie_Health = 9;
        public const int Zombie_AttackDamageMelee = 2;
        public const int Zombie_AttackDamageRanged = 4;
        public const int Zombie_AttackRange = 6;
        public const int Zombie_Defense = 2;
        public const int Zombie_Speed = 5;
        public const int Zombie_NumberOfFramesBeforeMove = 5;
        public const int Zombie_LineOfSite = 6;
        
        //ZombieDog
        public const int ZombieDog_Health = 10;
        public const int ZombieDog_AttackDamageMelee = 2;
        public const int ZombieDog_AttackDamageRanged = 4;
        public const int ZombieDog_AttackRange = 6;
        public const int ZombieDog_Defense = 2;
        public const int ZombieDog_Speed = 5;
        public const int ZombieDog_NumberOfFramesBeforeMove = 5;
        public const int ZombieDog_LineOfSite = 6;

        //FlyingZombie
        public const int FlyingZombie_Health = 10;
        public const int FlyingZombie_AttackDamageMelee = 2;
        public const int FlyingZombie_AttackDamageRanged = 4;
        public const int FlyingZombie_AttackRange = 6;
        public const int FlyingZombie_Defense = 2;
        public const int FlyingZombie_Speed = 5;
        public const int FlyingZombie_NumberOfFramesBeforeMove = 5;
        public const int FlyingZombie_LineOfSite = 6;

        //Redneck
        public const int Redneck_Health = 10;
        public const int Redneck_AttackDamageMelee = 2;
        public const int Redneck_AttackDamageRanged = 4;
        public const int Redneck_AttackRange = 6;
        public const int Redneck_Defense = 2;
        public const int Redneck_Speed = 5;
        public const int Redneck_NumberOfFramesBeforeMove = 5;
        public const int Redneck_LineOfSite = 6;

        //Priest
        public const int Priest_Health = 10;
        public const int Priest_AttackDamageMelee = 2;
        public const int Priest_AttackDamageRanged = 4;
        public const int Priest_AttackRange = 6;
        public const int Priest_Defense = 2;
        public const int Priest_Speed = 5;
        public const int Priest_NumberOfFramesBeforeMove = 5;
        public const int Priest_LineOfSite = 6;

        //Sheriff
        public const int Sheriff_Health = 10;
        public const int Sheriff_AttackDamageMelee = 2;
        public const int Sheriff_AttackDamageRanged = 4;
        public const int Sheriff_AttackRange = 6;
        public const int Sheriff_Defense = 2;
        public const int Sheriff_Speed = 5;
        public const int Sheriff_NumberOfFramesBeforeMove = 5;
        public const int Sheriff_LineOfSite = 6;

        //Hay
        public const int Hay_Health = 10;
        public const int Hay_AttackDamageMelee = 0;
        public const int Hay_AttackDamageRanged = 0;
        public const int Hay_AttackRange = 0;
        public const int Hay_Defense = 2;
        public const int Hay_Speed = 0;
        public const int Hay_LineOfSite = 0;
        public const int Hay_NumberOfFramesBeforeMove = 0;

        //Car
        public const int Car_Health = 100; //burn time
        public const int Car_AttackDamageMelee = 0;
        public const int Car_AttackDamageRanged = 4;
        public const int Car_AttackRange = 1;
        public const int Car_Defense = 5;
        public const int Car_Speed = 0;
        public const int Car_NumberOfFramesBeforeMove = 0;
        public const int Car_LineOfSite = 1;

        //Pit
        public const int Pit_Health = 3; //Number of Enemies that can fit into the pit
        public const int Pit_AttackDamageMelee = 1; //Damage to unit per timespan
        public const int Pit_AttackDamageRanged = 0;
        public const int Pit_AttackRange = 0;
        public const int Pit_Defense = 0;
        public const int Pit_Speed = 0;
        public const int Pit_LineOfSite = 0;
        public const int Pit_NumberOfFramesBeforeMove = 0;

        //Base
        public const int Base_Health = 100;
        public const int Base_AttackDamageMelee = 0;
        public const int Base_AttackDamageRanged = 0;
        public const int Base_AttackRange = 0;
        public const int Base_Defense = 2;
        public const int Base_Speed = 0;
        public const int Base_LineOfSite = 0;
        public const int Base_NumberOfFramesBeforeMove = 0;

        //Fog Effect
        public const int FogSpeed = 1;
        public const int Fog_UpdateRate = 2;
        public static float Fog_StartAlpha = .01f;
        public static float Fog_AlphaThreshold = 1.0f;
        public static float Fog_AlphaIncrement = .005f;
        public static float Fog_ResetValue = .7f;

        //Map
        public static int MapEdgeX = 1248;
        public static int MapEdgeY = 672;


        public static float Right = (float)Math.PI / 2.0f;
        public static float Left = (float)(3.0f * (float)(Math.PI / 2));
        public static float Down = (float)Math.PI;
        public static float Up = 0.0f;
        
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

    public enum MusicType
    {
        TBG
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

    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }


}
