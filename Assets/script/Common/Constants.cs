﻿using System;
using UnityEngine;

public class Constants {
	public static readonly Vector3 POS_TOP	=	Vector3.zero;

	public const string USER_DATA_FILE = "animinemap.anm";

	public const string RESOURCELOCATION_AUDIO = "Audio/";
	public const string RESOURCELOCATION_PREFAB = "prefab/";
	public const string RESOURCELOCATION_ANIMATION = "animations/Animation_";
	public const string TAG_HUD = "HUD";
	public const string TAG_HUD_MANAGER = "HUDManager";
	public const string TAG_PLAYER = "Player";

	public const string HUD_HEROES = "Heroes";
	public const string HUD_BAG = "Bag";
	public const string HUD_STORE = "Store";
	public const string HUD_MISSION = "Mission";
	public const string HUD_EARN_COIN = "EarnCoin";
	public const string HUD_HUD = "HUD";
	public const string HUD_PAUSE_SCREEN = "PauseScreen";
	public const string HUD_SETTINGS = "Settings";
	public const string HUD_LANGUAGES = "LanguageSelector";
	public const string HUD_WANT_TO_QUIT = "QuitMessage";
	public const string HUD_GAME_COMPLETE = "GameComplete";
	public const string HUD_GAME_OVER = "GameOver";
	public const string HUD_MESSAGE_POPUP = "MessagePopup";
	public const string HUD_SHOP = "InAppPurchase";
	public const string HUD_TUTORIAL = "Tutorial";


	public const float GRID_WIDTH = 1.74f;
	public const float GRID_HEIGHT = 1.65f;

	public static readonly string[] AUDIO_NAME={
		AudioName.ThemeGameMusic.ToString(),
		AudioName.TimeOverAlert.ToString(),
		AudioName.FanSound.ToString(),
		AudioName.DiggingSound.ToString(),
		AudioName.Explosion.ToString(),
		AudioName.ButtonClick.ToString(),
		AudioName.MineralGrabSound.ToString()
	};

	//prices & scores
	public static readonly int[] MINERAL_PRICE = {20,30,50,80,110,150,180,200};
	public static readonly int[] BRICK_DIGGING_SCORE = {1,2,3,4,5,6,7,8};
	public const int STONE_BLAST_SCORE = 100;
	public static readonly float[] BATTERY_DURATION = {60f,120f,180f,240f,300f,360f};
	public static readonly int[] DRILLER_STRENGTH = {2,5,8,11,14,17};
	public static readonly int[] FAN_SPEED = {8,12,16,20,25,30};
}

public enum AudioName{
	ThemeGameMusic,
	TimeOverAlert,
	FanSound,
	DiggingSound,
	Explosion,
	ButtonClick,
	MineralGrabSound
}

public enum RelativeDirection{
	None=-1,
	Right,
	Top,
	Left,
	Bottom
}

public enum Hero{
	Piggy,
	Cowy,
	Beary,
	Tigey,
	Draggy
}

public enum BrickType{
	A=0,
	B,
	C,
	D,
	E,
	F,
	G,
	H
}

public enum ToolType{
	None=-1,
	Driller,
	Fan,
	Battery,
	Dynamite,
	Bag
}

public enum MineralType{
	None=-1,
	Coal,
	Iron,
	Copper,
	Silver,
	Emerald,
	Gold,
	Ruby,
	Diamond,
	Stone,
	NonBreakableStone
}