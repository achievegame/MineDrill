using System;
using UnityEngine;

public class Constants {
	public static readonly Vector3 POS_TOP	=	Vector3.zero;
	public const string RESOURCELOCATION_AUDIO = "Audio/";
	public const string RESOURCELOCATION_PREFAB = "prefab/";
	public const string RESOURCELOCATION_ANIMATION = "animations/Animation_";
	public const string TAG_HUD = "HUD";
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

public enum Navigation{
	None=-1,
	Right,
	RightUp,
	Up,
	LeftUp,
	Left,
	LeftDown,
	Down,
	RightDown
}
