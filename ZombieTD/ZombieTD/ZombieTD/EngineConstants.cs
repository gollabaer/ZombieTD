﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieTD
{
    public static class EngineConstants
    {
        #region FilePaths
        public const string CharacterImageLocation = "Images/Character/";
        public const string StructureImageLocation = "Images/Structure/";
        public const string MapTilesImageLocation = "Images/MapTile/";
        public const string SoundFileLocation = "SoundFX/";
        public const string EffectImageLocation = "Images/Effects/";
        public const string MenuImageLocation = "Images/Menus/";
        public const string MusicFileLocation = "Music/";
        public const string MapFileLocation = "Map.txt";
        #endregion

        #region Game Settings
        //Logging Switch
        public const bool IsLogging = true;
        //FPS Switch
        public const bool showFPS = true;
        //Ticks Switch
        public static bool ShowTicks = true;
        //Framerate Settings
        public static bool DisableFrameRate = true;
        //Mouse XY Switch
        public static bool ShowMouseXY = true;
        #endregion

        #region HUD Display Locations
        //FPS Display
        public const float FPSX = 10.0f;
        public const float FPSY = 630.0f;

        //Ticks Display
        public const float TicksX = 10.0f;
        public const float TicksY = 650.0f;

        //Mouse XY Display
        public static float MouseX = 10.0f;
        public static float MouseY = 610.0f;
        #endregion

        #region Texture Constants
        public const int SmallTextureHeight = 32;
        public const int SmallTextureWidth = 32;
        public const int ScreenWidth = EngineConstants.SmallTextureWidth * 40;
        public const int ScreenHeight = EngineConstants.SmallTextureWidth * 22;
        public const int GameX = 1279;
        public const int GameY = 703;
        #endregion

        #region Character Directions
        public static float Up = 0.0f;
        public static float UpRight = .78539815f;
        public static float Right = (float)Math.PI / 2.0f;
        public static float DownRight = 2.35619452f;
        public static float Down = (float)(2.0f * (float)(Math.PI / 2));
        public static float DownLeft = 3.92699089f;
        public static float Left = (float)(3.0f * (float)(Math.PI / 2));
        public static float UpLeft = 5.49778715f;
        #endregion

        #region Character Select menu
        public const int SelectMenuTextureHeight = 64;
        public const int SelectMenuTextureWidth = 352;
        public const int MenuStartX = 928;
        public const int MenuStartY = 0;

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
        #endregion

        #region Score Menu
        public const int ScoreTextureHeight = 128;
        public const int ScoreTextureWidth = 160;
        public const int ScoreStartX = 0;
        public const int ScoreStartY = 0;

        //Score Game Over
        public const int GO_TotalKills_X = 225;
        public const int GO_TotalKills_Y = 365;
        public const int GO_TotalKilled_X = 225;
        public const int GO_TotalKilled_Y = 395;
        public const int GO_TotalTownsfolk_X = 225;
        public const int GO_TotalTownsfolk_Y = 425;
        public const int GO_TotalZombies_X = 225;
        public const int GO_TotalZombies_Y = 455;
        public const int GO_SurvivalTime_X = 225;
        public const int GO_SurvivalTime_Y = 485;
        public const int GO_FinalScore_X = 225;
        public const int GO_FinalScore_Y = 535;

        //Score Game Running
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
        #endregion

        #region Splash Screen
        public const int Button_Help_TopX = 249;
        public const int Button_Help_TopY = 415;
        public const int Button_Help_BottomX = 745;
        public const int Button_Help_BottomY = 562;

        public const int Button_Start_TopX = 249;
        public const int Button_Start_TopY = 246;
        public const int Button_Start_BottomX = 745;
        public const int Button_Start_BottomY = 388;

        public const int SplashScreenTextureHeight = 704;
        public const int SplashScreenTextureWidth = 1280;
        #endregion

        #region GameOverScreen
        public const int Button_Yes_TopX = 807;
        public const int Button_Yes_TopY = 508;
        public const int Button_Yes_BottomX = 889;
        public const int Button_Yes_BottomY = 549;

        public const int Button_No_TopX = 906;
        public const int Button_No_TopY = 508;
        public const int Button_No_BottomX = 986;
        public const int Button_No_BottomY = 549;

        public const int GameOverScreenTextureHeight = 704;
        public const int GameOverScreenTextureWidth = 1280;
        #endregion

        #region Help Screen
        public const int Button_Back_TopX = 1137;
        public const int Button_Back_TopY = 630;
        public const int Button_Back_BottomX = 1254;
        public const int Button_Back__BottomY = 678;

        public const int HelpMenuScreenTextureHeight = 704;
        public const int HelpMenuScreenTextureWidth = 1280;
        #endregion

        #region Wave Generator
        //Wave Generator
        public const int NumberOfFramesBeforeOrder = 60;
        public const int MaxNumberOfSpawns = 100;
        public const int NumberOfFramsBeforeSound = 1000;
        #endregion

        #region Map 
        public static int MapEdgeX = 1248;
        public static int MapEdgeY = 672;
        #endregion

        #region Zombie
        public const int Zombie_Health = 9;
        public const int Zombie_AttackDamageMelee = 2;
        public const int Zombie_AttackDamageRanged = 4;
        public const int Zombie_AttackRange = 6;
        public const int Zombie_Defense = 2;
        public const int Zombie_Speed = 1;
        public const int Zombie_NumberOfFramesBeforeMove = 3;
        public const int Zombie_LineOfSite = 2;
        public const int Zombie_NumberOfFramesBeforeAttack = 100;
        #endregion

        #region ZombieDog
        public const int ZombieDog_Health = 10;
        public const int ZombieDog_AttackDamageMelee = 2;
        public const int ZombieDog_AttackDamageRanged = 4;
        public const int ZombieDog_AttackRange = 6;
        public const int ZombieDog_Defense = 2;
        public const int ZombieDog_Speed = 2;
        public const int ZombieDog_NumberOfFramesBeforeMove = 2;
        public const int ZombieDog_LineOfSite = 2;
        public const int ZombieDog_NumberOfFramesBeforeAttack = 100;
        #endregion

        #region FlyingZombie
        public const int FlyingZombie_Health = 10;
        public const int FlyingZombie_AttackDamageMelee = 2;
        public const int FlyingZombie_AttackDamageRanged = 4;
        public const int FlyingZombie_AttackRange = 6;
        public const int FlyingZombie_Defense = 2;
        public const int FlyingZombie_Speed = 5;
        public const int FlyingZombie_NumberOfFramesBeforeMove = 5;
        public const int FlyingZombie_LineOfSite = 6;
        public const int FlyingZombie_NumberOfFramesBeforeAttack = 100;
        #endregion

        #region Redneck
        public const int Redneck_Health = 10;
        public const int Redneck_AttackDamageMelee = 2;
        public const int Redneck_AttackDamageRanged = 4;
        public const int Redneck_AttackRange = 6;
        public const int Redneck_Defense = 2;
        public const int Redneck_Speed = 5;
        public const int Redneck_NumberOfFramesBeforeMove = 5;
        public const int Redneck_LineOfSite = 2;
        public const int Redneck_MovmentRange = 4;
        #endregion

        #region Priest
        public const int Priest_Health = 3;
        public const int Priest_AttackDamageMelee = 5;
        public const int Priest_AttackDamageRanged = 5;
        public const int Priest_AttackRange = 2;
        public const int Priest_Defense = 2;
        public const int Priest_Speed = 2;
        public const int Priest_NumberOfFramesBeforeMove = 2;
        public const int Priest_LineOfSite = 2;
        #endregion

        #region Sheriff
        public const int Sheriff_Health = 10;
        public const int Sheriff_AttackDamageMelee = 2;
        public const int Sheriff_AttackDamageRanged = 4;
        public const int Sheriff_AttackRange = 6;
        public const int Sheriff_Defense = 2;
        public const int Sheriff_Speed = 2;
        public const int Sheriff_NumberOfFramesBeforeMove = 2;
        public const int Sheriff_LineOfSite = 3;
        #endregion

        #region Hay
        public const int Hay_Health = 10;
        public const int Hay_AttackDamageMelee = 0;
        public const int Hay_AttackDamageRanged = 0;
        public const int Hay_AttackRange = 0;
        public const int Hay_Defense = 2;
        public const int Hay_Speed = 0;
        public const int Hay_LineOfSite = 0;
        public const int Hay_NumberOfFramesBeforeMove = 0;
        #endregion

        #region Car
        public const int Car_Health = 20; //burn time
        public const int Car_AttackDamageMelee = 1;
        public const int Car_AttackDamageRanged = 0;
        public const int Car_AttackRange = 1;
        public const int Car_Defense = 5;
        public const int Car_Speed = 0;
        public const int Car_NumberOfFramesBeforeMove = 0;
        public const int Car_LineOfSite = 1;
        #endregion

        #region Pit
        public const int Pit_Health = 3; //Number of Enemies that can fit into the pit
        public const int Pit_AttackDamageMelee = 9999; //Damage to unit per timespan
        public const int Pit_AttackDamageRanged = 0;
        public const int Pit_AttackRange = 0;
        public const int Pit_Defense = 3; 
        public const int Pit_Speed = 0;
        public const int Pit_LineOfSite = 0;
        public const int Pit_NumberOfFramesBeforeMove = 0;
        #endregion

        #region Base
        public const int Base_Health = 100;
        public const int Base_AttackDamageMelee = 0;
        public const int Base_AttackDamageRanged = 0;
        public const int Base_AttackRange = 0;
        public const int Base_Defense = 2;
        public const int Base_Speed = 0;
        public const int Base_LineOfSite = 0;
        public const int Base_NumberOfFramesBeforeMove = 0;
        #endregion

        #region Fog EffectFog Effect
        public const int FogSpeed = 1;
        public const int Fog_UpdateRate = 2;
        public static float Fog_StartAlpha = .01f;
        public static float Fog_AlphaThreshold = 1.0f;
        public static float Fog_AlphaIncrement = .005f;
        public static float Fog_ResetValue = .7f;
        #endregion
    }

    //Used to track the state of the game
    public enum GameState
    {
        SplashScreen,
        HelpMenu,
        GameRunning,
        GameOver,
        GameReset,
        GameExit
    }

    //Used for Loading/Getting the Textures
    //Used for Character Movment AI
    public enum MapTileType
    {
        [ZombieDog]
        [Zombie]
        [Sheriff]
        [FlyingZombie]
        [Priest]
        RoadOutside,
        [Sheriff]
        [FlyingZombie]
        [Priest]
        Building_roof_center,
        [Sheriff]
        [FlyingZombie]
        [Priest]
        Building_roof_corner,
        [Sheriff]
        [FlyingZombie]
        [Priest]
        Building_Roof_Side,
        [Sheriff]
        [FlyingZombie]
        [Priest]
        Grass,
        [ZombieDog]
        [Zombie]
        [Sheriff]
        [FlyingZombie]
        [Priest]
        Path_noRock,
        [ZombieDog]
        [Zombie]
        [Sheriff]
        [FlyingZombie]
        [Priest]
        Path_withRock,
        [ZombieDog]
        [Zombie]
        [Sheriff]
        [FlyingZombie]
        [Priest]
        Path_Corner,
        [ZombieDog]
        [Zombie]
        [FlyingZombie]
        [Sheriff]
        [Priest]
        RoadMiddle,
        [Sheriff]
        [FlyingZombie]
        RoofTownHall_corner,
        [Sheriff]
        [FlyingZombie]
        TownHallRoof_Middle,
        [Sheriff]
        [FlyingZombie]
        TownhallRoof_Side,
        [FlyingZombie]
        Tree,
        Error
    }

    //Used for Loading/Getting Textures
    public enum CharacterTextureType
    {
        Zombie,
        ZombieDog,
        FlyingZombie,
        Priest,
        RedNeck,
        Sheriff
    }

    //Used for Loading/Getting Textures
    public enum StructureTextureType
    {
        Hay,
        Car,
        Pit
    }

    //Used for Loading/Getting Textures
    //Used for Character Attack AI
    public enum SpawnType
    {
        [EnemyWaveGenerator]
        [Car]
        [Priest]
        Zombie,
        [EnemyWaveGenerator]
        [Car]
        [Priest]
        ZombieDog,
        [EnemyWaveGenerator]
        [Priest]
        FlyingZombie,
        [ZombieDog]
        [Zombie]
        Priest,
        [ZombieDog]
        [Zombie]
        [FlyingZombie]
        RedNeck,
        [ZombieDog]
        [Zombie]
        [FlyingZombie]
        Sheriff,
        [ZombieDog]
        [Zombie]
        Hay,
        [ZombieDog]
        [Zombie]
        Car,
        Pit
    }

    //Used for Loading/Playing Music
    public enum MusicType
    {
        TBG
    }

    //Used for Loading/Playing Sound Effects
    //Used for Enemy Spawn Pool to Load/Play Sound Effects
    //Used for Character to Load/Play Sound Effects
    public enum SoundType
    {
        [Car]
        Fire,
        [Sheriff]
        Gunshot,
        [Priest]
        HolyWater,
        [Priest]
        Priest,
        [EnemySpawnPool]
        Zombie1,
        [EnemySpawnPool]
        Zombie2,
        [EnemySpawnPool]
        Zombie3,
        [EnemySpawnPool]
        Zombie4,
        [EnemySpawnPool]
        Zombie5,
        [Redneck]
        Chainsaw,
        BaseAttack,
        Error

    }

    //Used to Load/Get Textures
    public enum EffectTextureType
    {
        Fog,
        SelectTile,
        CharacterSelection
    }

    //Used to Load/Get Textures
    public enum MenuTextureType
    {
        SelectMenu,
        Score,
        SplashScreen,
        GameOver,
        HelpMenu
    }

    //Used By SpawnPools
    public enum OrderFor
    {
        Player,
        Enemy
    }

    //Used by Character AI
    public enum CurrentAction
    {
        Attack,
        Range,
        Move,
        Special1,
        Special2,
        Special3,
        None
    }

    //Used by Character AI
    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right,
        None
    }
}
