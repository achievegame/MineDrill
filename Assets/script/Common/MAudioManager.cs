using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MAudioManager : MonoBehaviour {

	public static MAudioManager current;	//a reference to our game control so we can access it statically

	public AudioSource sfxSource;
	public AudioSource musicSource;
	public AudioSource addOn1MusicSource;
	public AudioSource addOn2MusicSource;

	private bool isMusicOn = true;
	private bool isSoundOn = true;

	const string musicToggle = "MusicToggle";
	const string soundToggle = "SoundToggle";

	void Awake()
	{
		//if we don't currently have a game control...
		if (current == null)
			//...set this one to be it...
			current = this;
		//...otherwise...
		else if(current != this)
			//...destroy this one because it is a duplicate
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		foreach(string aName in Constants.AUDIO_NAME){
			AudioClip aClip= Resources.Load(Constants.RESOURCELOCATION_AUDIO+aName) as AudioClip;
			audioDict.Add (aName, aClip);
		}

		isMusicOn = PlayerPrefs.GetInt (musicToggle, 1)==1;
		isSoundOn = PlayerPrefs.GetInt (soundToggle, 1)==1;


	}
	private Dictionary<string,AudioClip> audioDict=new Dictionary<string, AudioClip>(Constants.AUDIO_NAME.Length);

	public void PlayFx(string aName){
		if (isSoundOn) {
			sfxSource.PlayOneShot (audioDict [aName.ToString ()]);
		}
	}

	public void PlayFx(AudioName aName){
		if (isSoundOn) {
			sfxSource.PlayOneShot (audioDict [aName.ToString ()]);
		}
	}

	public void PlayFx(AudioName aName, float delay){
		if (isSoundOn) {
			sfxSource.clip = audioDict [aName.ToString ()];
			sfxSource.PlayDelayed (delay);
		}
	}

	public void PlayThemeMusic(AudioName aName = AudioName.ThemeMenuMusic){
		if (isMusicOn) {
			StopGameThemeMusic ();
			
			musicSource.clip = audioDict [aName.ToString()];
			musicSource.loop = true;
			musicSource.Play ();
		}
	}

	public void StopThemeMusic(){
		musicSource.Stop ();
	}



	public void PlayGameThemeMusic(){
		if (isMusicOn) {
			StopThemeMusic ();			

			musicSource.clip = audioDict [AudioName.ThemeGameMusic.ToString ()];
			musicSource.loop = true;
		}

	}

	public void StopGameThemeMusic(){
		musicSource.Stop ();
	}

	public void PauseGameThemeMusic(){
		musicSource.Pause ();
	}

	public void ResumeGameThemeMusic(){
		musicSource.Play ();
	}


	public bool IsMusicOn {
		get{
			return isMusicOn;
		}
		set {

			isMusicOn = value;
			PlayerPrefs.SetInt(musicToggle,isMusicOn?1:0);
			if(isMusicOn){
				PlayThemeMusic();
			}else{
				StopThemeMusic();
			}
		}
	}
	
	public bool IsSoundOn {
		get{
			return isSoundOn;
		}
		set {
			isSoundOn = value;
			PlayerPrefs.SetInt(soundToggle,isSoundOn?1:0);
		}
	}


}



