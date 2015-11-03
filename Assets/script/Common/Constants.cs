using System;
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
	public const string HUD_HUD = "HUD";
	public const string HUD_PAUSE_SCREEN = "PauseScreen";
	public const string HUD_SETTINGS = "Settings";
	public const string HUD_LANGUAGES = "LanguageSelector";


	public const float GRID_WIDTH = 1.74f;
	public const float GRID_HEIGHT = 1.65f;

	public static readonly string[] AUDIO_NAME={
		AudioName.ThemeGameMusic.ToString(),
		AudioName.ThemeMenuMusic.ToString()
	};

	public static readonly string[] AWARD_ANIMATION_NAME = {"GoldFishDash","BagOfFish","DolphinSwim"};
	public static readonly string[] AWARD_NAME = {"Dash Fish","Bag Of Fish","Dolphin"};
}

public enum AudioName{
	ThemeGameMusic,
	ThemeMenuMusic
}

public enum RelativeDirection{
	None=-1,
	Right,
	Top,
	Left,
	Bottom
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

public enum MineralType{
	None=-1,
	Coal,
	Copper,
	Iron,
	Silver,
	Emerald,
	Gold,
	Ruby,
	Diamond,
	Stone,
	NonBreakableStone
}