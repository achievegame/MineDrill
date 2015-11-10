using System;
using UnityEngine;

public delegate void gameOverAction();
public delegate void readyForPlayingAction(bool instantPlay=false);
public delegate void gameStart();
public delegate void gamePaused(bool isPaused=true);
public delegate void ToggleButtonChanged(int index);
public delegate void characterChanged(int index);
public delegate void mineralAdded();
public delegate void LanguageChanged();