using UnityEngine;
using System.Collections;

public class SoundSystem : MonoBehaviour {

	public static SoundSystem instance;
	public AudioClip audWin;
	public AudioClip audDie;
	public AudioClip audTap;

	public AudioSource audSource;
	public AudioSource audBackGroud;

	private void Awake(){

		if (SoundSystem.instance == null) {
			SoundSystem.instance = this;
		} else {
			Destroy (gameObject);
		}
	}
  
	public void PlayWin(){

		PlayAudioClip (audWin);
	}

	public void PlayDie(){
		PlayAudioClip (audDie);
	}
	public void PlayTap(){
		PlayAudioClip (audTap);
	}

	private void PlayAudioClip(AudioClip source){
		audSource.clip = source;
		audSource.Play ();

	}

	public void StopAudio(){
		audBackGroud.Stop ();
	}
	private void OnDestroy(){
	
		if (SoundSystem.instance == this) {
			SoundSystem.instance = null;
		}
	}
}
