using UnityEngine;
using System.Collections;

public class Snd_FX : MonoBehaviour
{
	private AudioSource source;
	public void Play(AudioClip clip)
	{
		source = GetComponent<AudioSource>();
		source.clip = clip;
		source.Play();
	}

	void Update()
	{
		if(null != source && false == source.isPlaying)
		{
			Destroy(gameObject);
		}
	}
}

public class SoundManager
{
	public static void PlayFX(AudioClip clip)
	{
		GameObject sndFX = new GameObject();
		sndFX.AddComponent<AudioSource>();
		sndFX.AddComponent<Snd_FX>();
		sndFX.transform.name = "SndFX";

		sndFX = Object.Instantiate(sndFX, Vector3.up, Quaternion.identity) as GameObject;
		sndFX.GetComponent<Snd_FX>().Play(clip);
	}
}
