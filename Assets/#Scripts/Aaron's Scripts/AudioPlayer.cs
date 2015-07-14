using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

	public AudioClip[] audio;

	public AudioSource source;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAudio(int i)
	{
		source.clip = audio[i];
		source.Play ();
	}

	public void PlayAudioAt(int i, float time)
	{
		source.clip = audio[i];
		source.time = time;
		source.Play ();
	}
}
