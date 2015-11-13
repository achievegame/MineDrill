using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MAudioManager : MonoBehaviour {

	public static MAudioManager current;	//a reference to our game control so we can access it statically

	[SerializeField]
	public AudioSource sfxSource;
	[SerializeField]
	public AudioSource musicSource;
	[SerializeField]
	public AudioSource DiggingMusicSource;
	[SerializeField]
	public AudioSource FanMusicSource;
	[SerializeField]
	public AudioSource AlertMusicSource;

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


	public void StopThemeMusic(){
		musicSource.Stop ();
	}



	public void PlayGameThemeMusic(){
		if (isMusicOn) {
			musicSource.Play();
		}
	}

	public void StopGameThemeMusic(){
		musicSource.Stop ();
	}

	public void PauseGameThemeMusic(){
		musicSource.Pause ();
	}

	public void ResumeGameThemeMusic(){
		if (isMusicOn) {
			musicSource.Play();
		}
	}




	public void PlayDigSound(){
		if (!isSoundOn)
			return;
		if (DiggingMusicSource.isPlaying) {
			return;
		}
		DiggingMusicSource.Play ();
	}
	
	public void PlayFanSound(){
		if (!isSoundOn)
			return;
		if (FanMusicSource.isPlaying) {
			return;
		}
		FanMusicSource.Play ();
	}
	
	public void pauseSFX(){
		if (!isSoundOn)
			return;
		FanMusicSource.Pause ();
		DiggingMusicSource.Pause ();
	}


	public void PlayTimeAlert(){
		if (!isSoundOn)
			return;
		AlertMusicSource.Play ();
	}
	public void StopTimeAlert(){
		if (!isSoundOn)
			return;
		AlertMusicSource.Stop ();
	}


	public bool IsMusicOn {
		get{
			return isMusicOn;
		}
		set {

			isMusicOn = value;
			PlayerPrefs.SetInt(musicToggle,isMusicOn?1:0);		
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



