using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour {


    public MenuSettings menuSettings;
	public AudioClip titleMusic;					//Assign Audioclip for title music loop
	public AudioClip mainMusic;						//Assign Audioclip for main 
	public AudioMixerSnapshot volumeDown;			//Reference to Audio mixer snapshot in which the master volume of main mixer is turned down
	public AudioMixerSnapshot volumeUp;				//Reference to Audio mixer snapshot in which the master volume of main mixer is turned up

	private AudioSource musicSource;                //Reference to the AudioSource which plays music	private AudioSource lastMusicPlayed;
	private float resetTime = .1f;                 //Very short time used to fade in near instantly without a click

	void Awake () 
	{
		//Get a component reference to the AudioSource attached to the UI game object
		musicSource = GetComponent<AudioSource> ();
		//Call the PlayLevelMusic function to start playing music
	}


	public void PlayLevelMusic()
	{
		//This switch looks at the last loadedLevel number using the scene index in build settings to decide which music clip to play.
		switch (SceneManager.GetActiveScene().buildIndex)
		{
			//If scene index is 0 (usually title scene) assign the clip titleMusic to musicSource
			case 0:
				musicSource.clip = menuSettings.mainMenuMusicLoop;
				break;
			//If scene index is 1 (usually main scene) assign the clip mainMusic to musicSource
			case 1:
                Debug.Log("Scene index is 1, setting music to " + menuSettings.musicWorldMap);
				musicSource.clip = menuSettings.musicWorldMap;
				break;
			case 2:
				Debug.Log("Scene index is 2, setting music to " + menuSettings.musicLevel1);
				musicSource.clip = menuSettings.musicLevel1;
				break;
			case 3:
				Debug.Log("Scene index is 3, setting music to " + menuSettings.musicLevel2);
				musicSource.clip = menuSettings.musicLevel2;
				break;
			case 4:
				Debug.Log("Scene index is 4, setting music to " + menuSettings.musicLevel3);
				musicSource.clip = menuSettings.musicLevel3;
				break;
			case 5:
				Debug.Log("Scene index is 5, setting music to " + menuSettings.musicIntro);
				musicSource.clip = menuSettings.musicIntro;
				break;
			case 6:
				Debug.Log("Scene index is 5, setting music to " + menuSettings.musicOutro);
				musicSource.clip = menuSettings.musicOutro;
				break;
		}


		FadeUp(resetTime);
		//Play the assigned music clip in musicSource
		musicSource.Play();
	}
	
	public void StopMusic()
    {
		FadeDown(resetTime);
		musicSource.Stop();
    }

	//Used if running the game in a single scene, takes an integer music source allowing you to choose a clip by number and play.
	public void PlaySelectedMusic(AudioClip clipToPlay)
	{
		musicSource.clip = clipToPlay;

		//Play the selected clip
		FadeUp(resetTime);
		musicSource.Play();
	}

	//Call this function to very quickly fade up the volume of master mixer
	public void FadeUp(float fadeTime)
	{
		//call the TransitionTo function of the audioMixerSnapshot volumeUp;
		volumeUp.TransitionTo (fadeTime);
	}

	//Call this function to fade the volume to silence over the length of fadeTime
	public void FadeDown(float fadeTime)
	{
		//call the TransitionTo function of the audioMixerSnapshot volumeDown;
		volumeDown.TransitionTo(fadeTime);
	}
}
