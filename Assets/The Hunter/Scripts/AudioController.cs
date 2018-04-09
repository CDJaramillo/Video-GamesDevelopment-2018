using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour 
{
	public AudioMixer masterMixer;

	public void MusicSetSound(float soundLevel)
	{
		masterMixer.SetFloat("musicVol", soundLevel);
	}
	public void SfxSetSound(float soundLevel)
	{
		masterMixer.SetFloat("sfxVol", soundLevel);
	}
}
