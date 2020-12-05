using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudioLevels : MonoBehaviour {

	public AudioMixer mainMixer;                    //Used to hold a reference to the AudioMixer 

	[SerializeField] Slider optionMusicSlider = null;
	[SerializeField] Slider optionSFXSlider = null;
	[SerializeField] Slider pauseMusicSlider = null;
	[SerializeField] Slider pauseSFXSlider = null;

    private void Start()
    {
		SetSfxLevel(-10);
    }

    //Call this function and pass in the float parameter musicLvl to set the volume of the AudioMixerGroup Music in mainMixer
    public void SetMusicLevel(float musicLvl)
	{
		mainMixer.SetFloat("musicVol", musicLvl);
		optionMusicSlider.value = musicLvl;
		pauseMusicSlider.value = musicLvl;
	}

	//Call this function and pass in the float parameter sfxLevel to set the volume of the AudioMixerGroup SoundFx in mainMixer
	public void SetSfxLevel(float sfxLevel)
	{
		mainMixer.SetFloat("sfxVol", sfxLevel);
		optionSFXSlider.value = sfxLevel;
		pauseSFXSlider.value = sfxLevel;
	}
}
