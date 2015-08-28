using System;
using UnityEngine;

public delegate void gameOverAction();
public delegate void readyForPlayingAction(bool instantPlay=false);
public delegate void gameStart();
public delegate void gamePaused(bool isPaused=true);
public delegate void ToggleButtonChanged();